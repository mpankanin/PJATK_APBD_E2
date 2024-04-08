namespace LegacyApp
{
    public class Client : Person
    {
        private static int _lastClientId;
        
        public int ClientId { get; }
        public string Address { get; internal set; }
        public string Type { get; internal set; }
        
        public Client(string name, string email, string address, string type) 
            : base(name, email)
        {
            ClientId = ++_lastClientId;    
            Address = address;
            Type = type;
        }
    }
}