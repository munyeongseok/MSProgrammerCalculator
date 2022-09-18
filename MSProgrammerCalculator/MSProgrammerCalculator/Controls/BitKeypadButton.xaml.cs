﻿using MSProgrammerCalculator.Common;
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

namespace MSProgrammerCalculator.Controls
{
    /// <summary>
    /// BitKeypadButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BitKeypadButton : UserControl
    {
        private static readonly DependencyProperty BitProperty = DependencyProperty.Register(
            nameof(Bit),
            typeof(string),
            typeof(BitKeypadButton),
            new PropertyMetadata("0000", (s, e) =>
            {
                var self = (BitKeypadButton)s;
                self.OnBitChanged((string)e.NewValue);
            }));
        public string Bit
        {
            get => (string)GetValue(BitProperty);
            set => SetValue(BitProperty, value);
        }

        public static readonly DependencyProperty LSBIndexProperty = DependencyProperty.Register(
            nameof(LSBIndex),
            typeof(int),
            typeof(BitKeypadButton),
            new PropertyMetadata(0));
        public int LSBIndex
        {
            get => (int)GetValue(LSBIndexProperty);
            set => SetValue(LSBIndexProperty, value);
        }

        public event BitChangedEventHandler BitChanged;

        public BitKeypadButton()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void BitToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Bit = $"{bit3.Bit}{bit2.Bit}{bit1.Bit}{bit0.Bit}";

            BitChanged?.Invoke(this, new BitChangedEventArgs(Bit));
        }

        private void OnBitChanged(string newValue)
        {
            var b3 = newValue[0] == '1' ? 1 : 0;
            var b2 = newValue[1] == '1' ? 1 : 0;
            var b1 = newValue[2] == '1' ? 1 : 0;
            var b0 = newValue[3] == '1' ? 1 : 0;
            bit3.Bit = b3;
            bit2.Bit = b2;
            bit1.Bit = b1;
            bit0.Bit = b0;
        }
    }
}
