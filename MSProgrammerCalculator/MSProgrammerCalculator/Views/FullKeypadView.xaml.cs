using MSProgrammerCalculator.Common;
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
        public static readonly DependencyProperty TargetBaseNumberProperty = DependencyProperty.Register(
            nameof(TargetBaseNumber),
            typeof(BaseNumber),
            typeof(FullKeypadView),
            new PropertyMetadata(BaseNumber.Unknown, (s, e) =>
            {
                var self = (FullKeypadView)s;
                self.OnTargetBaseNumberChanged((BaseNumber)e.NewValue);
            }));
        public BaseNumber TargetBaseNumber
        {
            get => (BaseNumber)GetValue(TargetBaseNumberProperty);
            set => SetValue(TargetBaseNumberProperty, value);
        }
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

        private void OnTargetBaseNumberChanged(BaseNumber newValue)
        {
            switch (newValue)
            {
                case BaseNumber.Binary:
                    num2Button.IsEnabled = false;
                    num3Button.IsEnabled = false;
                    num4Button.IsEnabled = false;
                    num5Button.IsEnabled = false;
                    num6Button.IsEnabled = false;
                    num7Button.IsEnabled = false;
                    num8Button.IsEnabled = false;
                    num9Button.IsEnabled = false;
                    hexNumAButton.IsEnabled = false;
                    hexNumBButton.IsEnabled = false;
                    hexNumCButton.IsEnabled = false;
                    hexNumDButton.IsEnabled = false;
                    hexNumEButton.IsEnabled = false;
                    hexNumFButton.IsEnabled = false;
                    break;
                case BaseNumber.Octal:
                    num2Button.IsEnabled = true;
                    num3Button.IsEnabled = true;
                    num4Button.IsEnabled = true;
                    num5Button.IsEnabled = true;
                    num6Button.IsEnabled = true;
                    num7Button.IsEnabled = true;
                    num8Button.IsEnabled = false;
                    num9Button.IsEnabled = false;
                    hexNumAButton.IsEnabled = false;
                    hexNumBButton.IsEnabled = false;
                    hexNumCButton.IsEnabled = false;
                    hexNumDButton.IsEnabled = false;
                    hexNumEButton.IsEnabled = false;
                    hexNumFButton.IsEnabled = false;
                    break;
                case BaseNumber.Decimal:
                    num2Button.IsEnabled = true;
                    num3Button.IsEnabled = true;
                    num4Button.IsEnabled = true;
                    num5Button.IsEnabled = true;
                    num6Button.IsEnabled = true;
                    num7Button.IsEnabled = true;
                    num8Button.IsEnabled = true;
                    num9Button.IsEnabled = true;
                    hexNumAButton.IsEnabled = false;
                    hexNumBButton.IsEnabled = false;
                    hexNumCButton.IsEnabled = false;
                    hexNumDButton.IsEnabled = false;
                    hexNumEButton.IsEnabled = false;
                    hexNumFButton.IsEnabled = false;
                    break;
                case BaseNumber.Hexadecimal:
                    num2Button.IsEnabled = true;
                    num3Button.IsEnabled = true;
                    num4Button.IsEnabled = true;
                    num5Button.IsEnabled = true;
                    num6Button.IsEnabled = true;
                    num7Button.IsEnabled = true;
                    num8Button.IsEnabled = true;
                    num9Button.IsEnabled = true;
                    hexNumAButton.IsEnabled = true;
                    hexNumBButton.IsEnabled = true;
                    hexNumCButton.IsEnabled = true;
                    hexNumDButton.IsEnabled = true;
                    hexNumEButton.IsEnabled = true;
                    hexNumFButton.IsEnabled = true;
                    break;
            }
        }
    }
}
