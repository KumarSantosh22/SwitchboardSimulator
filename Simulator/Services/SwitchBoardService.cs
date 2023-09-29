using Simulator.Core;
using Simulator.Models;

namespace Simulator.Services
{
    public class SwitchBoardService
    {
        private SwitchBoard switchBoard;

        public SwitchBoardService()
        {
            switchBoard = new SwitchBoard(1);
        }

        public List<Switch> GetAllSwitch()
        {
            return switchBoard.Switches;
        }

        public Switch? GetSwitch(int id)
        {
            return switchBoard.Switches.SingleOrDefault(item => item.Id == id);
        }

        public void AddSwitch(Switch sch)
        {
            try
            {
                sch.Id = GenerateSwitchId();
                switchBoard.Switches.Add(sch);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public bool ToggleSwitchState(int id, State state)
        {
            try
            {
                Switch? sch = switchBoard.Switches.SingleOrDefault(x => x.Id == id);
                if (sch != null)
                {
                    sch.SwitchState = state;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private int GenerateSwitchId()
        {
            Switch? sch = switchBoard.Switches.LastOrDefault();
            if (sch != null)
            {
                return sch.Id + 1;
            }
            return 1;
        }
    }
}
