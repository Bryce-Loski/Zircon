using System;
using System.Windows.Forms;

namespace Server
{
    /// <summary>
    /// ComboBox 扩展方法，替代 DevExpress 的 Items.AddEnum&lt;T&gt;() 功能
    /// </summary>
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// 将枚举类型的所有值添加到 ComboBox 的 Items 中
        /// 替代 DevExpress ImageComboBoxEdit.Items.AddEnum&lt;T&gt;()
        /// 用法: comboBox.Items.AddEnumValues&lt;MyEnum&gt;();
        /// </summary>
        public static void AddEnumValues<T>(this ComboBox.ObjectCollection items) where T : struct, Enum
        {
            items.AddRange(Enum.GetValues(typeof(T)));
        }

        /// <summary>
        /// 将枚举类型的所有值添加到 DataGridViewComboBoxCell/Column 的 Items 中
        /// 用法: comboBoxColumn.Items.AddEnumValues&lt;MyEnum&gt;();
        /// 用法: comboBoxCell.Items.AddEnumValues&lt;MyEnum&gt;();
        /// </summary>
        public static void AddEnumValues<T>(this DataGridViewComboBoxCell.ObjectCollection items) where T : struct, Enum
        {
            items.AddRange(Enum.GetValues(typeof(T)));
        }
    }
}
