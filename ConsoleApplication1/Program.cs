using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace SelectSample
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var connection = new OleDbConnection(
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database11.accdb"))
            {
                Console.WriteLine(connection.State.ToString());
                connection.Open();

                Console.WriteLine(connection.State.ToString());
                var command = new OleDbCommand("SELECT * FROM Departments",
                                                connection);

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(string.Format("{0};\t{1}",
                            reader.GetString(1),
                            reader.GetString(2)));
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
