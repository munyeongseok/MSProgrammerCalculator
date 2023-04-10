# MSProgrammerCalculator

[**MSProgrammerCalculator:**](/MSProgrammerCalculator/MSProgrammerCalculator)
Calculator application.

[**Calculator:**](/MSProgrammerCalculator/Calculator)
Calculator class library.

[**CalculatorTests:**](/MSProgrammerCalculator/CalculatorTests)
Unit test project.

## Project Build

Visual Studio 2022. .NET Framework 4.8.

## Notes

#### For checking coding style.
Implement the Windows Calculator (Programmer) functionalities through clone coding.

## MSProgrammerCalculator Solution Structure

```mermaid
graph TD
    calculator[Calculator] --> calculatorApp[MSProgrammerCalculator]
```

## Calculator Expression Class Diagram

```mermaid
classDiagram
    IExpression <|-- IOperator
    IExpression <|-- UnaryOperatorExpression
    IOperator <|-- UnaryOperatorExpression
    UnaryOperatorExpression <|-- BitwiseNOTExpression
    UnaryOperatorExpression <|-- NegateExpression
    <<interface>> IExpression
    IExpression : long EvaluateResult()
    IExpression : string EvaluateExpression(BaseNumber)
    <<interface>> IOperator
    IOperator : OperatorDescriptor OperatorDescriptor
    <<abstract>> UnaryOperatorExpression
    UnaryOperatorExpression : IExpression Operand
```

```mermaid
classDiagram
    IExpression <|-- IOperator
    IExpression <|-- BinaryOperatorExpression
    IOperator <|-- BinaryOperatorExpression
    BinaryOperatorExpression <|-- BitwiseANDExpression
    BinaryOperatorExpression <|-- BitwiseNANDExpression
    BinaryOperatorExpression <|-- BitwiseNORExpression
    BinaryOperatorExpression <|-- BitwiseORExpression
    BinaryOperatorExpression <|-- BitwiseXORExpression
    BinaryOperatorExpression <|-- DivideExpression
    BinaryOperatorExpression <|-- LeftShiftExpression
    BinaryOperatorExpression <|-- MinusExpression
    BinaryOperatorExpression <|-- ModuloExpression
    BinaryOperatorExpression <|-- MultiplyExpression
    BinaryOperatorExpression <|-- PlusExpression
    BinaryOperatorExpression <|-- RightShiftExpression
    <<interface>> IExpression
    IExpression : long EvaluateResult()
    IExpression : string EvaluateExpression(BaseNumber)
    <<interface>> IOperator
    IOperator : OperatorDescriptor OperatorDescriptor
    <<abstract>> BinaryOperatorExpression
    BinaryOperatorExpression : IExpression LeftOperand
    BinaryOperatorExpression : IExpression RightOperand
```

```mermaid
classDiagram
    IExpression <|-- IOperator
    IExpression <|-- OperandExpression
    IExpression <|-- SubmitExpression
    IExpression <|-- ParenthesisExpression
    IOperator <|-- ParenthesisExpression
    <<interface>> IExpression
    IExpression : long EvaluateResult()
    IExpression : string EvaluateExpression(BaseNumber)
    <<interface>> IOperator
    IOperator : OperatorDescriptor OperatorDescriptor
```