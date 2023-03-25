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
        /// 결과를 평가합니다.
        /// </summary>
        /// <returns></returns>
        long EvaluateResult();

        /// <summary>
        /// 표현식을 평가합니다.
        /// </summary>
        /// <returns></returns>
        string EvaluateExpression(BaseNumber baseNumber);

        /// <summary>
        /// 표현식 토큰을 가져옵니다.
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <returns></returns>
        string GetToken(BaseNumber baseNumber = BaseNumber.Decimal);
    }
}
