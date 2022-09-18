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
        public BitKeypadView()
        {
            InitializeComponent();
        }

        private void BitKeypadButton_BitChanged(object sender, BitChangedEventArgs e)
        {
            var allBit = $"{bitButton60.Bit}{bitButton56.Bit}{bitButton52.Bit}{bitButton48.Bit}{bitButton44.Bit}{bitButton40.Bit}{bitButton36.Bit}{bitButton32.Bit}{bitButton28.Bit}{bitButton24.Bit}{bitButton20.Bit}{bitButton16.Bit}{bitButton12.Bit}{bitButton8.Bit}{bitButton4.Bit}{bitButton0.Bit}";
            var bitValue = Convert.ToInt64(allBit, 2);

            Console.WriteLine(bitValue.ToString());
        }
    }
}
