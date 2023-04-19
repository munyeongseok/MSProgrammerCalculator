using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_RepeatedSubmit
    {
        [TestMethod("[30, \"24 + 6 = \"]")]
        public void TestMethod1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(18, calculator.Operand);
            Assert.AreEqual("12 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(24, calculator.Operand);
            Assert.AreEqual("18 + 6 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(30, calculator.Operand);
            Assert.AreEqual("24 + 6 = ", calculator.Expression);
        }

        [TestMethod("[5, \"4 + 1 = \"]")]
        public void TestMethod2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("2 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("3 + 1 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 + 1 = ", calculator.Expression);
        }

        [TestMethod("[5, \"-3 - 2 = \"]")]
        public void TestMethod3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Minus);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-1, calculator.Operand);
            Assert.AreEqual("1 - 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("-1 - 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(-5, calculator.Operand);
            Assert.AreEqual("-3 - 2 = ", calculator.Expression);
        }

        [TestMethod("[8, \"4 × 2 = \"]")]
        public void TestMethod4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 × 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 × 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(8, calculator.Operand);
            Assert.AreEqual("4 × 2 = ", calculator.Expression);
        }

        [TestMethod("[0, \"0 ÷ 2 = \"]")]
        public void TestMethod5()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Divide);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 ÷ 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 ÷ 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("0 ÷ 2 = ", calculator.Expression);
        }

        [TestMethod("[1, \"1 % 2 = \"]")]
        public void TestMethod6()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Modulo);
            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 % 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 % 2 = ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 % 2 = ", calculator.Expression);
        }
    }
}
