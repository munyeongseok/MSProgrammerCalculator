﻿using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace CalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod("Display Value: 0, Expression: \"NOT( NOT( 0 ) ) = \"")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();
            
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("NOT( 0 ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("NOT( NOT( 0 ) ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: -1, Expression: \"1 + NOT( 1 ) = \"")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + NOT( 1 ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: -11, Expression: \"1 + NOT( 5 + 6 ) = \"")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.OpenParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + ( ", calculator.NumericalExpression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Numbers.Num6);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            calculator.Evaluate();
            Assert.AreEqual(11, calculator.Operand);
            Assert.AreEqual("1 + ( 5 + 6 ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-12, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-11, calculator.Operand);
            Assert.AreEqual("1 + NOT( 5 + 6 ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 2, Expression: \"1 + negate( negate( 1 ) ) = \"")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 + negate( 1 ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + negate( negate( 1 ) ) = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 6, Expression: \"1 + 2 + 3 = \"")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 0, Expression: \"0 = \"")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 1, Expression: \"1 = \"")]
        public void TestMethod7()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 5, Expression: \"4 + 1 = \"")]
        public void TestMethod8()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 1 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("2 + 1 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("3 + 1 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 + 1 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 30, Expression: \"24 + 6 = \"")]
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
            Assert.AreEqual("1 + 2 + 3 + ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + 6 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(18, calculator.Operand);
            Assert.AreEqual("12 + 6 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(24, calculator.Operand);
            Assert.AreEqual("18 + 6 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(30, calculator.Operand);
            Assert.AreEqual("24 + 6 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 6, Expression: \"( 1 + ( 2 + 3 ) ) = \"")]
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
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("( 1 + ( 2 + 3 ) ) = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("6 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: 10, Expression: \"( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = \"")]
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
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("( 1 + 2 ) + ( 3 + 4 ) + ( 0 ) = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("10 + 0 = ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(10, calculator.Operand);
            Assert.AreEqual("10 + 0 = ", calculator.NumericalExpression);
        }

        [TestMethod("Display Value: -27, Expression: \"9 - 6 × 6 = \"")]
        public void TestMethod12()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 × ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Minus);
            calculator.Evaluate();
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 - ", calculator.NumericalExpression);

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("9 - 6 × ", calculator.NumericalExpression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-27, calculator.Operand);
            Assert.AreEqual("9 - 6 × 6 = ", calculator.NumericalExpression);
        }
    }
}