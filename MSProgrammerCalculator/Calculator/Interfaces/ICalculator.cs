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
        /// 현재 표시 값.
        /// </summary>
        long CurrentDisplayValue { get; }

        /// <summary>
        /// 현재 수치 표현식.
        /// </summary>
        string CurrentNumericalExpression { get; }

        /// <summary>
        /// 식을 평가합니다.
        /// </summary>
        void Evaluate();

        /// <summary>
        /// 기수(Radix)를 변경합니다.
        /// </summary>
        /// <param name="baseNumber"></param>
        void ChangeBaseNumber(BaseNumber baseNumber);

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
        /// 연산자 Expression을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        bool TryEnqueueExpression(Operators op);
    }
}
