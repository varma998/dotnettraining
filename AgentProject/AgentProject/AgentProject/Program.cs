using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentBAL;
using AgentDAL;
using AgentEntity;
using AgentExceptions;

namespace AgentProject
{
    class Program
    {
        static AgentBusinessLayer bal = new AgentBusinessLayer();

        public static void AddAgentMain()
        {
            Agent agent = new Agent();
            Console.WriteLine("Enter Agent Name  ");
            agent.AgentName = Console.ReadLine();
            Console.WriteLine("Enter Agent Gender  ");
            agent.Gender = Console.ReadLine();
            Console.WriteLine("Enter Agent PayMode  ");
            agent.PayMode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Agent Premium");
            agent.Premium = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(bal.AddAgentBAL(agent));


        }

        public static void SearchAgentMain()
        {
            int agentid;
            Console.WriteLine("Enter Agent No  ");
            agentid = Convert.ToInt32(Console.ReadLine());
            Agent agent = bal.SearchAgentBAL(agentid);
            if (agent != null)
            {
                Console.WriteLine(agent);
            }
            else
            {
                Console.WriteLine("Record Not Found...");
            }
        }

        public static void DeleteAgentMain()
        {
            int agentid;
            Console.WriteLine("Enter agent No  ");
            agentid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(bal.DeleteAgentBAL(agentid));
        }

        public static void ShowAgentMain()
        {
            List<Agent> agentList = bal.ShowAgentBAL();
            foreach (Agent agent in agentList)
            {
                Console.WriteLine(agent);
            }
        }

        public static void ReadAgentFileMain()
        {
            bal.ReadAgentFileBAL();
        }
        public static void WriteAgentFileMain()
        {
            bal.WriteAgentFileBAL();
        }

        public static void UpdateAgentMain()
        {
            Console.WriteLine("Enter the Agent id : ");
            int agentid = Convert.ToInt32((Console.ReadLine()));
            Console.WriteLine(bal.UpdateAgentBAL(agentid));
        }

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("O P T I O N S ");
                Console.WriteLine("--------------");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. Show Agent");
                Console.WriteLine("3. Search Agent");
                Console.WriteLine("4. Delete Agent");
                Console.WriteLine("5. Write Agent");
                Console.WriteLine("6. Read Agent");
                Console.WriteLine("7. Update Agent");
                Console.WriteLine("8.Exit");
                Console.WriteLine("Enter Your Choice   ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            AddAgentMain();
                        }
                        catch (AgentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        ShowAgentMain();
                        break;
                    case 3:
                        SearchAgentMain();
                        break;
                    case 4:
                        DeleteAgentMain();
                        break;
                    case 5:
                        WriteAgentFileMain();
                        break;
                    case 6:
                        ReadAgentFileMain();
                        break;
                    case 7:
                        UpdateAgentMain();
                        break;
                    case 8:
                        return;
                }
            } while (choice != 8);
        }
    }
}
