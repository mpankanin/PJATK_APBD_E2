using System;

namespace LegacyApp
{
    public class User : Person
    {
        public Client Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        
        public User(string name, string email, Client client, DateTime dateOfBirth, string lastName) : base(name, email)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            LastName = lastName;
        }
        
        public void SetCreditLimit(User user)
        {
            if (user.Client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (user.Client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    user.CreditLimit = creditLimit;
                }
            }
        }
    }
}