using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository
    {
        // This collection is used to simulate remote database
        public static readonly Dictionary<int, Client> Database = new()
        {
            {1, new Client("Kowalski", "kowalski@wp.pl", "Warszawa, Złota 12" ,"NormalClient")},
            {2, new Client("Malewski", "malewski@gmail.pl", "Warszawa, Koszykowa 86", "VeryImportantClient")},
            {3, new Client("Smith", "smith@gmail.pl", "Warszawa, Kolorowa 22", "ImportantClient")},
            {4, new Client("Doe", "doe@gmail.pl", "Warszawa, Koszykowa 32", "ImportantClient")},
            {5, new Client("Kwiatkowski", "kwiatkowski@wp.pl", "Warszawa, Złota 52", "NormalClient")},
            {6, new Client("Andrzejewicz", "andrzejewicz@wp.pl", "Warszawa, Koszykowa 52", "NormalClient")}
        };
        
        // Simulating fetching a client from remote database
        internal Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (Database.ContainsKey(clientId))
                return Database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }
}