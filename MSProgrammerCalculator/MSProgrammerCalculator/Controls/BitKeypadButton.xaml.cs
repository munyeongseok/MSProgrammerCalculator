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
        public int Bit0 { get; set; }
        public int Bit1 { get; set; }
        public int Bit2 { get; set; }
        public int Bit3 { get; set; }

        public BitKeypadButton()
        {
            InitializeComponent();
        }
    }
}
