var service = new InheemseSoortService();
bool gebruikerMaaktValideKeuze = true;

while (gebruikerMaaktValideKeuze)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Registreer een nieuwe inheemse soort");
    Console.WriteLine("2. Toon alle geregistreerde inheemse soorten");
    Console.WriteLine("3. Afsluiten");
    Console.Write("Maak een keuze: ");
    string keuze = Console.ReadLine();
  
    if (keuze == "1")
    {
        Console.Write("Naam van de soort: ");
        string naam = Console.ReadLine();

        Console.Write("Naam van de locatie: ");
        string locatieNaam  = Console.ReadLine();

        Console.Write("Longitude: ");
        string longitudeAntwoord = Console.ReadLine();
        Decimal longitude = Convert.ToDecimal(longitudeAntwoord);

        Console.Write("Latitude: ");
        string latitudeAntwoord = Console.ReadLine();
        Decimal laitude = Convert.ToDecimal(latitudeAntwoord);

        Console.Write($"(Voorbeeld: 23-12-2024 14:45) {Environment.NewLine} Datum: ");
        string datumAntwoord = Console.ReadLine();
        DateTime datum = DateTime.ParseExact(datumAntwoord, "dd-MM-yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);;

        service.RegistreerInheemseSoort(naam, locatieNaam, longitude, laitude, datum);
        Console.WriteLine("Soort geregistreerd!\n");
    }
    else if (keuze == "2")
    {
        var soorten = service.HaalAlleInheemseSoortenOp();
        Console.WriteLine("Geregistreerde soorten:");

        foreach (var soort in soorten)
        {
            Console.WriteLine($"Naam: {soort.Naam}, Locatie: {soort.LocatieNaam}, Longitude: {soort.Longitude}, Latitude: {soort.Latitude}, Datum: {soort.Datum}");
        }
        Console.WriteLine();
    }
    else if (keuze == "3")
    {
        Console.WriteLine("Programma afgesloten.");
        gebruikerMaaktValideKeuze = false;
    }
    else
    {
        Console.WriteLine("Ongeldige keuze, probeer opnieuw.\n");
    }
}