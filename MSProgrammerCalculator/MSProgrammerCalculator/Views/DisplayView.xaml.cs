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
    /// DisplayView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DisplayView : UserControl
    {
        public static readonly DependencyProperty DisplayValueProperty = DependencyProperty.Register(
            nameof(DisplayValue),
            typeof(long),
            typeof(DisplayView),
            new PropertyMetadata(0L, (s, e) =>
            {
                var self = (DisplayView)s;
                self.OnDisplayValueChanged((long)e.NewValue);
            }));
        public long DisplayValue
        {
            get => (long)GetValue(DisplayValueProperty);
            set => SetValue(DisplayValueProperty, value);
        }

        public DisplayView()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void OnDisplayValueChanged(long newValue)
        {
            displayValueTextBlock.Text = newValue.ToString("N0");
        }
    }
}
