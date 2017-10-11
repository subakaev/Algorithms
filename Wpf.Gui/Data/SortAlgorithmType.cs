using System.ComponentModel;
using Wpf.Utils;

namespace Wpf.Gui.Data {
    [TypeConverter(typeof(EnumTypeConverter))]
    public enum SortAlgorithmType
    {
        [Description("Наивная")]
        Bogo,

        [Description("Полный перебор")]
        BruteForce,

        [Description("Пузырек")]
        Bubble,

        [Description("Пузырек+Выбором")]
        BubbleSelection,

        [Description("Выбором")]
        Selection,

        [Description("Блинная")]
        Pancake,

        [Description("Блуждающая")]
        Stooge
    }
}