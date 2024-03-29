﻿using System;
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
        /// 현재 수식.
        /// </summary>
        string Expression { get; }

        /// <summary>
        /// 현재 피연산자.
        /// </summary>
        long Operand { get; }

        /// <summary>
        /// 현재 기수(Radix).
        /// </summary>
        BaseNumber BaseNumber { get; set; }

        /// <summary>
        /// 계산기를 초기화합니다.
        /// </summary>
        void Initialize();

        /// <summary>
        /// 숫자 토큰을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="number"></param>
        void EnqueueToken(Numbers number);

        /// <summary>
        /// 연산자 토큰을 입력 대기열의 끝 부분에 추가합니다.
        /// </summary>
        /// <param name="op"></param>
        void EnqueueToken(Operators op);

        /// <summary>
        /// 피연산자 오른쪽 숫자를 제거합니다.
        /// </summary>
        void RemoveOperandRightDigit();

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
