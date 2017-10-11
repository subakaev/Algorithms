using System;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace Wpf.Gui
{
    class TempBehavior : Behavior<MainWindow>
    {
        private MainWindowViewModel ViewModel => (MainWindowViewModel) AssociatedObject.DataContext;

        protected override void OnAttached() {
            ViewModel.GraphicsChanged += OnGraphicsChanged;
        }

        private void OnGraphicsChanged(object sender, EventArgs e) {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => AssociatedObject.GraphControl.InvalidateVisual()));
        }

        protected override void OnDetaching() {
            ViewModel.GraphicsChanged -= OnGraphicsChanged;
        }
    }
}
