using System;

namespace LegacyApp
{
    public class UserService
    {
        
        private const int MinAge = 21;  
        private const int MaxCreditLimit = 500;
        
        public bool AddUser(string name, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            // Validate input
            if (!ValidateName(name) || !ValidateName(lastName) || !ValidateEmail(email) || !ValidateAge(dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            
            var user = new User(name, email, client, dateOfBirth, lastName);
            user.SetCreditLimit(user);
            
            // Validate credit limit
            if (ValidateCreditLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        
        private bool ValidateEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        
        private bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
        
        private bool ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age >= MinAge;
        }
        
        private bool ValidateCreditLimit(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < MaxCreditLimit;
        }
    }
}
