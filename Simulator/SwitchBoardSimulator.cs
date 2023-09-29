using Simulator.Core;
using Simulator.Models;
using Simulator.Services;

namespace Simulator
{
    // Driver Functions
    public class SwitchBoardSimulator
    {
        private int Fans { get; set; }
        private int Bulbs { get; set; }
        private int ACs { get; set; }

        private SwitchBoardService switchboardService;
        private ApplianceService applianceService;

        public SwitchBoardSimulator()
        {
            switchboardService = new SwitchBoardService();
            applianceService = new ApplianceService();
        }

        public void OnStartup()
        {
            try
            {
                Print("Please enter number of fans you want to connect: ");
                try
                {
                    Fans = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Print(ex.Message);
                }

                Print("Please enter number of bulbs you want to connect: ");
                try
                {
                    Bulbs = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Print(ex.Message);
                }

                Print("Please enter number of ACs you want to connect: ");
                try
                {
                    ACs = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Print(ex.Message);
                }

                // Add Switch and Connect to the Device
                for (int i = 1; i <= Fans; i++)
                {
                    int id = applianceService.Add(new Appliance(ApplianceType.Fan, $"Fan {i}"));
                    switchboardService.AddSwitch(new Switch(id));
                }
                for (int i = 1; i <= Bulbs; i++)
                {
                    int id = applianceService.Add(new Appliance(ApplianceType.Fan, $"Bulb {i}"));
                    switchboardService.AddSwitch(new Switch(id));
                }
                for (int i = 1; i <= ACs; i++)
                {
                    int id = applianceService.Add(new Appliance(ApplianceType.Fan, $"AC {i}"));
                    switchboardService.AddSwitch(new Switch(id));
                }
            }
            catch (Exception ex)
            {
                Print(ex.Message);
                OnStartup();
            }
        }

        public int DisplayAndSelectFromMainMenu()
        {
            Print("\nSelect from the option: ");

            // Get all switch
            List<Switch> switches = switchboardService.GetAllSwitch();
            if (switches.Count > 0)
            {
                foreach (Switch sw in switches)
                {
                    // find Appliance connected to switch
                    Appliance? appliance = applianceService.Get(sw.ApplianceId);
                    if (appliance == null || sw.SwitchState != appliance.State)
                    {
                        Print("No appliance found connected to switch. There may be some disconnection or issue.\nPlease check your connection.");
                    }
                    Print($"{sw.Id}. {appliance.Name} is \"{sw.SwitchState}\"");
                }
                Print("0. Exit");
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Print(ex.Message);
                    return -1;
                }
            }
            return -1;
        }

        public void ShowSubMenu(int switchId)
        {
            Switch? sw = switchboardService.GetSwitch(switchId);
            if (sw != null)
            {
                Appliance? appliance = applianceService.Get(sw.ApplianceId);
                State st = sw.SwitchState == State.On ? State.Off : State.On;
                Print($"1. Switch {appliance.Name} {st.ToString()}");
                Print($"2. Back");
                Print();
                int option = Int32.Parse(Console.ReadLine());
                if (option == 1)
                {
                    DoOperation(sw, appliance);
                }
            }
        }

        public void DoOperation(Switch sw, Appliance appliance)
        {
            try
            {
                State newState = sw.SwitchState == State.On ? State.Off : State.On;
                switchboardService.ToggleSwitchState(sw.Id, newState);
                applianceService.UpdateState(appliance.Id, newState);
            }
            catch (Exception ex)
            {
                Print($"{ex.Message}");
            }
        }

        public void Print(string message = "")
        {
            Console.WriteLine(message);
        }
    }
}
