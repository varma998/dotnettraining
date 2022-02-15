using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentExceptions
{
    public class AgentException : ApplicationException
    {
        public AgentException() { }

        public AgentException(string error) : base(error) { }
    }
}
