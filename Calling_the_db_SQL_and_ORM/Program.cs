using Calling_the_db_SQL_and_ORM.Data;
using Calling_the_db_SQL_and_ORM.Models;

namespace Calling_the_db_SQL_and_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(NorthContext context = new NorthContext())
            {
                var customers = context.Customers //Skapar en lista med företagskunder
                                .OrderBy(c => c.CompanyName)
                                .Select(c => new
                                {
                                    c.CustomerId,
                                    c.CompanyName,
                                    c.ContactName,
                                    c.ContactTitle,
                                    c.Address,
                                    c.City,
                                    c.Region,
                                    c.PostalCode,
                                    c.Country,
                                    c.Phone,
                                    c.Fax,
                                    OrderCount = context.Orders.Count(o => o.CustomerId == c.CustomerId)
                                })
                                .ToList();



                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("Välj en funktion:");
                    Console.WriteLine("1. Hämta alla kunder");
                    Console.WriteLine("2. Visa en kunds information");
                    Console.WriteLine("3. Lägg till en ny kund");
                    Console.WriteLine("4. Avsluta");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": //prints a list of all costumers in asc or desc
                            Console.Clear();
                            Console.WriteLine("Välj mellan A-Ö (1) eller Ö-A (2):");
                            string ascOrDesc = Console.ReadLine();
                            if (ascOrDesc == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("Alla kunder:");
                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"Företagsnamn: {customer.CompanyName}, \nLand: {customer.Country}, \nRegion: {customer.Region}, \nTelefonnummer: {customer.Phone}, \nAntal ordrar: {customer.OrderCount}\n");
                                }
                                Console.ReadLine();
                            }
                            else if (ascOrDesc == "2")
                            {
                                Console.Clear();
                                Console.WriteLine("Alla kunder:");
                                customers.Reverse();
                                foreach (var customer in customers)
                                {
                                    Console.WriteLine($"Företagsnamn: {customer.CompanyName}, \nLand: {customer.Country}, \nRegion: {customer.Region}, \nTelefonnummer: {customer.Phone}, \nAntal ordrar: {customer.OrderCount}\n");
                                }
                                customers.Reverse();
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val.");
                                Console.ReadLine();
                            }
                            break;

                        case "2": //lets you see more info about a chosen costumer and its orders
                            Console.Clear();
                            Console.WriteLine("Välj en kund från listan:");
                            for (int i = 0; i < customers.Count; i++) //prints out all companies in a numbered list
                            {
                                Console.WriteLine($"{i + 1}. {customers[i].CompanyName}");
                            }

                            int selectedCustomerIndex = int.Parse(Console.ReadLine());
                            if (selectedCustomerIndex >= 0 && selectedCustomerIndex < customers.Count) //prints info about chosen costumer
                            {
                                var selectedCustomer = customers[selectedCustomerIndex-1];
                                Console.WriteLine("Kundinformation:");
                                Console.WriteLine($"Företagsnamn: {selectedCustomer.CompanyName}");
                                Console.WriteLine($"Kontaktperson: {selectedCustomer.ContactName}");
                                Console.WriteLine($"Titel: {selectedCustomer.ContactTitle}");
                                Console.WriteLine($"Adress: {selectedCustomer.Address}");
                                Console.WriteLine($"Stad: {selectedCustomer.City}");
                                Console.WriteLine($"Region: {selectedCustomer.Region}");
                                Console.WriteLine($"Postnummer: {selectedCustomer.PostalCode}");
                                Console.WriteLine($"Land: {selectedCustomer.Country}");
                                Console.WriteLine($"Telefonnummer: {selectedCustomer.Phone}");
                                Console.WriteLine($"Fax: {selectedCustomer.Fax}");
                                Console.WriteLine($"Antal ordrar: {selectedCustomer.OrderCount}");

                                var customersOrders = context.Orders //Creates a list of all orders for chosen costumer
                                    .Where(o => o.CustomerId == selectedCustomer.CustomerId)
                                    .Select(o => new
                                    {
                                        o.OrderDate,
                                        o.RequiredDate,
                                        o.ShippedDate,
                                        o.ShipVia,
                                        o.Freight,
                                        o.ShipName,
                                        o.ShipAddress,
                                        o.ShipCity,
                                        o.ShipRegion,
                                        o.ShipPostalCode,
                                        o.ShipCountry
                                    })
                                    .ToList();

                                Console.WriteLine("Kundens ordrar:\n");
                                foreach (var order in customersOrders) //prints out all orders from the list for chosen costumer
                                {
                                    Console.WriteLine($"Orderdatum: {order.OrderDate}");
                                    Console.WriteLine($"Inköpsdatum: {order.RequiredDate}");
                                    Console.WriteLine($"Leveransdatum: {order.ShippedDate}");
                                    Console.WriteLine($"Leveranssätt: {order.ShipVia}");
                                    Console.WriteLine($"Frakt: {order.Freight}");
                                    Console.WriteLine($"Leveransnamn: {order.ShipName}");
                                    Console.WriteLine($"Adress: {order.ShipAddress}");
                                    Console.WriteLine($"Stad: {order.ShipCity}");
                                    Console.WriteLine($"Region: {order.ShipRegion}");
                                    Console.WriteLine($"Postnummer: {order.ShipPostalCode}");
                                    Console.WriteLine($"Land: {order.ShipCountry}");
                                    Console.WriteLine();
                                }

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val.");
                                Console.ReadLine();
                            }
                                
                            break;
                        case "3": //lets you add a new costumer
                            Console.Clear();
                            static string GenerateRandomID()
                            {
                                const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                                var random = new Random();
                                var randomId = new string(Enumerable.Repeat(characters, 5)
                                    .Select(s => s[random.Next(5)])
                                    .ToArray());
                                return randomId;
                            }

                            Console.WriteLine("Fyll i kunduppgifter:");
                            Console.WriteLine("Företagsnamn: ");
                            string newCompanyName = Console.ReadLine();
                            Console.WriteLine("Kontaktperson: ");
                            string newContactName = Console.ReadLine();
                            Console.WriteLine("Titel: ");
                            string newContactTitle = Console.ReadLine();
                            Console.WriteLine("Adress: ");
                            string newAddress = Console.ReadLine();
                            Console.WriteLine("Stad: ");
                            string newCity = Console.ReadLine();
                            Console.WriteLine("Region: ");
                            string newRegion = Console.ReadLine();
                            Console.WriteLine("Postnummer: ");
                            string newPostalCode = Console.ReadLine();
                            Console.WriteLine("Land: ");
                            string newCountry = Console.ReadLine();
                            Console.WriteLine("Telefonnummer: ");
                            string newPhone = Console.ReadLine();
                            Console.WriteLine("Fax: ");
                            string newFax = Console.ReadLine();

                            var newCustomer = new Customer
                            {
                                CustomerId = GenerateRandomID(),
                                CompanyName = newCompanyName,
                                ContactName = newContactName,
                                ContactTitle = newContactTitle,
                                Address = newAddress,
                                City = newCity,
                                Region = newRegion,
                                PostalCode = newPostalCode,
                                Country = newCountry,
                                Phone = newPhone,
                                Fax = newFax,
                            };

                            context.Customers.Add(newCustomer);
                            context.SaveChanges();

                            Console.ReadLine();
                            break;
                        case "4": //ends the program
                            Console.Clear();
                            Console.WriteLine("Programmet avslutat.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }
            }
        }
    }
}