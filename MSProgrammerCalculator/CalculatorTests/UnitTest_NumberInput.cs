using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_NumberInput
    {
        [TestMethod("[1, \"(1) \"] -> [7, \"(1) \"] -> [78, \"(1) \"] -> [789, \"(1) \"]")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num7);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num8);
            Assert.AreEqual(78, calculator.Operand);
            Assert.AreEqual("( 1 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            Assert.AreEqual(789, calculator.Operand);
            Assert.AreEqual("( 1 ) ", calculator.Expression);
        }

        [TestMethod("[2, \"(1) + (2) \"] -> [7, \"(1) + \"] -> [78, \"(1) + \"] -> [789, \"(1) + \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("( 1 ) + ( 2 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num7);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("( 1 ) + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num8);
            Assert.AreEqual(78, calculator.Operand);
            Assert.AreEqual("( 1 ) + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            Assert.AreEqual(789, calculator.Operand);
            Assert.AreEqual("( 1 ) + ", calculator.Expression);
        }

        [TestMethod("[2, \"(1) × (2) \"] -> [7, \"(1) × \"] -> [78, \"(1) × \"] -> [789, \"(1) × \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("( 1 ) × ( 2 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num7);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("( 1 ) × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num8);
            Assert.AreEqual(78, calculator.Operand);
            Assert.AreEqual("( 1 ) × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            Assert.AreEqual(789, calculator.Operand);
            Assert.AreEqual("( 1 ) × ", calculator.Expression);
        }
    }
}
