namespace WindowsInspector
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interop;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IntPtr _handle;

        public MainWindow()
        {
            InitializeComponent();

            var helper = new WindowInteropHelper(this);
            _handle = helper.Handle == IntPtr.Zero ? helper.EnsureHandle() : helper.Handle;
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            using (Dispatcher.DisableProcessing())
            {
                Core.Fill(treeView.Items);
            }
        }
    }
}
