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

namespace MSProgrammerCalculator.Views
{
    /// <summary>
    /// NumericKeypadView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NumericKeypadView : UserControl
    {
        public static readonly DependencyProperty TargetBaseNumberProperty = DependencyProperty.Register(
            nameof(TargetBaseNumber),
            typeof(BaseNumber),
            typeof(NumericKeypadView),
            new PropertyMetadata(BaseNumber.Unknown, (s, e) =>
            {
                var self = (NumericKeypadView)s;
                self.OnTargetBaseNumberChanged((BaseNumber)e.NewValue);
            }));
        public BaseNumber TargetBaseNumber
        {
            get => (BaseNumber)GetValue(TargetBaseNumberProperty);
            set => SetValue(TargetBaseNumberProperty, value);
        }

        #region Click Events: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

        public static readonly RoutedEvent Click0Event = EventManager.RegisterRoutedEvent(
            nameof(Click0),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click0
        {
            add => AddHandler(Click0Event, value);
            remove => RemoveHandler(Click0Event, value);
        }

        public static readonly RoutedEvent Click1Event = EventManager.RegisterRoutedEvent(
            nameof(Click1),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click1
        {
            add => AddHandler(Click1Event, value);
            remove => RemoveHandler(Click1Event, value);
        }

        public static readonly RoutedEvent Click2Event = EventManager.RegisterRoutedEvent(
            nameof(Click2),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click2
        {
            add => AddHandler(Click2Event, value);
            remove => RemoveHandler(Click2Event, value);
        }

        public static readonly RoutedEvent Click3Event = EventManager.RegisterRoutedEvent(
            nameof(Click3),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click3
        {
            add => AddHandler(Click3Event, value);
            remove => RemoveHandler(Click3Event, value);
        }

        public static readonly RoutedEvent Click4Event = EventManager.RegisterRoutedEvent(
            nameof(Click4),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click4
        {
            add => AddHandler(Click4Event, value);
            remove => RemoveHandler(Click4Event, value);
        }

        public static readonly RoutedEvent Click5Event = EventManager.RegisterRoutedEvent(
            nameof(Click5),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click5
        {
            add => AddHandler(Click5Event, value);
            remove => RemoveHandler(Click5Event, value);
        }

        public static readonly RoutedEvent Click6Event = EventManager.RegisterRoutedEvent(
            nameof(Click6),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click6
        {
            add => AddHandler(Click6Event, value);
            remove => RemoveHandler(Click6Event, value);
        }

        public static readonly RoutedEvent Click7Event = EventManager.RegisterRoutedEvent(
            nameof(Click7),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click7
        {
            add => AddHandler(Click7Event, value);
            remove => RemoveHandler(Click7Event, value);
        }

        public static readonly RoutedEvent Click8Event = EventManager.RegisterRoutedEvent(
            nameof(Click8),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click8
        {
            add => AddHandler(Click8Event, value);
            remove => RemoveHandler(Click8Event, value);
        }

        public static readonly RoutedEvent Click9Event = EventManager.RegisterRoutedEvent(
            nameof(Click9),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler Click9
        {
            add => AddHandler(Click9Event, value);
            remove => RemoveHandler(Click9Event, value);
        }

        #endregion

        #region Click Events: A, B, C, D, E, F

        public static readonly RoutedEvent ClickAEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickA),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickA
        {
            add => AddHandler(ClickAEvent, value);
            remove => RemoveHandler(ClickAEvent, value);
        }

        public static readonly RoutedEvent ClickBEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickB),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickB
        {
            add => AddHandler(ClickBEvent, value);
            remove => RemoveHandler(ClickBEvent, value);
        }

        public static readonly RoutedEvent ClickCEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickC),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickC
        {
            add => AddHandler(ClickCEvent, value);
            remove => RemoveHandler(ClickCEvent, value);
        }

        public static readonly RoutedEvent ClickDEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickD),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickD
        {
            add => AddHandler(ClickDEvent, value);
            remove => RemoveHandler(ClickDEvent, value);
        }

        public static readonly RoutedEvent ClickEEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickE),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickE
        {
            add => AddHandler(ClickEEvent, value);
            remove => RemoveHandler(ClickEEvent, value);
        }

        public static readonly RoutedEvent ClickFEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickF),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickF
        {
            add => AddHandler(ClickFEvent, value);
            remove => RemoveHandler(ClickFEvent, value);
        }

        #endregion

        #region Click Events: <<, >>, %, ÷, ×, -, +, +/-, C, ←, (, ), ., =

        public static readonly RoutedEvent ClickLeftShiftEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickLeftShift),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickLeftShift
        {
            add => AddHandler(ClickLeftShiftEvent, value);
            remove => RemoveHandler(ClickLeftShiftEvent, value);
        }

        public static readonly RoutedEvent ClickRightShiftEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickRightShift),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickRightShift
        {
            add => AddHandler(ClickRightShiftEvent, value);
            remove => RemoveHandler(ClickRightShiftEvent, value);
        }

        public static readonly RoutedEvent ClickModuloEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickModulo),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickModulo
        {
            add => AddHandler(ClickModuloEvent, value);
            remove => RemoveHandler(ClickModuloEvent, value);
        }

        public static readonly RoutedEvent ClickDivideEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickDivide),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickDivide
        {
            add => AddHandler(ClickDivideEvent, value);
            remove => RemoveHandler(ClickDivideEvent, value);
        }

        public static readonly RoutedEvent ClickMultiplyEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickMultiply),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickMultiply
        {
            add => AddHandler(ClickMultiplyEvent, value);
            remove => RemoveHandler(ClickMultiplyEvent, value);
        }

        public static readonly RoutedEvent ClickMinusEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickMinus),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickMinus
        {
            add => AddHandler(ClickMinusEvent, value);
            remove => RemoveHandler(ClickMinusEvent, value);
        }

        public static readonly RoutedEvent ClickPlusEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickPlus),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickPlus
        {
            add => AddHandler(ClickPlusEvent, value);
            remove => RemoveHandler(ClickPlusEvent, value);
        }

        public static readonly RoutedEvent ClickNegateEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickNegate),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickNegate
        {
            add => AddHandler(ClickNegateEvent, value);
            remove => RemoveHandler(ClickNegateEvent, value);
        }

        public static readonly RoutedEvent ClickClearEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickClear),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickClear
        {
            add => AddHandler(ClickClearEvent, value);
            remove => RemoveHandler(ClickClearEvent, value);
        }

        public static readonly RoutedEvent ClickBackSpaceEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickBackSpace),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickBackSpace
        {
            add => AddHandler(ClickBackSpaceEvent, value);
            remove => RemoveHandler(ClickBackSpaceEvent, value);
        }

        public static readonly RoutedEvent ClickOpenParenthesisEvent = EventManager.RegisterRoutedEvent(
            nameof(ClickOpenParenthesisSpace),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NumericKeypadView));
        public event RoutedEventHandler ClickOpenParenthesisSpace
        {
            add => AddHandler(ClickOpenParenthesisEvent, value);
            remove => RemoveHandler(ClickOpenParenthesisEvent, value);
        }

        public static readonly RoutedEvent ClickCloseParenthesisEvent = EventManager.RegisterRoutedEvent(
           nameof(ClickCloseParenthesisSpace),
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(NumericKeypadView));
        public event RoutedEventHandler ClickCloseParenthesisSpace
        {
            add => AddHandler(ClickCloseParenthesisEvent, value);
            remove => RemoveHandler(ClickCloseParenthesisEvent, value);
        }

        public static readonly RoutedEvent ClickDecimalSeparatorEvent = EventManager.RegisterRoutedEvent(
           nameof(ClickDecimalSeparatorSpace),
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(NumericKeypadView));
        public event RoutedEventHandler ClickDecimalSeparatorSpace
        {
            add => AddHandler(ClickDecimalSeparatorEvent, value);
            remove => RemoveHandler(ClickDecimalSeparatorEvent, value);
        }

        public static readonly RoutedEvent ClickResultEvent = EventManager.RegisterRoutedEvent(
           nameof(ClickResultSpace),
           RoutingStrategy.Bubble,
           typeof(RoutedEventHandler),
           typeof(NumericKeypadView));
        public event RoutedEventHandler ClickResultSpace
        {
            add => AddHandler(ClickResultEvent, value);
            remove => RemoveHandler(ClickResultEvent, value);
        }

        #endregion

        public NumericKeypadView()
        {
            InitializeComponent();
            SubscribeMainWindowEvents();
            SubscribeNumericKeypadButtonClickEvents();
        }

        private void SubscribeMainWindowEvents()
        {
            var mainWindow = Application.Current.MainWindow;
            mainWindow.SizeChanged += MainWindow_SizeChanged;
            mainWindow.LocationChanged += MainWindow_LocationChanged;
        }

        private void SubscribeNumericKeypadButtonClickEvents()
        {
            num0Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click0Event));
            num1Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click1Event));
            num2Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click2Event));
            num3Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click3Event));
            num4Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click4Event));
            num5Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click5Event));
            num6Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click6Event));
            num7Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click7Event));
            num8Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click8Event));
            num9Button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(Click9Event));

            numAButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickAEvent));
            numBButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickBEvent));
            numCButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickCEvent));
            numDButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickDEvent));
            numEButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickEEvent));
            numFButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickFEvent));

            numLeftShiftButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickLeftShiftEvent));
            numRightShiftButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickRightShiftEvent));
            numModuloButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickModuloEvent));
            numDivideButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickDivideEvent));
            numMultiplyButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickMultiplyEvent));
            numMinusButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickMinusEvent));
            numPlusButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickPlusEvent));
            numNegateButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickNegateEvent));
            numClearButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickClearEvent));
            numBackSpaceButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickBackSpaceEvent));
            numOpenParenthesisButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickOpenParenthesisEvent));
            numCloseParenthesisButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickCloseParenthesisEvent));
            numDecimalSeparatorButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickDecimalSeparatorEvent));
            numResultButton.Click += (s, e) => RaiseEvent(new RoutedEventArgs(ClickResultEvent));
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
                    numAButton.IsEnabled = false;
                    numBButton.IsEnabled = false;
                    numCButton.IsEnabled = false;
                    numDButton.IsEnabled = false;
                    numEButton.IsEnabled = false;
                    numFButton.IsEnabled = false;
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
                    numAButton.IsEnabled = false;
                    numBButton.IsEnabled = false;
                    numCButton.IsEnabled = false;
                    numDButton.IsEnabled = false;
                    numEButton.IsEnabled = false;
                    numFButton.IsEnabled = false;
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
                    numAButton.IsEnabled = false;
                    numBButton.IsEnabled = false;
                    numCButton.IsEnabled = false;
                    numDButton.IsEnabled = false;
                    numEButton.IsEnabled = false;
                    numFButton.IsEnabled = false;
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
                    numAButton.IsEnabled = true;
                    numBButton.IsEnabled = true;
                    numCButton.IsEnabled = true;
                    numDButton.IsEnabled = true;
                    numEButton.IsEnabled = true;
                    numFButton.IsEnabled = true;
                    break;
            }
        }
    }
}
