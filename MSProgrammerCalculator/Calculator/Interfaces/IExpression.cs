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
        /// 표현식을 평가합니다.
        /// </summary>
        /// <returns></returns>
        long Evaluate();

        /// <summary>
        /// 표현식 토큰을 가져옵니다.
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <returns></returns>
        string GetToken(BaseNumber baseNumber = BaseNumber.Decimal);
    }
}
