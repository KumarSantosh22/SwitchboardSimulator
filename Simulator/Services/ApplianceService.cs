using Simulator.Core;
using Simulator.Models;

namespace Simulator.Services
{
    public class ApplianceService
    {
        private List<Appliance> appliances;
        public ApplianceService()
        {
            appliances = new List<Appliance>();
        }

        public List<Appliance> GetAll()
        {
            return appliances;
        }

        public Appliance? Get(int id)
        {
            return appliances.SingleOrDefault(item => item.Id == id);
        }

        public int Add(Appliance appliance)
        {
            try
            {
                appliance.Id = GenerateId();
                appliances.Add(appliance);
                return appliance.Id;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool UpdateState(int id, State state)
        {
            try
            {
                Appliance? appliance = appliances.SingleOrDefault(x => x.Id == id);
                if (appliance == null)
                {
                    return false;
                }
                appliance.State = state;
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        
        public bool Remove(int id)
        {
            try
            {
                Appliance? appliance = appliances.SingleOrDefault(x => x.Id == id);
                if (appliance == null)
                {
                    return false;
                }
                return appliances.Remove(appliance);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private int GenerateId()
        {
            Appliance? appliance = appliances.LastOrDefault();
            if (appliance != null)
            {
                return appliance.Id + 1;
            }
            return 1;
        }
    }
}
