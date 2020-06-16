using Bogus;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDcource2020
{
    class Generator
    {
        static string conn_param = "Server=127.0.0.1; Port=5432; User Id=admin; Password=admin; Database=course2020";

        public Generator()
        {
            //GenerateFirms(40);
            //GenerateHospital(40);
            //GenerateOrders(10000);
        }

        public static List<int> getReferenceKeys(string table)
        {
            NpgsqlConnection connection = new NpgsqlConnection(conn_param);
            var select = string.Format("SELECT * FROM \"{0}\"", table);
            var dataAdapter = new NpgsqlDataAdapter(select, connection);
            var dataSet = new System.Data.DataTable();
            dataAdapter.Fill(dataSet);
            connection.Close();
            List<int> list = new List<int>();
            for (int i = 0; i < dataSet.Rows.Count; i++)
                list.Add((int)dataSet.Rows[i].ItemArray[0]);
            return list;
        }
         
        public static void GenerateFirms(int count)
        {
            Faker faker = new Faker("en");
            Faker fakeru = new Faker("ru");
            Random rand = new Random();

            NpgsqlConnection connection = new NpgsqlConnection(conn_param);
            connection.Open();

            var id_type = getReferenceKeys("Тип собственности");

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string sql = string.Format("insert into \"Фирма производитель\"" +
                            "(название, id_type, страна, год)" +
                            " values('{0}', {1}, '{2}', {3})",
                            faker.Company.CompanyName(),
                            id_type[rand.Next(0, id_type.Count - 1)],
                            fakeru.Address.Country(),
                            rand.Next(1920, 2020)
                            );
                    NpgsqlCommand com = new NpgsqlCommand(sql, connection);
                    com.ExecuteNonQuery();
                }
                catch (Exception ee)
                {

                }
            }

            connection.Close();
        }

        public static void GenerateOrders(int count)
        {
            Faker faker = new Faker("en");
            Faker fakeru = new Faker("ru");
            Random rand = new Random();

            NpgsqlConnection connection = new NpgsqlConnection(conn_param);
            connection.Open();

            var id_firm = getReferenceKeys("Фирма производитель");
            var id_group = getReferenceKeys("Фармокологическая группа");
            var id_form = getReferenceKeys("Форма выпуска");
            var id_hospital = getReferenceKeys("Больницы");

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string sql = string.Format("insert into \"Заказы\"" +
                            "(id_firm, id_group, id_form, дата, количество, цена, id_hospital)" +
                            " values({0}, {1}, '{2}', '{3}', {4}, {5}, {6})",
                            id_firm[rand.Next(0, id_firm.Count - 1)],
                            id_group[rand.Next(0, id_group.Count - 1)],
                            id_form[rand.Next(0, id_form.Count - 1)],
                            faker.Date.Between(new DateTime(1985, 1, 1), DateTime.Now),
                            rand.Next(200, 2000),
                            rand.Next(15, 150),
                            id_hospital[rand.Next(0, id_hospital.Count - 1)]
                            );
                    NpgsqlCommand com = new NpgsqlCommand(sql, connection);
                    com.ExecuteNonQuery();
                }
                catch (Exception ee)
                {

                }
            }

            connection.Close();
        }

        public static void GenerateHospital(int count)
        {
            Faker faker = new Faker("en");
            Faker fakeru = new Faker("ru");
            Random rand = new Random();

            NpgsqlConnection connection = new NpgsqlConnection(conn_param);
            connection.Open();

            var id_type = getReferenceKeys("Типы больницы");
            var id_district = getReferenceKeys("Районы города");

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string sql = string.Format("insert into Больницы" +
                            "(номер, id_type, id_district, \"год создания\", \"число мест\", \"количество врачей\", телефон)" +
                            " values({0}, {1}, {2}, {3}, {4}, {5}, '{6}')",
                            rand.Next(3, 150),
                            id_type[rand.Next(0, id_type.Count - 1)],
                            id_district[rand.Next(0, id_district.Count - 1)],
                            rand.Next(1920, 2020),
                            rand.Next(50, 1200),
                            rand.Next(12, 120),
                            faker.Phone.PhoneNumber("+38071#######")
                            );
                    NpgsqlCommand com = new NpgsqlCommand(sql, connection);
                    com.ExecuteNonQuery();
                }
                catch (Exception ee)
                {

                }
            }

            connection.Close();
        }

        public static void GenerateZavodi(int count)
        {
            Faker faker = new Faker("en");
            Faker fakeru = new Faker("ru");
            Random rand = new Random();

            var id_type = getReferenceKeys("тип собственности");
            var id_coutnry = getReferenceKeys("страны");
            var id_fuel = getReferenceKeys("вид топлива");

            NpgsqlConnection connection = new NpgsqlConnection(conn_param);
            connection.Open();

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string sql = string.Format("insert into Заводы" +
                            "(название, город, id_type, год, телефон, id_country, id_fuel, объём, цена)" +
                            " values('{0}', '{1}', {2}, {3}, '{4}', {5}, {6}, {7}, {8})",
                            faker.Company.CompanyName(),
                            fakeru.Address.City(),
                            id_type[rand.Next(0, id_type.Count - 1)],
                            rand.Next(1800, 2020),
                            faker.Phone.PhoneNumber("+38071#######"),
                            id_coutnry[rand.Next(0, id_coutnry.Count - 1)],
                            id_fuel[rand.Next(0, id_fuel.Count - 1)],
                            rand.Next(350, 2000),
                            rand.Next(2, 14)
                            );
                    NpgsqlCommand com = new NpgsqlCommand(sql, connection);
                    com.ExecuteNonQuery();
                }
                catch (Exception ee)
                {

                }
            }

            connection.Close();
        }

    }
}
