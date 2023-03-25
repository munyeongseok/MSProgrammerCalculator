using Calculator;
using MSProgrammerCalculator.Common;
using MSProgrammerCalculator.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static readonly DependencyProperty ExpressionProperty = DependencyProperty.Register(
            nameof(Expression),
            typeof(string),
            typeof(DisplayView),
            new PropertyMetadata(string.Empty));
        public string Expression
        {
            get => (string)GetValue(DisplayValueProperty);
            set => SetValue(ExpressionProperty, value);
        }

        public static readonly DependencyProperty DisplayValueProperty = DependencyProperty.Register(
            nameof(DisplayValue),
            typeof(long),
            typeof(DisplayView),
            new PropertyMetadata(0L));
        public long DisplayValue
        {
            get => (long)GetValue(DisplayValueProperty);
            set => SetValue(DisplayValueProperty, value);
        }

        public static readonly DependencyProperty SelectedBaseNumberProperty = DependencyProperty.Register(
            nameof(SelectedBaseNumber),
            typeof(BaseNumber),
            typeof(DisplayView),
            new PropertyMetadata(BaseNumber.Decimal));
        public BaseNumber SelectedBaseNumber
        {
            get => (BaseNumber)GetValue(SelectedBaseNumberProperty);
            set => SetValue(SelectedBaseNumberProperty, value);
        }

        public DisplayView()
        {
            InitializeComponent();
        }
    }
}
