﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Ex10.Util
{
    class ConectaDB
    {
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "infiniteloop0";
        private static string dataBaseName = "Concessionaria_DB";

        public static NpgsqlConnection getConexao()
        {
            try
            {
                string stgConexao = String.Format("Server = {0}; Port ={1}; User Id={2}; Password={3}; Database={4};", serverName, port, userName, password, dataBaseName);

                NpgsqlConnection npsqlConnection = new NpgsqlConnection(stgConexao);

                npsqlConnection.Open();

                return npsqlConnection;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
   
}
