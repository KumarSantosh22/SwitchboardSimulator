namespace Simulator.Models
{
    public class SwitchBoard
    {
        public int Id { get; set; }
        public List<Switch> Switches { get; set; }

        public SwitchBoard()
        {
            Switches = new List<Switch>();
        }
        public SwitchBoard(int id)
        {
            Id = id;
            Switches = new List<Switch>();
        }
    }
}
