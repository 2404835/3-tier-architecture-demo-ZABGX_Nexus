using MySql.Data.MySqlClient;
using MySQLTest.BusinessLayer;

class Program
{
    static void Main()
    {
        OrganismeService _service = new OrganismeService();
        bool _gebruikerMaaktValideKeuze = true;

        while (_gebruikerMaaktValideKeuze)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Registreer een nieuw Dier");
            Console.WriteLine("2. Registreer een nieuwe Plant");
            Console.WriteLine("3. Toon alle geregistreerde dieren en planten");
            Console.WriteLine("4. Filter op (Dier/Plant/Exotisch/Inheems)");
            Console.WriteLine("5. Afsluiten");
            Console.Write("Maak een keuze: ");
            string keuze = Console.ReadLine();

            if (keuze == "1")
            {
                Console.Clear();
                Console.Write("Wat is de naam van het dier? ");
                string naam = Console.ReadLine();

                Console.Write("Is het een inheems of exotisch dier? ");
                string oorsprong = Console.ReadLine();

                Console.Write("Waar komt het dier vooral voor? ");
                string leefgebied = Console.ReadLine();




                _service.RegistreerDier(naam, oorsprong, leefgebied);
                Console.WriteLine("\nInfo geregistreerd!\nDruk op <Enter> om terug naar het Menu");
                Console.ReadLine();


            }
            else if (keuze == "2")
            {
                Console.Clear();
                Console.Write("Wat is de naam van de plant? ");
                string naam = Console.ReadLine();

                Console.Write("Is de plant inheems of exotisch? ");
                string oorsprong = Console.ReadLine();

                Console.Write("Hoe hoog kan de plant worden in meters? ");
                string hoogte = Console.ReadLine();

                decimal hoogte_decimal = decimal.Parse(hoogte);
                Console.Write("Waar heb je de plant gevonden? ");
                string locatie =Console.ReadLine();




                _service.RegistreerPlant(naam, oorsprong, hoogte_decimal, locatie);
                Console.WriteLine("\nInfo geregistreerd!\nDruk op <Enter> om terug naar het Menu");
                Console.ReadLine();





            }
            else if (keuze == "3")
            {
                Console.Clear();
                var soorten_dieren = _service.HaalAlleDierenOp();
                var soorten_planten = _service.HaalAllePlantenOp();
                Console.WriteLine("Geregistreerde soorten:");

                foreach (var soort in soorten_dieren)
                {
                    Console.WriteLine($"Dier: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Leefgebied: {soort.Leefgebied}");
                }
                foreach (var soort in soorten_planten)
                {
                    Console.WriteLine($"Plant: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Hoogte: {soort.Hoogte}, Locatie: {soort.Locatie}");
                }
                Console.WriteLine("\nDruk op <Enter> om terug naar het Menu");
                Console.ReadLine();

            }
            else if (keuze == "4")
            {
                Console.Clear();
                Console.WriteLine("Kies uit de onderstaande filters");
                Console.WriteLine("1. Dier");
                Console.WriteLine("2. Plant");
                Console.WriteLine("3. Exotisch");
                Console.WriteLine("4. Inheems");
                Console.WriteLine("Keuze: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    var soorten_dieren = _service.HaalAlleDierenOp();
                    foreach (var soort in soorten_dieren)
                    {
                        Console.WriteLine($"Dier: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Leefgebied: {soort.Leefgebied}");
                    }
                }
                if (input == "2")
                {
                    var soorten_planten = _service.HaalAllePlantenOp();
                    foreach (var soort in soorten_planten)
                    {
                        Console.WriteLine($"Plant: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Hoogte: {soort.Hoogte}, Locatie: {soort.Locatie}");
                    }
                }
                if (input == "3")
                {
                    var soorten_dieren = _service.HaalAlleDierenOp();
                    var soorten_planten = _service.HaalAllePlantenOp();
                    Console.WriteLine("Geregistreerde exotische soorten:");

                    foreach (var soort in soorten_dieren)
                    {
                        if (soort.Oorsprong.ToLower() == "exotisch")
                        {

                            Console.WriteLine($"Dier: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Leefgebied: {soort.Leefgebied}");

                        }
                    }
                    foreach (var soort in soorten_planten)
                    {
                        if (soort.Oorsprong.ToLower() == "exotisch")
                        {

                            Console.WriteLine($"Plant: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Hoogte: {soort.Hoogte}, Locatie: {soort.Locatie}");

                        }
                    }
                }
                if (input == "4")
                {
                    var soorten_dieren = _service.HaalAlleDierenOp();
                    var soorten_planten = _service.HaalAllePlantenOp();
                    Console.WriteLine("Geregistreerde inheemse soorten:");

                    foreach (var soort in soorten_dieren)
                    {
                        if (soort.Oorsprong.ToLower() == "inheems")
                        {

                            Console.WriteLine($"Dier: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Leefgebied: {soort.Leefgebied}");

                        }
                    }
                    foreach (var soort in soorten_planten)
                    {
                        if (soort.Oorsprong.ToLower() == "inheems")
                        {

                            Console.WriteLine($"Plant: Naam: {soort.Naam}, Oorsprong: {soort.Oorsprong}, Hoogte: {soort.Hoogte}, Locatie: {soort.Locatie}");

                        }
                    }


                }
                Console.WriteLine("\nDruk op <Enter> om terug naar het Menu");
                Console.ReadLine();
            }
                else if (keuze == "5")
                {
                    Console.WriteLine("Programma afgesloten.");
                    _gebruikerMaaktValideKeuze = false;
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw.\n");
                }
            }
        }
    }

        

