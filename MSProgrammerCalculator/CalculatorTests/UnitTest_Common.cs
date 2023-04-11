using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_Common
    {
        [TestMethod("[0, \"NOT( NOT( 0 ) ) = \"]")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();
            
            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("NOT( 0 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) = ", calculator.Expression);
        }

        [TestMethod("[-1, \"1 + NOT( 1 ) = \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) = ", calculator.Expression);
        }

        [TestMethod("[-11, \"1 + NOT( 5 + 6 ) = \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ( ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num6);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(11, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + 6 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-12, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-11, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) = ", calculator.Expression);
        }

        [TestMethod("[2, \"1 + negate( negate( 1 ) ) = \"]")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("", calculator.Expression);

            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("", calculator.Expression);

            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + negate( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) = ", calculator.Expression);
        }

        [TestMethod("[6, \"1 + 2 + 3 = \"]")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 = ", calculator.Expression);
        }

        [TestMethod("[0, \"0 = \"]")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 = ", calculator.Expression);
        }

        [TestMethod("[1, \"1 = \"]")]
        public void TestMethod7()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 = ", calculator.Expression);
        }

        [TestMethod("[6, \"( 1 + ( 2 + 3 ) ) = \"]")]
        public void TestMethod8()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) = ", calculator.Expression);
        }

        [TestMethod("[10, \"( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = \"]")]
        public void TestMethod9()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = ", calculator.Expression);
        }

        [TestMethod("[-27, \"9 - 6 × 6 = \"]")]
        public void TestMethod10()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 - ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("9 - 6 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-27, calculator.Operand);
            Assert.AreEqual("9 - 6 × 6 = ", calculator.Expression);
        }

        [TestMethod("[2, \"1 + ( 2 ) \"] -> Clear -> [0, \"1 + \"]")]
        public void TestMethod11()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + ( 2 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }

        [TestMethod("[-2, \"NOT( NOT( NOT( NOT( NOT( 1 ) ) ) ) ) \"")]
        public void TestMethod12()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("NOT( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 1 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("NOT( NOT( NOT( 1 ) ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("NOT( NOT( NOT( NOT( 1 ) ) ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("NOT( NOT( NOT( NOT( NOT( 1 ) ) ) ) ) ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [1, \"1 - \"] -> [1, \"1 × \"] -> [1, \"1 ÷ \"] -> [1, \"1 % \"]")]
        public void TestMethod13()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 - ", calculator.Expression);

            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 % ", calculator.Expression);
        }

        [TestMethod("[0, \"0 + \"] -> Clear -> [0, \"0 - \"] -> Clear -> [0, \"0 × \"] -> Clear -> [0, \"0 ÷ \"] -> Clear -> [0, \"0 % \"]")]
        public void TestMethod14()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 - ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 % ", calculator.Expression);
        }

        [TestMethod("[2, \"1 + 2 - 3 × 4 ÷ 5 % \"]")]
        public void TestMethod15()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 - ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 × 4 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 × 4 ÷ 5 % ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 × 4 ÷ 5 % 2 = ", calculator.Expression);
        }

        [TestMethod("[0, \"1 × ( \"]")]
        public void TestMethod16()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 × ( ", calculator.Expression);
        }

        [TestMethod("[-2, \"NOT( 1 ) × ( \"]")]
        public void TestMethod17()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("NOT( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("NOT( 1 ) × ( ", calculator.Expression);
        }

        [TestMethod("[-2, \"1 + NOT( 1 ) × ( \"]")]
        public void TestMethod18()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) × ( ", calculator.Expression);
        }

        [TestMethod("[1, \"( 1 ) × ( \"]")]
        public void TestMethod19()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("( 1 ) × ( ", calculator.Expression);
        }

        [TestMethod("[-1, \"1 + negate( 1 ) \"] -> [-1, \"1 + ( \"]")]
        public void TestMethod20()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + negate( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + ( ", calculator.Expression);
        }
    }
}
