using Simulator;

SwitchBoardSimulator simulator = new SwitchBoardSimulator();
simulator.OnStartup();

int swo = -1;
while (swo!=0)
{
    try
    {
        swo = simulator.DisplayAndSelectFromMainMenu();
        if (swo < 0)
        {
            simulator.Print("Select a valid option.");
            simulator.Print();
        }
        else if(swo > 0)
        {
            simulator.ShowSubMenu(swo);
            simulator.Print();
        }
        else
        {
            simulator.Print("Exiting from application . . .");
        }
    }
    catch (Exception ex)
    {
        simulator.Print(ex.Message);
    }
}
