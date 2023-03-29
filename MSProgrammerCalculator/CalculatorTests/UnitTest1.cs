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
    public class UnitTest1
    {
        [TestMethod("[0, \"NOT( NOT( 0 ) ) = \"]")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();
            
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("NOT( 0 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) = ", calculator.Expression);
        }

        [TestMethod("[-1, \"1 + NOT( 1 ) = \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) = ", calculator.Expression);
        }

        [TestMethod("[-11, \"1 + NOT( 5 + 6 ) = \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ( ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num6);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(11, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + 6 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-12, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-11, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) = ", calculator.Expression);
        }

        [TestMethod("[2, \"1 + negate( negate( 1 ) ) = \"]")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("", calculator.Expression);

            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("", calculator.Expression);

            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + negate( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) = ", calculator.Expression);
        }

        [TestMethod("[6, \"1 + 2 + 3 = \"]")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 = ", calculator.Expression);
        }

        [TestMethod("[0, \"0 = \"]")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 = ", calculator.Expression);
        }

        [TestMethod("[1, \"1 = \"]")]
        public void TestMethod7()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 = ", calculator.Expression);
        }

        [TestMethod("[5, \"4 + 1 = \"]")]
        public void TestMethod8()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("2 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("3 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 + 1 = ", calculator.Expression);
        }

        [TestMethod("[30, \"24 + 6 = \"]")]
        public void TestMethod9()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(18, calculator.Operand);
            Assert.AreEqual("12 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(24, calculator.Operand);
            Assert.AreEqual("18 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(30, calculator.Operand);
            Assert.AreEqual("24 + 6 = ", calculator.Expression);
        }

        [TestMethod("[6, \"( 1 + ( 2 + 3 ) ) = \"]")]
        public void TestMethod10()
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
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("6 = ", calculator.Expression);
        }

        [TestMethod("[10, \"( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = \"]")]
        public void TestMethod11()
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
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("10 + 0 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("10 + 0 = ", calculator.Expression);
        }

        [TestMethod("[-27, \"9 - 6 × 6 = \"]")]
        public void TestMethod12()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Minus);
            calculator.Evaluate();
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 - ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("9 - 6 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-27, calculator.Operand);
            Assert.AreEqual("9 - 6 × 6 = ", calculator.Expression);
        }

        [TestMethod("[2, \"1 + ( 2 ) \"] -> Clear -> [0, \"1 + \"]")]
        public void TestMethod13()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + ( 2 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Clear);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual(string.Empty, calculator.Expression);
        }
    }
}
