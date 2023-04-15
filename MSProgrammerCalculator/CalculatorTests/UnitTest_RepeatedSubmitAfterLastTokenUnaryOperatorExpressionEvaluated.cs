using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_RepeatedSubmitAfterLastTokenUnaryOperatorExpressionEvaluated
    {
        [TestMethod("[0, \"1 + negate( 1 ) = \"] -> [-1, \"0 + -1 = \"] -> [-2, \"-1 + -1 = \"] -> [-3, \"-2 + -1 = \"]")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + negate( 1 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("0 + -1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("-1 + -1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("-2 + -1 = ", calculator.Expression);
        }

        [TestMethod("[0, \"1 + 2 + negate( 3 ) = \"] -> [-3, \"0 + -3 = \"] -> [-6, \"-3 + -3 = \"] -> [-9, \"-6 + -3 = \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 + negate( 3 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("0 + -3 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-6, calculator.Operand);
            Assert.AreEqual("-3 + -3 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-9, calculator.Operand);
            Assert.AreEqual("-6 + -3 = ", calculator.Expression);
        }

        [TestMethod("[-3, \"1 + 2 × negate( 2 ) = \"] -> [-7, \"-3 + -4 = \"] -> [-11, \"-7 + -4 = \"] -> [-15, \"-11 + -4 = \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.EnqueueToken(Operators.Negate);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("1 + 2 × negate( 2 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-7, calculator.Operand);
            Assert.AreEqual("-3 + -4 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-11, calculator.Operand);
            Assert.AreEqual("-7 + -4 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-15, calculator.Operand);
            Assert.AreEqual("-11 + -4 = ", calculator.Expression);
        }

        [TestMethod("[-1, \"1 + NOT( 1 ) = \"] -> [-3, \"-1 + -2 = \"] -> [-5, \"-3 + -2 = \"] -> [-7, \"-5 + -2 = \"]")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("-1 + -2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-5, calculator.Operand);
            Assert.AreEqual("-3 + -2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-7, calculator.Operand);
            Assert.AreEqual("-5 + -2 = ", calculator.Expression);
        }

        [TestMethod("[-1, \"1 + 2 + NOT( 3 ) = \"] -> [-5, \"-1 + -4 = \"] -> [-9, \"-5 + -4 = \"] -> [-13, \"-9 + -4 = \"]")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + 2 + NOT( 3 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-5, calculator.Operand);
            Assert.AreEqual("-1 + -4 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-9, calculator.Operand);
            Assert.AreEqual("-5 + -4 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-13, calculator.Operand);
            Assert.AreEqual("-9 + -4 = ", calculator.Expression);
        }

        [TestMethod("[-5, \"1 + 2 × NOT( 2 ) = \"] -> [-11, \"-5 + -6 = \"] -> [-17, \"-11 + -6 = \"] -> [-23, \"-17 + -6 = \"]")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-5, calculator.Operand);
            Assert.AreEqual("1 + 2 × NOT( 2 ) = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-11, calculator.Operand);
            Assert.AreEqual("-5 + -6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-17, calculator.Operand);
            Assert.AreEqual("-11 + -6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-23, calculator.Operand);
            Assert.AreEqual("-17 + -6 = ", calculator.Expression);
        }
    }
}
