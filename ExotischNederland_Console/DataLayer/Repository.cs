using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTest
{
    using System.Net.NetworkInformation;
    using MySql.Data.MySqlClient;

    internal class OrganismeRepository
    {
        string connectionString = "Server=20.13.32.76;Database=Database;User ID=ZABGX;Password=ZABGXNexus123!;";

        public OrganismeRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new MySqlConnection(connectionString);
        }

        public void VoegDierToe(Dier dier)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = @"
            INSERT INTO dier (Naam, Oorsprong, Leefgebied)
            VALUES (@Naam, @Oorsprong, @Leefgebied);";

            using var command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Naam", dier.Naam);
            command.Parameters.AddWithValue("@Oorsprong", dier.Oorsprong);
            command.Parameters.AddWithValue("@Leefgebied", dier.Leefgebied);

            command.ExecuteNonQuery();
        }
        public void VoegPlantToe(Plant plant)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string insertQuery = @"
            INSERT INTO plant (Naam, Oorsprong, Hoogte)
            VALUES (@Naam, @Oorsprong, @Hoogte);";

            using var command = new MySqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@Naam", plant.Naam);
            command.Parameters.AddWithValue("@Oorsprong", plant.Oorsprong);
            command.Parameters.AddWithValue("@Hoogte", plant.Hoogte);

            command.ExecuteNonQuery();
        }

        public List<Dier> HaalAlleDierenOp()
        {
            var soorten = new List<Dier>();

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string selectQuery = @"
            SELECT Naam, Oorsprong, Leefgebied FROM dier;";
            using var command = new MySqlCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string naam = reader.GetString(0);
                string oorsprong = reader.GetString(1);
                string leefgebied = reader.GetString(2);

                soorten.Add(new Dier
                (
                    naam,
                    oorsprong,
                    leefgebied
                ));
            }

            return soorten;
        }
        public List<Plant> HaalAllePlantenOp()
        {
            var soorten = new List<Plant>();

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string selectQuery = @"
            SELECT Naam, Oorsprong, Hoogte FROM plant;";
            using var command = new MySqlCommand(selectQuery, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string naam = reader.GetString(0);
                string oorsprong = reader.GetString(1);
                decimal hoogte = reader.GetDecimal(2);

                soorten.Add(new Plant
                (
                    naam,
                    oorsprong,
                    hoogte
                ));
            }

            return soorten;
        }
       
    }
}
