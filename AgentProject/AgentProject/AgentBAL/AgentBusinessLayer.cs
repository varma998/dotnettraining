using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgentDAL;
using AgentEntity;
using AgentExceptions;
using System.Threading.Tasks;

namespace AgentBAL
{
    public class AgentBusinessLayer
    {
        static int id = 1;
        static StringBuilder sb = new StringBuilder();
        static AgentDataLayer dal = new AgentDataLayer();

        public bool ValidateAgent(Agent agent) {
            bool isValidAgent = true;
            if (agent.AgentName.Length < 5 || agent.AgentName.Length > 12) {
                sb.Append("Agent Name should be between 5 to 12 characters");
                isValidAgent = false;
            }
            if (!(agent.Gender.Equals("Male")) && !(agent.Gender.Equals("Female")))
            {
                sb.Append("Agent gender should be Male or Female--??");
                isValidAgent = false;
            }

            if (agent.PayMode>3 || agent.PayMode<1) {
                sb.Append("Paymode should be only 1,2,3...");
                isValidAgent = false;
            }
            if (agent.Premium < 15000) {
                sb.Append("Minimum premium is 15000");
                isValidAgent = false;
            }
            return isValidAgent;
        }

        public string AddAgentBAL(Agent agent) {
            agent.AgentId = id++;
            if (ValidateAgent(agent) == false)
            {
                throw new AgentException(sb.ToString());
            }
            else { 
                return dal.AddAgentDAL(agent);
            }
        }

        public List<Agent> ShowAgentBAL() { 
            return dal.ShowAgentDAL();
        }

        public Agent SearchAgentBAL(int agentID) { 
            return dal.SearchAgentDAL(agentID);
        }

        public string DeleteAgentBAL(int agentID) { 
            return dal.DeleteAgentDAL(agentID);
        }

        public string UpdateAgentBAL(int agentID) {
            Console.WriteLine("Enter Updated Name of Agent:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Gender to be Updated");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter updated paymode : ");
;           int paymode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter updated premium : ");
            double premium = Convert.ToDouble(Console.ReadLine());
            return dal.UpdateAgentDAL(agentID, name, gender, paymode, premium);

        }
        public string ReadAgentFileBAL()
        {
            return dal.ReadAgentFileDAL();
        }
        public string WriteAgentFileBAL()
        {
            return dal.WriteAgentFileDAL();
        }
    }
}
