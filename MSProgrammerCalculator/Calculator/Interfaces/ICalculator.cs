using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ICalculator
    {
        /// <summary>
        /// 현재 기수(Radix).
        /// </summary>
        BaseNumber CurrentBaseNumber { get; set; }

        /// <summary>
        /// 현재 피연산자.
        /// </summary>
        long CurrentOperand { get; }

        /// <summary>
        /// 현재 표현식.
        /// </summary>
        string CurrentExpression { get; }

        /// <summary>
        /// 현재 피연산자가 변경됐을 때 발생합니다.
        /// </summary>
        event EventHandler<CurrentOperandChangedEventArgs> CurrentOperandChanged;

        /// <summary>
        /// 식이 평가됐을 때 발생합니다.
        /// </summary>
        event EventHandler<ExpressionEvaluatedEventArgs> ExpressionEvaluated;

        /// <summary>
        /// 식을 평가합니다.
        /// </summary>
        void Evaluate();

        /// <summary>
        /// 표시 값 오른쪽에 숫자를 삽입합니다.
        /// </summary>
        /// <param name="number"></param>
        void InsertNumber(Numbers number);

        /// <summary>
        /// 표시 값 오른쪽의 숫자를 제거합니다.
        /// </summary>
        void RemoveNumber();

        /// <summary>
        /// 연산자 토큰을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns>연산자 토큰이 추가됐으면 true이고, 그렇지 않으면 false입니다.</returns>
        bool TryEnqueueToken(Operators op);
    }
}
