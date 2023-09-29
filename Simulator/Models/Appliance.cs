using Simulator.Core;

namespace Simulator.Models
{
    public class Appliance
    {
        public int Id { get; set; }
        public ApplianceType ApplianceType { get; set; }
        public string Name { get; set; }
        public State State { get; set; }

        public Appliance() { }
        public Appliance(ApplianceType applianceType, string name, State state=State.Off)
        {
            ApplianceType = applianceType;
            Name = name;
            State = state;
        }

        public Appliance(int id, ApplianceType applianceType, string name, State state=State.Off)
        {
            Id = id;
            ApplianceType = applianceType;
            Name = name;
            State = state;
        }
    }
}
