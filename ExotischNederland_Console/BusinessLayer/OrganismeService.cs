using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQLTest.DataLayer;
using MySQLTest.Models;

namespace MySQLTest.BusinessLayer
{
    internal class OrganismeService
    {
        private readonly OrganismeRepository _repository;

        public OrganismeService()
        {
            _repository = new OrganismeRepository();
        }

        public void RegistreerDier(string naam, string oorsprong, string leefgebied)
        {
            var soort_dier = new Dier
            (
                naam,
                oorsprong,
                leefgebied
            );

            _repository.VoegDierToe(soort_dier);
        }
        public void RegistreerPlant(string naam, string oorsprong, decimal hoogte)
        {
            var soort_plant = new Plant
            (
                naam,
                oorsprong,
                hoogte
            );

            _repository.VoegPlantToe(soort_plant);
        }

        public List<Dier> HaalAlleDierenOp()
        {
            return _repository.HaalAlleDierenOp();
        }
        public List<Plant> HaalAllePlantenOp()
        {
            return _repository.HaalAllePlantenOp();
        }

    }
}

