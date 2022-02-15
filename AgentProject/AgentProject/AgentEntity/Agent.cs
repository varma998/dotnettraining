using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentEntity
{
    [Serializable]
    public class Agent
    {
        

        public int AgentId { get; set; }
        public String AgentName { get; set; }
        public String Gender { get; set; }
        public int PayMode { get; set; }
        public double Premium { get; set; }

        public override string ToString()
        {
            return "Agent Id = " + AgentId + " AgentName = " + AgentName + " Gender = " + Gender + " Paymode = " + PayMode + " Premium" + Premium;
        }
    }
}
