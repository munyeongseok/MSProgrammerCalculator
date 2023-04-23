using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_OperandOfBinaryOperatorExpression
    {
        #region Arithmetic Operators

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 + \"] -> [6, \"1 + 2 + 3 + \"]")]
        public void TestMethod_Plus1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 + \"] -> [3, \"1 + 2 + 3 × \"]")]
        public void TestMethod_Plus2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 × ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 - \"] -> [0, \"1 + 2 - 3 - \"]")]
        public void TestMethod_Minus1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 - ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Minus);
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 - ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 - \"] -> [3, \"1 + 2 - 3 × \"]")]
        public void TestMethod_Minus2()
        {
            var calculator = new ProgrammerCalculator();

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
        }

        [TestMethod("[1, \"1 + \"] -> [2, \"1 + 2 × \"] -> [6, \"1 + 2 × 3 × \"]")]
        public void TestMethod_Multiply1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 × 3 × ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [2, \"1 + 2 × \"] -> [7, \"1 + 2 × 3 + \"]")]
        public void TestMethod_Multiply2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("1 + 2 × 3 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 × \"] -> [6, \"2 × 3 + \"] -> [7, \"2 × 3 + 1 + \"]")]
        public void TestMethod_Multiply3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("2 × 3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("2 × 3 + 1 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 × \"] -> [6, \"2 × 3 + \"] -> [1, \"2 × 3 + 1 × \"]")]
        public void TestMethod_Multiply4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("2 × 3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Multiply);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("2 × 3 + 1 × ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [9, \"1 + 9 ÷ \"] -> [4, \"1 + 9 ÷ 2 ÷ \"]")]
        public void TestMethod_Divide1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("1 + 9 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 9 ÷ 2 ÷ ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [9, \"1 + 9 ÷ \"] -> [5, \"1 + 9 ÷ 2 + \"]")]
        public void TestMethod_Divide2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("1 + 9 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + 9 ÷ 2 + ", calculator.Expression);
        }

        [TestMethod("[9, \"9 ÷ \"] -> [4, \"9 ÷ 2 + \"] -> [5, \"9 ÷ 2 + 1 + \"]")]
        public void TestMethod_Divide3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("9 ÷ 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("9 ÷ 2 + 1 + ", calculator.Expression);
        }

        [TestMethod("[9, \"9 ÷ \"] -> [4, \"9 ÷ 2 + \"] -> [1, \"9 ÷ 2 + 1 ÷ \"]")]
        public void TestMethod_Divide4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num9);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(9, calculator.Operand);
            Assert.AreEqual("9 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("9 ÷ 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Divide);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("9 ÷ 2 + 1 ÷ ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [5, \"1 + 5 % \"] -> [2, \"1 + 5 % 3 % \"]")]
        public void TestMethod_Modulo1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + 5 % ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 5 % 3 % ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [5, \"1 + 5 % \"] -> [3, \"1 + 5 % 3 + \"]")]
        public void TestMethod_Modulo2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + 5 % ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 5 % 3 + ", calculator.Expression);
        }

        [TestMethod("[5, \"5 % \"] -> [2, \"5 % 3 + \"] -> [3, \"5 % 3 + 1 + \"]")]
        public void TestMethod_Modulo3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("5 % ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("5 % 3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("5 % 3 + 1 + ", calculator.Expression);
        }

        [TestMethod("[5, \"5 % \"] -> [2, \"5 % 3 + \"] -> [1, \"5 % 3 + 1 % \"]")]
        public void TestMethod_Modulo4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("5 % ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("5 % 3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Modulo);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("5 % 3 + 1 % ", calculator.Expression);
        }

        #endregion

        #region Bitwise Operators

        [TestMethod("[1, \"1 + \"] -> [1, \"1 + 1 Lsh \"] -> [4, \"1 + 1 Lsh 2 Lsh \"]")]
        public void TestMethod_LeftShift1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + 1 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 1 Lsh 2 Lsh ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [1, \"1 + 1 Lsh \"] -> [5, \"1 + 1 Lsh 2 + \"]")]
        public void TestMethod_LeftShift2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + 1 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 + 1 Lsh 2 + ", calculator.Expression);
        }

        [TestMethod("[1, \"1 Lsh \"] -> [4, \"1 Lsh 2 + \"] -> [5, \"1 Lsh 2 + 1 + \"]")]
        public void TestMethod_LeftShift3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 Lsh 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 Lsh 2 + 1 + ", calculator.Expression);
        }

        [TestMethod("[1, \"1 Lsh \"] -> [4, \"1 Lsh 2 + \"] -> [5, \"1 Lsh 2 + 1 Lsh \"]")]
        public void TestMethod_LeftShift4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 Lsh 2 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.LeftShift);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("1 Lsh 2 + 1 Lsh ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [4, \"1 + 4 Rsh \"] -> [2, \"1 + 4 Rsh 1 Rsh \"]")]
        public void TestMethod_RightShift1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 4 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 4 Rsh 1 Rsh ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [4, \"1 + 4 Rsh \"] -> [3, \"1 + 4 Rsh 1 + \"]")]
        public void TestMethod_RightShift2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 4 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 4 Rsh 1 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 Rsh \"] -> [2, \"4 Rsh 1 + \"] -> [3, \"4 Rsh 1 + 1 + \"]")]
        public void TestMethod_RightShift3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("4 Rsh 1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("4 Rsh 1 + 1 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 Rsh \"] -> [2, \"4 Rsh 1 + \"] -> [1, \"4 Rsh 1 + 1 Rsh \"]")]
        public void TestMethod_RightShift4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("4 Rsh 1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.RightShift);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("4 Rsh 1 + 1 Rsh ", calculator.Expression);
        }

        [TestMethod("[3, \"3 + \"] -> [7, \"3 + 4 AND \"] -> [5, \"3 + 4 AND 5 AND \"]")]
        public void TestMethod_BitwiseAND1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("3 + 4 AND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("3 + 4 AND 5 AND ", calculator.Expression);
        }

        [TestMethod("[3, \"3 + \"] -> [7, \"3 + 4 AND \"] -> [5, \"3 + 4 AND 5 + \"]")]
        public void TestMethod_BitwiseAND2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num7);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("3 + 4 AND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("3 + 4 AND 5 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 AND \"] -> [5, \"4 AND 5 + \"] -> [6, \"4 AND 5 + 1 + \"]")]
        public void TestMethod_BitwiseAND3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 AND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 AND 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("4 AND 5 + 1 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 AND \"] -> [5, \"4 AND 5 + \"] -> [4, \"4 AND 5 + 1 AND \"]")]
        public void TestMethod_BitwiseAND4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 AND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 AND 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseAND);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 AND 5 + 1 AND ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 OR \"] -> [7, \"1 + 2 OR 4 OR \"]")]
        public void TestMethod_BitwiseOR1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 OR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("1 + 2 OR 4 OR ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 OR \"] -> [4, \"1 + 2 OR 4 + \"]")]
        public void TestMethod_BitwiseOR2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 OR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 2 OR 4 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 OR \"] -> [4, \"2 OR 4 + \"] -> [5, \"2 OR 4 + 1 + \"]")]
        public void TestMethod_BitwiseOR3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 OR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 OR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("2 OR 4 + 1 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 OR \"] -> [4, \"2 OR 4 + \"] -> [7, \"2 OR 4 + 1 OR \"]")]
        public void TestMethod_BitwiseOR4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 OR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 OR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseOR);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("2 OR 4 + 1 OR ", calculator.Expression);
        }

        [TestMethod("[3, \"3 + \"] -> [7, \"3 + 4 NAND \"] -> [-6, \"3 + 4 NAND 5 NAND \"]")]
        public void TestMethod_BitwiseNAND1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("3 + 4 NAND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(-6, calculator.Operand);
            Assert.AreEqual("3 + 4 NAND 5 NAND ", calculator.Expression);
        }

        [TestMethod("[3, \"3 + \"] -> [7, \"3 + 4 NAND \"] -> [5, \"3 + 4 NAND 5 + \"]")]
        public void TestMethod_BitwiseNAND2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("3 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("3 + 4 NAND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("3 + 4 NAND 5 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 NAND \"] -> [5, \"4 NAND 5 + \"] -> [6, \"4 NAND 5 + 1 + \"]")]
        public void TestMethod_BitwiseNAND3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 NAND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 NAND 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("4 NAND 5 + 1 + ", calculator.Expression);
        }

        [TestMethod("[4, \"4 NAND \"] -> [5, \"4 NAND 5 + \"] -> [-5, \"4 NAND 5 + 1 NAND \"]")]
        public void TestMethod_BitwiseNAND4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("4 NAND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num5);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("4 NAND 5 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            Assert.AreEqual(-5, calculator.Operand);
            Assert.AreEqual("4 NAND 5 + 1 NAND ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 NOR \"] -> [-8, \"1 + 2 NOR 4 NOR \"]")]
        public void TestMethod_BitwiseNOR1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(-8, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR 4 NOR ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 NOR \"] -> [4, \"1 + 2 NOR 4 + \"]")]
        public void TestMethod_BitwiseNOR2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR 4 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 NOR \"] -> [4, \"2 NOR 4 + \"] -> [5, \"2 NOR 4 + 1 + \"]")]
        public void TestMethod_BitwiseNOR3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 NOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 NOR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("2 NOR 4 + 1 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 NOR \"] -> [4, \"2 NOR 4 + \"] -> [-8, \"2 NOR 4 + 1 NOR \"]")]
        public void TestMethod_BitwiseNOR4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 NOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 NOR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            Assert.AreEqual(-8, calculator.Operand);
            Assert.AreEqual("2 NOR 4 + 1 NOR ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 XOR \"] -> [7, \"1 + 2 XOR 4 XOR \"]")]
        public void TestMethod_BitwiseXOR1()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR 4 XOR ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + \"] -> [3, \"1 + 2 XOR \"] -> [4, \"1 + 2 XOR 4 + \"]")]
        public void TestMethod_BitwiseXOR2()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR 4 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 XOR \"] -> [4, \"2 XOR 4 + \"] -> [5, \"2 XOR 4 + 1 + \"]")]
        public void TestMethod_BitwiseXOR3()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 XOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 XOR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(5, calculator.Operand);
            Assert.AreEqual("2 XOR 4 + 1 + ", calculator.Expression);
        }

        [TestMethod("[2, \"2 XOR \"] -> [4, \"2 XOR 4 + \"] -> [7, \"2 XOR 4 + 1 XOR \"]")]
        public void TestMethod_BitwiseXOR4()
        {
            var calculator = new ProgrammerCalculator();

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("2 XOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num4);
            calculator.EnqueueToken(Operators.Plus);
            Assert.AreEqual(4, calculator.Operand);
            Assert.AreEqual("2 XOR 4 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            Assert.AreEqual(7, calculator.Operand);
            Assert.AreEqual("2 XOR 4 + 1 XOR ", calculator.Expression);
        }

        #endregion
    }
}
