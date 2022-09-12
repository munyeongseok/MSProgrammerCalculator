using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSProgrammerCalculator.Views
{
    /// <summary>
    /// FullKeypadView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FullKeypadView : UserControl
    {
        public FullKeypadView()
        {
            InitializeComponent();

            var mainWindow = Application.Current.MainWindow;
            mainWindow.SizeChanged += MainWindow_SizeChanged;
            mainWindow.LocationChanged += MainWindow_LocationChanged;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bitwiseButton.IsChecked = false;
            bitShiftButton.IsChecked = false;
        }

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {
            if (bitwiseButtonPopup.IsOpen)
            {
                var offset = bitwiseButtonPopup.HorizontalOffset;
                bitwiseButtonPopup.HorizontalOffset = offset + 1;
                bitwiseButtonPopup.HorizontalOffset = offset;
            }

            if (bitShiftButtonPopup.IsOpen)
            {
                var offset = bitShiftButtonPopup.HorizontalOffset;
                bitShiftButtonPopup.HorizontalOffset = offset + 1;
                bitShiftButtonPopup.HorizontalOffset = offset;
            }
        }
    }
}
