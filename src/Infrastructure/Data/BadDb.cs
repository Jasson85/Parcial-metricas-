using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data
{
    public static class BadDb
    {
        // El campo no debe ser público ni modificable directamente.
        // Se vuelve private para que no sea accesible desde afuera.       
        private static string _connectionString;

        // Se crea una propiedad pública controlada
        // Esta propiedad permite leer el valor pero no permite modificarlo libremente.
        // Con esto no expone un campo mutable.
        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        
        public static int ExecuteNonQueryUnsafe(string sql)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static IDataReader ExecuteReaderUnsafe(string sql)
        {
            var conn = new SqlConnection(ConnectionString);
            var cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader();
        }
    }
}
