using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTest.Models
{
    internal class Dier
    {
        public string Naam { get; private set; }
        public string Oorsprong { get; private set; }
        public string Leefgebied { get; private set; }


        public Dier(string naam, string oorprong, string leefgebied)
        {
            Naam = naam;
            Oorsprong = oorprong;
            Leefgebied = leefgebied;
        }
    }
    internal class Plant
    {
        public string Naam { get; private set; }
        public string Oorsprong { get; private set; }
        public decimal Hoogte { get; private set; }
        public string Locatie { get; private set; }


        public Plant(string naam, string oorprong, decimal hoogte, string locatie)
        {
            Naam = naam;
            Oorsprong = oorprong;
            Hoogte = hoogte;
            Locatie = locatie;
        }
    }
}
