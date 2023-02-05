using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IExpression
    {
        /// <summary>
        /// 숫자 표현식 토큰.
        /// </summary>
        string NumericalExpressionToken { get; }

        /// <summary>
        /// 식을 평가합니다.
        /// </summary>
        /// <returns></returns>
        long Evaluate();
    }
}
