using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_EnqueueOperatorAfterSubmit
    {
        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 + \"]")]
        public void TestMethod1()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 + ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 - \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 - ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 × \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 × ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 ÷ \"]")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 ÷ ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 % \"]")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 % ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 Lsh \"]")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 Lsh ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 Rsh \"]")]
        public void TestMethod7()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 Rsh ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"( \"]")]
        public void TestMethod8()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.OpenParenthesis);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("( ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"\"]")]
        public void TestMethod9()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.CloseParenthesis);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [-3, \"negate(3) \"]")]
        public void TestMethod10()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.Negate);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("negate( 3 ) ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 AND \"]")]
        public void TestMethod11()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 AND ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 OR \"]")]
        public void TestMethod12()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 OR ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [-4, \"NOT(3) \"]")]
        public void TestMethod13()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            Assert.AreEqual(-4, calculator.Operand);
            Assert.AreEqual("NOT( 3 ) ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 NAND \"]")]
        public void TestMethod14()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 NAND ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 NOR \"]")]
        public void TestMethod15()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 NOR ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 = \"] -> [3, \"3 XOR \"]")]
        public void TestMethod16()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 XOR ", calculator.Expression);
        }
    }
}
