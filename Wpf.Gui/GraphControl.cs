using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Wpf.Gui
{
    class GraphControl : FrameworkElement
    {
        public static readonly DependencyProperty DataProperty = 
            DependencyProperty.Register("Data", typeof(int[]), typeof(GraphControl));

        public static readonly DependencyProperty SelectedIndexProperty = 
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(GraphControl));

        public int[] Data {
            get => (int[]) GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public int SelectedIndex {
            get => GetValue(SelectedIndexProperty) as int? ?? 0;
            set => SetValue(SelectedIndexProperty, value);
        }

        protected override void OnRender(DrawingContext context) {
            context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1), new Rect(new Size(ActualWidth, ActualHeight)));

            if (Data == null || Data.Length == 0)
                return;

            var maxItem = Data.Max();

            var array = Data;

            var columnWidth = ActualWidth / (array.Length * 3 + 1);

            var height = ActualHeight / (maxItem * 1.2);

            var left = columnWidth;

            for (var i = 0; i < array.Length; i++) {
                context.DrawRectangle(SelectedIndex != i ? Brushes.DodgerBlue : Brushes.Red, new Pen(Brushes.Black, 1), new Rect(left, ActualHeight - height * array[i], columnWidth * 2, ActualHeight));

                left += columnWidth * 3;
            }
        }
    }
}
