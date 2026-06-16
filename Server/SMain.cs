using Library;
using Library.SystemModels;
using MirDB;
using PluginCore;
using Server.DBModels;
using Server.Envir;
using Server.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// 服务端主窗口类
    /// 基于标准 WinForms Form 实现，提供服务端管理界面
    /// 包含：服务器启停控制、数据表管理、日志查看、插件管理等功能
    /// </summary>
    public partial class SMain : Form
    {
        /// <summary>已打开的子页面列表（UserControl 实例）</summary>
        public List<Control> Windows = new List<Control>();
        /// <summary>MirDB 数据库会话（服务端模式）</summary>
        public static Session Session;
        /// <summary>服务端状态缓存文件路径（JSON 格式）</summary>
        private static readonly string CacheFilePath = Path.Combine(Application.StartupPath, "Server.cache.json");

        public SMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化插件系统
        /// 注册插件事件处理器（日志、视图、地图查看器），加载所有 Plugin.*.dll 插件
        /// </summary>
        private void SetupPlugin()
        {
            PluginLoader.Instance.Log += PluginLoader_Log;
            PluginLoader.Instance.View += PluginLoader_ShowView;
            PluginLoader.Instance.MapViewer += PluginLoader_MapViewer;

            PluginLoader.LoadPlugins(pluginsToolStrip, SMain.Session);

            // 如果有插件添加了按钮，则显示工具栏
            if (pluginsToolStrip.Items.Count > 0)
                pluginsToolStrip.Visible = true;
        }

        private void PluginLoader_Log(object sender, PluginCore.LogEventArgs e)
        {
            SEnvir.Log(e.Message);
        }

        private void PluginLoader_ShowView(object sender, ShowViewEventArgs e)
        {
            ShowView(e.View);
        }

        private void PluginLoader_MapViewer(object sender, ShowMapViewerEventArgs e)
        {
            if (string.IsNullOrEmpty(e.MapPath)) return;

            if (MapViewer.CurrentViewer == null)
            {
                MapViewer.CurrentViewer = new MapViewer();
                MapViewer.CurrentViewer.Show();
            }

            MapViewer.CurrentViewer.BringToFront();

            if (!System.IO.File.Exists(e.MapPath))
            {
                MessageBox.Show("Map file does not exist.");
                return;
            }

            MapViewer.CurrentViewer.MapPath = e.MapPath;
        }

        /// <summary>
        /// 窗口加载事件：初始化数据库会话、加载配置、构建导航树、启动界面
        /// </summary>
        private void SMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Config.EncryptionKey))
                    SEnvir.CryptoKey = Convert.FromBase64String(Config.EncryptionKey);
            }
            catch (Exception)
            {
                throw new ApplicationException($"Invalid format encryption key, expected a base64 with 32 bytes");
            }

            if (Config.EncryptionEnabled && SEnvir.CryptoKey == null)
                throw new ApplicationException($"Encryption is enabled but not specified key [System] => DatabaseKey");

            if (Config.EncryptionEnabled)
                Encryption.SetKey(SEnvir.CryptoKey);

            LoadUserCache();

            // 初始化 MirDB 数据库会话（System 模式，用于服务端配置数据）
            // 加载 LibraryCore 和 ServerLibrary 程序集中的所有 DBObject 子类
            Session = new Session(SessionMode.System)
            {
                BackUpDelay = 60
            };

            Session.Initialize(
                Assembly.GetAssembly(typeof(ItemInfo)), // returns assembly LibraryCore
                Assembly.GetAssembly(typeof(AccountInfo)) // returns assembly ServerLibrary
            );

            CurrencyInfoView.AddDefaultCurrencies();

            BuildNavigationTree();

            SetupPlugin();

            UpdateInterface();

            // 默认打开 SystemLogView
            ShowView(typeof(SystemLogView));

            Application.Idle += Application_Idle;
        }

        /// <summary>
        /// 构建左侧导航树
        /// 将原有的 NavBarGroup/NavBarItem 结构映射为 TreeNode 层级
        /// </summary>
        private void BuildNavigationTree()
        {
            navigationTreeView.BeginUpdate();
            navigationTreeView.Nodes.Clear();

            // Operations
            var operations = navigationTreeView.Nodes.Add("Operations", "Operations");
            operations.Nodes.Add("SystemLogView", "System Log");
            operations.Nodes.Add("ChatLogView", "Chat Log");
            operations.Nodes.Add("ConfigView", "Config");

            // Player
            var player = navigationTreeView.Nodes.Add("Player", "Player");
            player.Nodes.Add("BaseStatView", "Base Stats");
            player.Nodes.Add("MagicInfoView", "Magic Info");
            player.Nodes.Add("FameInfoView", "Fame Info");
            player.Nodes.Add("DisciplineInfoView", "Discipline Info");
            player.Nodes.Add("CompanionInfoView", "Companion Info");
            player.Nodes.Add("CurrencyInfoView", "Currency Info");
            player.Nodes.Add("HelpInfoView", "Help Info");

            // Map
            var map = navigationTreeView.Nodes.Add("Map", "Map");
            map.Nodes.Add("MapInfoView", "Map Info");
            map.Nodes.Add("InstanceInfoView", "Instance Info");
            map.Nodes.Add("MapRegionView", "Map Region");
            map.Nodes.Add("MovementInfoView", "Movement Info");
            map.Nodes.Add("SafeZoneInfoView", "Safe Zone Info");
            map.Nodes.Add("FishingInfoView", "Fishing Info");
            map.Nodes.Add("CastleInfoView", "Castle Info");
            map.Nodes.Add("EventInfoView", "Event Info");

            // NPC
            var npc = navigationTreeView.Nodes.Add("NPC", "NPC");
            npc.Nodes.Add("NPCInfoView", "NPC Info");
            npc.Nodes.Add("NPCPageView", "NPC Page");
            npc.Nodes.Add("QuestInfoView", "Quest Info");
            npc.Nodes.Add("MilestoneInfoView", "Milestone Info");
            npc.Nodes.Add("StoreInfoView", "Store Info");

            // Item
            var item = navigationTreeView.Nodes.Add("Item", "Item");
            item.Nodes.Add("ItemInfoView", "Item Info");
            item.Nodes.Add("ItemInfoStatView", "Item Info Stat");
            item.Nodes.Add("SetInfoView", "Set Info");
            item.Nodes.Add("WeaponCraftStatInfoView", "Weapon Craft Info");
            item.Nodes.Add("BundleInfoView", "Bundle Info");
            item.Nodes.Add("LootBoxInfoView", "Loot Box Info");

            // Monster
            var monster = navigationTreeView.Nodes.Add("Monster", "Monster");
            monster.Nodes.Add("MonsterInfoView", "Monster Info");
            monster.Nodes.Add("MonsterInfoStatView", "Monster Info Stat");
            monster.Nodes.Add("DropInfoView", "Drop Info");
            monster.Nodes.Add("RespawnInfoView", "Respawn Info");

            // Management
            var management = navigationTreeView.Nodes.Add("Management", "Management");
            management.Nodes.Add("AccountView", "Account");
            management.Nodes.Add("CharacterView", "Character Info");
            management.Nodes.Add("UserDropView", "User Drop");
            management.Nodes.Add("GameGoldPaymentView", "Payments");
            management.Nodes.Add("GameStoreSaleView", "Store Sales");
            management.Nodes.Add("DiagnosticView", "Diagnostics");
            management.Nodes.Add("OrphanDiagnosticView", "Orphan Diagnostics");
            management.Nodes.Add("UserConquestStatsView", "Conquest Stats");
            management.Nodes.Add("UserMailView", "User Mail");
            management.Nodes.Add("NPCListView", "NPC Data");

            // 展开所有分组
            navigationTreeView.ExpandAll();

            navigationTreeView.EndUpdate();
        }

        /// <summary>
        /// 导航树节点选中事件 — 映射节点名称到 View 类型并打开
        /// </summary>
        private void NavigationTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            // 分组节点（父节点）不打开页面
            if (e.Node.Level == 0) return;

            string viewName = e.Node.Name;
            Type viewType = Type.GetType($"Server.Views.{viewName}");
            if (viewType != null)
            {
                ShowView(viewType);
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            try
            {
                MapViewer.CurrentViewer?.Process();

                while (AppStillIdle)
                {
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                SEnvir.Log(ex.ToString());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveUserCache();

            base.OnFormClosing(e);

            Session.BackUpDelay = 0;
            Session?.Save(true);

            if (SEnvir.EnvirThread == null) return;

            SEnvir.Started = false;

            while (SEnvir.EnvirThread != null) Thread.Sleep(1);
        }

        /// <summary>
        /// 显示指定类型的子页面
        /// 在 TabControl 中查找已打开的页面，或创建新的 UserControl 并添加到 TabPage
        /// </summary>
        private void ShowView(Type type)
        {
            try
            {
                // 查找已打开的同类型页面
                foreach (Control item in Windows)
                {
                    if (item.GetType() == type)
                    {
                        // 找到对应的 TabPage 并激活
                        foreach (TabPage tab in mainTabControl.TabPages)
                        {
                            if (tab.Controls.Contains(item))
                            {
                                mainTabControl.SelectedTab = tab;
                                return;
                            }
                        }
                        return;
                    }
                }

                // 创建新的 UserControl 实例
                UserControl view = (UserControl)Activator.CreateInstance(type);
                view.Dock = DockStyle.Fill;
                view.Tag = type.Name;
                Windows.Add(view);

                // 创建 TabPage 并添加 UserControl
                string tabTitle = type.Name.Replace("View", "").Replace("Info", " Info");
                TabPage tabPage = new TabPage(tabTitle);
                tabPage.Controls.Add(view);
                tabPage.Tag = type;
                mainTabControl.TabPages.Add(tabPage);
                mainTabControl.SelectedTab = tabPage;
            }
            finally
            { }
        }

        private void View_Disposed(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            Windows.Remove(ctrl);

            // 移除对应的 TabPage
            foreach (TabPage tab in mainTabControl.TabPages)
            {
                if (tab.Controls.Contains(ctrl))
                {
                    mainTabControl.TabPages.Remove(tab);
                    tab.Dispose();
                    break;
                }
            }
        }

        /// <summary>TabControl 标签页关闭时移除对应 UserControl</summary>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 预留扩展：可添加标签页关闭按钮等功能
        }

        /// <summary>界面定时器：更新服务端状态显示（连接数、对象数等）</summary>
        private void InterfaceTimer_Tick(object sender, EventArgs e)
        {
            UpdateInterface();

            if (!SEnvir.Started && SEnvir.EnvirThread == null)
                InterfaceTimer.Enabled = false;
        }

        private void UpdateInterface()
        {
            StartServerButton.Enabled = SEnvir.EnvirThread == null;
            StopServerButton.Enabled = SEnvir.Started;

            ConnectionLabel.Text = string.Format(@"Connections: {0:#,##0}", SEnvir.Connections.Count);
            ObjectLabel.Text = string.Format(@"Objects: {0} of {1:#,##0}", SEnvir.ActiveObjects.Count, SEnvir.Objects.Count);
            ProcessLabel.Text = string.Format(@"Process Count: {0:#,##0}", SEnvir.ProcessObjectCount);
            LoopLabel.Text = string.Format(@"Loop Count: {0:#,##0}", SEnvir.LoopCount);
            EMailsSentLabel.Text = string.Format(@"E-Mails Sent: {0:#,##0}", EmailService.EMailsSent);

            ConDelay.Text = string.Format(@"Con Delay: {0:#,##0}ms", SEnvir.ConDelay);
            SaveDelay.Text = string.Format(@"Save Delay: {0:#,##0}ms", SEnvir.SaveDelay);

            const decimal KB = 1024;
            const decimal MB = KB * 1024;
            const decimal GB = MB * 1024;

            if (SEnvir.TotalBytesReceived > GB)
                TotalDownloadLabel.Text = string.Format(@"Downloaded: {0:#,##0.0}GB", SEnvir.TotalBytesReceived / GB);
            else if (SEnvir.TotalBytesReceived > MB)
                TotalDownloadLabel.Text = string.Format(@"Downloaded: {0:#,##0.0}MB", SEnvir.TotalBytesReceived / MB);
            else if (SEnvir.TotalBytesReceived > KB)
                TotalDownloadLabel.Text = string.Format(@"Downloaded: {0:#,##0}KB", SEnvir.TotalBytesReceived / KB);
            else
                TotalDownloadLabel.Text = string.Format(@"Downloaded: {0:#,##0}B", SEnvir.TotalBytesReceived);

            if (SEnvir.TotalBytesSent > GB)
                TotalUploadLabel.Text = string.Format(@"Uploaded: {0:#,##0.0}GB", SEnvir.TotalBytesSent / GB);
            else if (SEnvir.TotalBytesSent > MB)
                TotalUploadLabel.Text = string.Format(@"Uploaded: {0:#,##0.0}MB", SEnvir.TotalBytesSent / MB);
            else if (SEnvir.TotalBytesSent > KB)
                TotalUploadLabel.Text = string.Format(@"Uploaded: {0:#,##0}KB", SEnvir.TotalBytesSent / KB);
            else
                TotalUploadLabel.Text = string.Format(@"Uploaded: {0:#,##0}B", SEnvir.TotalBytesSent);

            if (SEnvir.DownloadSpeed > GB)
                DownloadSpeedLabel.Text = string.Format(@"D/L Speed: {0:#,##0.0}GBps", SEnvir.DownloadSpeed / GB);
            else if (SEnvir.DownloadSpeed > MB)
                DownloadSpeedLabel.Text = string.Format(@"D/L Speed: {0:#,##0.0}MBps", SEnvir.DownloadSpeed / MB);
            else if (SEnvir.DownloadSpeed > KB)
                DownloadSpeedLabel.Text = string.Format(@"D/L Speed: {0:#,##0}KBps", SEnvir.DownloadSpeed / KB);
            else
                DownloadSpeedLabel.Text = string.Format(@"D/L Speed: {0:#,##0}Bps", SEnvir.DownloadSpeed);

            if (SEnvir.UploadSpeed > GB)
                UploadSpeedLabel.Text = string.Format(@"U/L Speed: {0:#,##0.0}GBps", SEnvir.UploadSpeed / GB);
            else if (SEnvir.UploadSpeed > MB)
                UploadSpeedLabel.Text = string.Format(@"U/L Speed: {0:#,##0.0}MBps", SEnvir.UploadSpeed / MB);
            else if (SEnvir.UploadSpeed > KB)
                UploadSpeedLabel.Text = string.Format(@"U/L Speed: {0:#,##0}KBps", SEnvir.UploadSpeed / KB);
            else
                UploadSpeedLabel.Text = string.Format(@"U/L Speed: {0:#,##0}Bps", SEnvir.UploadSpeed);
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                InterfaceTimer.Enabled = true;
                SEnvir.StartServer();
                UpdateInterface();
            }
            catch (Exception ex)
            {
                SEnvir.Log($"Exception: " + ex.ToString(), true);
            }
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            SEnvir.Started = false;
            UpdateInterface();
        }

        /// <summary>
        /// 设置 DataGridView 的通用选项（多选、键盘快捷键）
        /// 替代原有的 GridView 设置方法
        /// </summary>
        public static void SetUpView(DataGridView view)
        {
            view.MultiSelect = true;
            view.SelectionMode = DataGridViewSelectionMode.CellSelect;
            view.AutoResizeColumns();
            view.KeyPress += PasteData_KeyPress;
            view.KeyDown += DeleteRows_KeyDown;
        }

        public static void InsertRowAfterFocusedObject<T>(DataGridView view) where T : DBObject, new()
        {
            var collection = Session.GetCollection<T>();
            string title = $"Insert {typeof(T)}";

            if (view.CurrentRow?.DataBoundItem is not T focusedObject)
            {
                MessageBox.Show($"Please select a {typeof(T)} to insert after.", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string description = focusedObject.ToString();

            if (string.IsNullOrWhiteSpace(description))
                description = focusedObject.Index.ToString();

            DialogResult result = MessageBox.Show($"Do you want to insert row after {description}?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            T newObject = Session.InsertObjectAfter<T>(focusedObject.Index);

            // 刷新数据源
            if (view.DataSource is BindingSource bs)
                bs.ResetBindings(false);

            // 选中新插入的行
            if (view.DataSource is BindingSource bs2)
            {
                int idx = bs2.List.IndexOf(newObject);
                if (idx >= 0 && idx < view.Rows.Count)
                {
                    view.ClearSelection();
                    view.Rows[idx].Selected = true;
                    view.FirstDisplayedScrollingRowIndex = idx;
                }
            }
            view.AutoResizeColumns();
        }

        private static void DeleteRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete) return;

            if (MessageBox.Show("Delete rows?", "Confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            DataGridView view = (DataGridView)sender;

            List<DBObject> objects = new List<DBObject>();

            foreach (DataGridViewRow row in view.SelectedRows)
            {
                if (row.DataBoundItem is DBObject obj)
                    objects.Add(obj);
            }

            // 也支持单元格选择模式下的行删除
            if (objects.Count == 0)
            {
                HashSet<int> rowIndexes = new HashSet<int>();
                foreach (DataGridViewCell cell in view.SelectedCells)
                    rowIndexes.Add(cell.RowIndex);

                foreach (int idx in rowIndexes)
                {
                    if (view.Rows[idx].DataBoundItem is DBObject obj)
                        objects.Add(obj);
                }
            }

            foreach (DBObject ob in objects)
                ob?.Delete();
        }

        private static void PasteData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x16)
            {
                // 粘贴功能待实现，不拦截按键，让默认行为处理
                DataGridView view = (DataGridView)sender;
                string data = Clipboard.GetText();
                if (string.IsNullOrWhiteSpace(data)) return;

                string[] copied = data.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (copied.Length <= 1) return;

                e.Handled = true;

                // 简单粘贴：尝试逐行写入当前单元格所在行及后续行
                int startRow = view.CurrentCell?.RowIndex ?? 0;
                int startCol = view.CurrentCell?.ColumnIndex ?? 0;

                for (int i = 1; i < copied.Length; i++) // 跳过标题行
                {
                    int targetRow = startRow + i - 1;
                    if (targetRow >= view.Rows.Count) break;

                    string[] fields = copied[i].Split('\t');
                    for (int j = 0; j < fields.Length; j++)
                    {
                        int targetCol = startCol + j;
                        if (targetCol >= view.Columns.Count) break;

                        var cell = view.Rows[targetRow].Cells[targetCol];
                        if (!cell.ReadOnly)
                            cell.Value = fields[j];
                    }
                }
                view.Refresh();
            }
        }

        #region Idle Check
        private static bool AppStillIdle
        {
            get
            {
                PeekMsg msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool PeekMessage(out PeekMsg msg, IntPtr hWnd, uint messageFilterMin,
                                               uint messageFilterMax, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        private struct PeekMsg
        {
            private readonly IntPtr hWnd;
            private readonly Message msg;
            private readonly IntPtr wParam;
            private readonly IntPtr lParam;
            private readonly uint time;
            private readonly Point p;
        }
        #endregion

        private void LoadUserCache()
        {
            try
            {
                if (!File.Exists(CacheFilePath)) return;

                var cache = JsonSerializer.Deserialize<ServerUserCache>(File.ReadAllText(CacheFilePath));

                if (cache == null) return;

                WindowState = cache.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;

                if (cache.ExpandedGroups != null)
                {
                    foreach (TreeNode group in navigationTreeView.Nodes)
                    {
                        if (cache.ExpandedGroups.Contains(group.Name))
                            group.Expand();
                        else
                            group.Collapse();
                    }
                }
            }
            catch (Exception ex)
            {
                SEnvir.Log($"Failed to load UI cache: {ex}");
            }
        }

        private void SaveUserCache()
        {
            try
            {
                var expandedGroups = new List<string>();
                foreach (TreeNode group in navigationTreeView.Nodes)
                {
                    if (group.IsExpanded)
                        expandedGroups.Add(group.Name);
                }

                var cache = new ServerUserCache
                {
                    ExpandedGroups = expandedGroups,
                    Maximized = WindowState == FormWindowState.Maximized
                };

                File.WriteAllText(CacheFilePath, JsonSerializer.Serialize(cache, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
            }
            catch (Exception ex)
            {
                SEnvir.Log($"Failed to save UI cache: {ex}");
            }
        }

        private class ServerUserCache
        {
            public List<string> ExpandedGroups { get; set; } = new List<string>();
            public bool Maximized { get; set; }
        }
    }
}
