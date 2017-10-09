using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Algorithms.Common;
using Algorithms.Sort;

namespace Wpf.Gui
{
    class GraphControl : FrameworkElement
    {
        private int[] array;

        private int maxItem;

        private int selectedIndex;

        public GraphControl() {
            array = ArrayGenerator.Generate(150, false, 1, 151);

            maxItem = array.Max();
        }

        public void Start() {
            var t = new BubbleSort<int>(ProgressAction);

            Task.Factory.StartNew(() => {
                t.Sort(array, ListSortDirection.Ascending);
            });
        }

        private void ProgressAction(int index) {
            selectedIndex = index;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(InvalidateVisual));
            Thread.Sleep(10);
        }

        protected override void OnRender(DrawingContext context) {
            context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1), new Rect(new Size(ActualWidth, ActualHeight)));

            var columnWidth = ActualWidth / (array.Length * 3 + 1);

            var height = ActualHeight / (maxItem * 1.2);

            var left = columnWidth;

            for (var i = 0; i < array.Length; i++) {
                context.DrawRectangle(i != selectedIndex ? Brushes.DodgerBlue : Brushes.Red, new Pen(Brushes.Black, 1), new Rect(left, ActualHeight - height * array[i], columnWidth * 2, ActualHeight));

                left += columnWidth * 3;
            }
        }
    }
}
