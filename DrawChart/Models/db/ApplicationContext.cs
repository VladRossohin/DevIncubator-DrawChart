using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace DrawChart.Models.db
{
    public class ApplicationContext 
    {

        public DbSet<PointViewModel> Points { get; set; }
        public DbSet<RequestViewModel> UserData { get; set; }
        public MySqlConnection connection { get; set; }
        
        public ApplicationContext()
        {
            connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=chartdb");
        }

        public void OpenConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed) {
                connection.Open();
            }

        }

        public void closeConnection()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

    }
}