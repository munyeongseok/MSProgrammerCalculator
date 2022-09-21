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
    /// BitKeypadView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BitKeypadView : UserControl
    {
        public static readonly DependencyProperty BitDataUnitProperty = DependencyProperty.Register(
            nameof(BitDataUnit),
            typeof(BitDataUnit),
            typeof(BitKeypadView),
            new PropertyMetadata(BitDataUnit.QWORD, (s, e) =>
            {
                var self = (BitKeypadView)s;
                self.OnBitDataUnitChanged((BitDataUnit)e.NewValue);
            }));
        public BitDataUnit BitDataUnit
        {
            get => (BitDataUnit)GetValue(BitDataUnitProperty);
            set => SetValue(BitDataUnitProperty, value);
        }

        public event BitKeypadValueChangedEventHandler ValueChanged;

        public BitKeypadView()
        {
            InitializeComponent();
        }

        private void BitKeypadButton_BitChanged(object sender, BitChangedEventArgs e)
        {
            var allBit = $"{bitButton60.Bit}{bitButton56.Bit}{bitButton52.Bit}{bitButton48.Bit}{bitButton44.Bit}{bitButton40.Bit}{bitButton36.Bit}{bitButton32.Bit}{bitButton28.Bit}{bitButton24.Bit}{bitButton20.Bit}{bitButton16.Bit}{bitButton12.Bit}{bitButton8.Bit}{bitButton4.Bit}{bitButton0.Bit}";
            var bitValue = Convert.ToInt64(allBit, 2);
            ValueChanged?.Invoke(this, new BitKeypadValueChangedEventArgs(bitValue));
        }

        private void OnBitDataUnitChanged(BitDataUnit newValue)
        {
            switch (newValue)
            {
                case BitDataUnit.QWORD:
                    bitButton60.IsEnabled = true;
                    bitButton56.IsEnabled = true;
                    bitButton52.IsEnabled = true;
                    bitButton48.IsEnabled = true;
                    bitButton44.IsEnabled = true;
                    bitButton40.IsEnabled = true;
                    bitButton36.IsEnabled = true;
                    bitButton32.IsEnabled = true;
                    bitButton28.IsEnabled = true;
                    bitButton24.IsEnabled = true;
                    bitButton20.IsEnabled = true;
                    bitButton16.IsEnabled = true;
                    bitButton12.IsEnabled = true;
                    bitButton8.IsEnabled = true;
                    break;
                case BitDataUnit.DWORD:
                    bitButton60.IsEnabled = false; bitButton60.Bit = "0000";
                    bitButton56.IsEnabled = false; bitButton56.Bit = "0000";
                    bitButton52.IsEnabled = false; bitButton52.Bit = "0000";
                    bitButton48.IsEnabled = false; bitButton48.Bit = "0000";
                    bitButton44.IsEnabled = false; bitButton44.Bit = "0000";
                    bitButton40.IsEnabled = false; bitButton40.Bit = "0000";
                    bitButton36.IsEnabled = false; bitButton36.Bit = "0000";
                    bitButton32.IsEnabled = false; bitButton32.Bit = "0000";
                    break;
                case BitDataUnit.WORD:
                    bitButton28.IsEnabled = false; bitButton28.Bit = "0000";
                    bitButton24.IsEnabled = false; bitButton24.Bit = "0000";
                    bitButton20.IsEnabled = false; bitButton20.Bit = "0000";
                    bitButton16.IsEnabled = false; bitButton16.Bit = "0000";
                    break;
                case BitDataUnit.Byte:
                    bitButton12.IsEnabled = false; bitButton12.Bit = "0000";
                    bitButton8.IsEnabled = false; bitButton8.Bit = "0000";
                    break;
            }
        }
    }
}
