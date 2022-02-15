using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AgentEntity;

namespace AgentDAL
{
    public class AgentDataLayer
    {
        static List<Agent> agentList;
        static AgentDataLayer() {
            agentList = new List<Agent>();
        }

        public string AddAgentDAL(Agent agent) {
            agentList.Add(agent);
            return "Agent Added";
        }

        public List<Agent> ShowAgentDAL()
        {
            return agentList;
        }

        public Agent SearchAgentDAL(int agentID) {
            foreach (Agent agent in agentList) {
                if (agent.AgentId == agentID) {
                    return agent;
                }
            }
            return null;
        }

        public string UpdateAgentDAL(int agentID,string name,string gender,int paymode,double premium)
        {
            foreach (Agent agent in agentList)
            {
                if (agent.AgentId == agentID)
                {
                    agent.AgentName = name;
                    agent.Gender = gender;
                    agent.PayMode = paymode;
                    agent.Premium = premium;
                    return "Agent Updated";
                }
            }
            return null;
        }

        public string DeleteAgentDAL(int agentID) {
            Agent agentFound = SearchAgentDAL(agentID);
            if (agentFound != null)
            {
                agentList.Remove(agentFound);

            }
            return "Agent Record is Not Available";
        }

        public string ReadAgentFileDAL()
        {
            FileStream fs = new FileStream("d:/AgentProject.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter binf = new BinaryFormatter();
            agentList = (List<Agent>)binf.Deserialize(fs);
            fs.Close();
            return "Data Restored From File";
        }

        public string WriteAgentFileDAL()
        {
            FileStream fs = new FileStream("d:/AgentProject.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter binf = new BinaryFormatter();
            binf.Serialize(fs, agentList);
            fs.Close();
            return "Data Stored in File";
        }
    }
}
