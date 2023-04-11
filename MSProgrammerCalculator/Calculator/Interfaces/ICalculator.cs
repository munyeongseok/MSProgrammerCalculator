using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ICalculator : INotifyPropertyChanged
    {
        /// <summary>
        /// 현재 기수(Radix).
        /// </summary>
        BaseNumber BaseNumber { get; set; }

        /// <summary>
        /// 현재 피연산자.
        /// </summary>
        long Operand { get; }

        /// <summary>
        /// 현재 수식.
        /// </summary>
        string Expression { get; }

        /// <summary>
        /// 입력 제출 여부.
        /// </summary>
        bool IsInputSubmitted { get; }

        /// <summary>
        /// 숫자 토큰을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="number"></param>
        void EnqueueToken(Numbers number);

        /// <summary>
        /// 연산자 토큰을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="op"></param>
        /// <returns>연산자 토큰이 추가됐으면 true이고, 그렇지 않으면 false입니다.</returns>
        bool EnqueueToken(Operators op);

        /// <summary>
        /// 입력 대기열의 끝 부분에 추가된 숫자 토큰을 제거합니다.
        /// </summary>
        void RemoveLastNumberToken();

        /// <summary>
        /// 수식을 평가합니다.
        /// </summary>
        void Evaluate();

        /// <summary>
        /// 입력을 제거합니다.
        /// </summary>
        void ClearInput();

        /// <summary>
        /// 입력을 제출합니다.
        /// </summary>
        void SubmitInput();
    }
}
