using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deluxe.BLL
{
    public class TypingErreur:Exception
    {
        public TypingErreur():base()
        {

        }
        public TypingErreur(string message): base(message)
        {

        }
        public TypingErreur(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
