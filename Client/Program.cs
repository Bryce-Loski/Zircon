using Client.Controls;
using Client.Envir;
using Client.Rendering;
using Client.Scenes;
using Library;
using Sentry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Client
{
    /// <summary>
    /// 客户端程序入口类
    /// 负责应用程序的初始化、资源加载和主循环启动
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 应用程序主入口点
        /// 1. 加载配置文件
        /// 2. 可选地初始化 Sentry 错误追踪
        /// 3. 初始化游戏引擎
        /// 4. 退出时保存配置
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 通过反射加载程序集中所有标记了 ConfigPath 特性的配置类，从 INI 文件读取配置
            ConfigReader.Load(Assembly.GetAssembly(typeof(Config)));

            // 如果启用了 Sentry 错误追踪服务，则在 Sentry SDK 初始化作用域内启动
            if (Config.SentryEnabled && !string.IsNullOrEmpty(Config.SentryDSN))
            {
                using (SentrySdk.Init(Config.SentryDSN))
                    Init(args);
            }
            else
            {
                Init(args);
            }

            // 将运行时修改的配置回写到 INI 文件
            ConfigReader.Save(typeof(Config).Assembly);
        }

        /// <summary>
        /// 游戏引擎初始化流程
        /// 按顺序执行：UI初始化 -> 图库加载 -> 环境初始化 -> 渲染管线启动 -> 主循环
        /// </summary>
        static void Init(string[] args)
        {
            // 初始化 WinForms 应用程序基础设置
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            // 遍历 LibraryFile 枚举中定义的所有图库路径，加载存在的 .Zl 图库文件到内存
            // 每个 MirLibrary 实例代表一个图库（包含多个精灵图像）
            foreach (KeyValuePair<LibraryFile, string> pair in Libraries.LibraryList)
            {
                if (!File.Exists(@".\" + pair.Value)) continue;

                CEnvir.LibraryList[pair.Key] = new MirLibrary(@".\" + pair.Value);
            }

            // 初始化客户端环境（命令行参数处理、用户数据目录创建等）
            CEnvir.Init(args);

            // 创建主窗口（基于 SharpDX 的 RenderForm，支持 DirectX 渲染）
            CEnvir.Target = new TargetForm();
            // 规范化渲染管线标识符，确保使用可用的管线（DX9 或 DX11）
            string requestedPipelineId = RenderingPipelineManager.NormalizePipelineId(Config.RenderingPipeline);
            if (!string.Equals(Config.RenderingPipeline, requestedPipelineId, StringComparison.OrdinalIgnoreCase))
                Config.RenderingPipeline = requestedPipelineId;

            // 初始化渲染管线，支持自动回退（如 DX11 不可用则回退到 DX9）
            string activePipelineId = RenderingPipelineManager.InitializeWithFallback(requestedPipelineId, new RenderingPipelineContext(CEnvir.Target));
            if (!string.Equals(Config.RenderingPipeline, activePipelineId, StringComparison.OrdinalIgnoreCase))
                Config.RenderingPipeline = activePipelineId;
            // 初始化音效管理器
            DXSoundManager.Create();

            // 设置初始场景为登录场景
            DXControl.ActiveScene = new LoginScene(Config.GameSize);

            // 启动游戏主循环（消息泵 + 更新 + 渲染）
            RenderingPipelineManager.RunMessageLoop(CEnvir.Target, CEnvir.GameLoop);

            // 退出清理：保存用户数据、卸载资源、关闭渲染管线和音效系统
            CEnvir.Session?.Save(true);
            CEnvir.Unload();
            RenderingPipelineManager.Shutdown();
            DXSoundManager.Unload();
        }
    }
}
