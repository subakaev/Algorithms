using System;
using System.Windows;

namespace Wpf.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            GraphControl.Start();
        }
    }

    
}
