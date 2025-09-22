using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate
{
    public delegate void MessageTFShow(ErrorCode WrongProblem);

    public class Publisher
    {
        public event MessageTFShow aMessage;

        public void ShowMessage(ErrorCode aErrorCode)
        {
            aMessage?.Invoke(aErrorCode);
        }
    }

    public enum ErrorCode
    {
        PassWordWrong =0,
        PassWordNull = 1,
    }
}
