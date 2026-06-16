using System.Drawing;
using System.Windows.Forms;

namespace PluginCore.Helpers
{
    /// <summary>
    /// ToolStrip 辅助方法，替代 DevExpress RibbonHelper
    /// </summary>
    public static class RibbonHelper
    {
        /// <summary>
        /// 向 ToolStrip 添加分隔组（通过分隔符 + 标签实现）
        /// </summary>
        public static ToolStripLabel AddGroup(IPluginStart start, ToolStrip toolStrip, string title)
        {
            toolStrip.Items.Add(new ToolStripSeparator());
            var label = new ToolStripLabel(title)
            {
                Name = $"{start.Name}Group",
                Font = new Font(toolStrip.Font, FontStyle.Bold)
            };
            toolStrip.Items.Add(label);
            return label;
        }

        /// <summary>
        /// 向 ToolStrip 添加按钮
        /// </summary>
        public static ToolStripButton AddButton(IPluginStart start, ToolStrip toolStrip, string caption, Image icon, System.EventHandler clickHandler)
        {
            var button = new ToolStripButton(caption)
            {
                Name = $"{start.Name}{caption.Replace(" ", "")}",
                Image = icon,
                DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            };
            button.Click += clickHandler;
            toolStrip.Items.Add(button);
            return button;
        }
    }
}
