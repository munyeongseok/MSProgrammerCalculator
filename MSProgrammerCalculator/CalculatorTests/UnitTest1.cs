using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod("Display Value: 0, Expression: \"NOT( NOT( 0 ) ) \"")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();
            
            calculator.TryEnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("NOT( 0 ) ", calculator.NumericalExpression);

            calculator.TryEnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) ", calculator.NumericalExpression);

            calculator.TryEnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: -2, Expression: \"1 + NOT( 1 ) \"")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.InsertNumber(Numbers.Num1);
            calculator.TryEnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.TryEnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) ", calculator.NumericalExpression);

            calculator.TryEnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: -12, Expression: \"1 + NOT ( 5 + 6 ) \"")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.InsertNumber(Numbers.Num1);
            calculator.TryEnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.TryEnqueueToken(Operators.OpenParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ( ", calculator.NumericalExpression);

            calculator.InsertNumber(Numbers.Num5);
            calculator.TryEnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + ", calculator.NumericalExpression);

            calculator.InsertNumber(Numbers.Num6);
            calculator.TryEnqueueToken(Operators.CloseParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(11, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + 6 ) ", calculator.NumericalExpression);

            calculator.SubmitInput();
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + 6 ) = ", calculator.NumericalExpression);
        }
    }
}
