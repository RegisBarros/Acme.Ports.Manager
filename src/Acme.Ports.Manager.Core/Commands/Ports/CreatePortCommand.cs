namespace Acme.Ports.Manager.Core.Commands.Ports
{
    public class CreatePortCommand
    {
        public CreatePortCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}