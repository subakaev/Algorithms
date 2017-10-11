using System.ComponentModel;
using Wpf.Utils;

namespace Wpf.Gui.Data {
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum SortAlgorithmType
    {
        [Description("�������")]
        Bogo,

        [Description("������ �������")]
        BruteForce,

        [Description("�������")]
        Bubble,

        [Description("�������+�������")]
        BubbleSelection,

        [Description("�������")]
        Selection,

        [Description("�������")]
        Pancake,

        [Description("����������")]
        Stooge
    }
}