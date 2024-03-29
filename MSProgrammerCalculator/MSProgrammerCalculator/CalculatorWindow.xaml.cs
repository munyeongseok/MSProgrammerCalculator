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

namespace MSProgrammerCalculator
{
    /// <summary>
    /// CalculatorWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            memoryPanelColumn.Width = e.NewSize.Width > 570 ? new GridLength(8, GridUnitType.Star) : new GridLength(0);
        }

        private void BitKeypadView_ValueChanged(object sender, BitKeypadValueChangedEventArgs e)
        {
            displayView.DisplayValue = e.Value;
        }
    }
}
