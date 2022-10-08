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
    public enum KeypadMode
    {
        NumericKeypad,
        BitKeypad
    }

    /// <summary>
    /// KeypadControlView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class KeypadControlView : UserControl
    {
        public static readonly DependencyProperty KeypadModeProperty = DependencyProperty.Register(
            nameof(KeypadMode),
            typeof(KeypadMode),
            typeof(KeypadControlView),
            new PropertyMetadata(KeypadMode.NumericKeypad));
        public KeypadMode KeypadMode
        {
            get => (KeypadMode)GetValue(KeypadModeProperty);
            set => SetValue(KeypadModeProperty, value);
        }

        public static readonly DependencyProperty BitDataUnitProperty = DependencyProperty.Register(
            nameof(BitDataUnit),
            typeof(BitDataUnit),
            typeof(KeypadControlView),
            new PropertyMetadata(BitDataUnit.QWORD, (s, e) =>
            {
                var self = (KeypadControlView)s;
                self.bitDataUnitButton.Content = e.NewValue.ToString();
            }));
        public BitDataUnit BitDataUnit
        {
            get => (BitDataUnit)GetValue(BitDataUnitProperty);
            set => SetValue(BitDataUnitProperty, value);
        }

        public KeypadControlView()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void BitDataUnitButton_Click(object sender, RoutedEventArgs e)
        {
            BitDataUnit = (BitDataUnit)(((int)BitDataUnit + 1) % 4);
        }
    }
}
