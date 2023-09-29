using Simulator.Core;

namespace Simulator.Models
{
    public class Switch
    {
        public int Id { get; set; }
        public int ApplianceId { get; set; }
        public State SwitchState { get; set; }

        public Switch() { }

        public Switch(int applianceId, State switchState=State.Off)
        {
            ApplianceId = applianceId;
            SwitchState = switchState;
        }

        public Switch(int id, int applianceId, State switchState)
        {
            Id = id;
            ApplianceId = applianceId;
            SwitchState = switchState;
        }
    }
}
