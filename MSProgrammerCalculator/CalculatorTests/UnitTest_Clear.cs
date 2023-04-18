using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_Clear
    {
        [TestMethod("[2, \"1 + ( 2 ) \"] -> Clear -> [0, \"1 + \"]")]
        public void TestMethod1()
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

        [TestMethod("[0, \"0 + \"] -> Clear -> [0, \"0 - \"] -> Clear -> [0, \"0 × \"] -> Clear -> [0, \"0 ÷ \"] -> Clear -> [0, \"0 % \"]")]
        public void TestMethod2()
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
    }
}
