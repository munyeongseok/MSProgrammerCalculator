using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests
{
    /// <summary>
    /// [Display Operand, Expression]
    /// </summary>
    [TestClass]
    public class UnitTest_RepeatedSameOperatorAfterPlus
    {
        [TestMethod("[12, \"1 + 2 + 3 + 6 = \"]")]
        public void TestMethod1()
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

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(12, calculator.Operand);
            Assert.AreEqual("1 + 2 + 3 + 6 = ", calculator.Expression);
        }

        [TestMethod("[0, \"1 + 2 - 3 - 0 = \"]")]
        public void TestMethod2()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Minus);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 - ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Minus);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 - ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 - 3 - 0 = ", calculator.Expression);
        }

        [TestMethod("[37, \"1 + 2 × 3 × 6 = \"]")]
        public void TestMethod3()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 × ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Multiply);
            calculator.Evaluate();
            Assert.AreEqual(6, calculator.Operand);
            Assert.AreEqual("1 + 2 × 3 × ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(37, calculator.Operand);
            Assert.AreEqual("1 + 2 × 3 × 6 = ", calculator.Expression);
        }

        [TestMethod("[\"정의되지 않은 결과입니다.\", \"1 + 2 ÷ 3 ÷ \"]")]
        public void TestMethod4()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Divide);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Divide);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 ÷ 3 ÷ ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual("정의되지 않은 결과입니다.", calculator.Operand);
            Assert.AreEqual("1 + 2 ÷ 3 ÷ ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + 2 % 3 % 2 = \"]")]
        public void TestMethod5()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Modulo);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 % ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Modulo);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 % 3 % ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + 2 % 3 % 2 = ", calculator.Expression);
        }

        [TestMethod("[1,048,577, \"1 + 2 Lsh 3 Lsh 16 = \"]")]
        public void TestMethod6()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.LeftShift);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.LeftShift);
            calculator.Evaluate();
            Assert.AreEqual(16, calculator.Operand);
            Assert.AreEqual("1 + 2 Lsh 3 Lsh ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(1048577, calculator.Operand);
            Assert.AreEqual("1 + 2 Lsh 3 Lsh 16 = ", calculator.Expression);
        }

        [TestMethod("[1, \"1 + 2 Rsh 3 Rsh 0 = \"]")]
        public void TestMethod7()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.RightShift);
            calculator.Evaluate();
            Assert.AreEqual(2, calculator.Operand);
            Assert.AreEqual("1 + 2 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.RightShift);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 Rsh 3 Rsh ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + 2 Rsh 3 Rsh 0 = ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 AND 3 AND 3 = \"]")]
        public void TestMethod8()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseAND);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 AND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseAND);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 AND 3 AND ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 AND 3 AND 3 = ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 OR 3 OR 3 = \"]")]
        public void TestMethod9()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseOR);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 OR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseOR);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 OR 3 OR ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 OR 3 OR 3 = ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 NAND 3 NAND - 4 = \"]")]
        public void TestMethod10()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NAND ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseNAND);
            calculator.Evaluate();
            Assert.AreEqual(-4, calculator.Operand);
            Assert.AreEqual("1 + 2 NAND 3 NAND ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NAND 3 NAND -4 = ", calculator.Expression);
        }

        [TestMethod("[3, \"1 + 2 NOR 3 NOR - 4 = \"]")]
        public void TestMethod11()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseNOR);
            calculator.Evaluate();
            Assert.AreEqual(-4, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR 3 NOR ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 NOR 3 NOR -4 = ", calculator.Expression);
        }

        [TestMethod("[0, \"1 + 2 XOR 3 XOR 0 = \"]")]
        public void TestMethod12()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            calculator.Evaluate();
            Assert.AreEqual(3, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseXOR);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR 3 XOR ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(0, calculator.Operand);
            Assert.AreEqual("1 + 2 XOR 3 XOR 0 = ", calculator.Expression);
        }

        [TestMethod("[24, \"1 + 23 = \"]")]
        public void TestMethod13()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(-2, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.Negate);
            calculator.Evaluate();
            Assert.AreEqual(23, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(24, calculator.Operand);
            Assert.AreEqual("1 + 23 = ", calculator.Expression);
        }

        [TestMethod("[-3, \"1 + NOT(3) = \"]")]
        public void TestMethod14()
        {
            var calculator = new Calculator.Calculator();

            calculator.EnqueueToken(Numbers.Num1);
            calculator.EnqueueToken(Operators.Plus);
            calculator.Evaluate();
            Assert.AreEqual(1, calculator.Operand);
            Assert.AreEqual("1 + ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num2);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("1 + NOT( 2 ) ", calculator.Expression);

            calculator.EnqueueToken(Numbers.Num3);
            calculator.EnqueueToken(Operators.BitwiseNOT);
            calculator.Evaluate();
            Assert.AreEqual(-4, calculator.Operand);
            Assert.AreEqual("1 + NOT( 3 ) ", calculator.Expression);

            calculator.EnqueueToken(Operators.Submit);
            calculator.Evaluate();
            Assert.AreEqual(-3, calculator.Operand);
            Assert.AreEqual("1 + NOT( 3 ) = ", calculator.Expression);
        }
    }
}
