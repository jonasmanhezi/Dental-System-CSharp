﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaDentaria2
{
    class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-OQO1RAI\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True";
            return Con;
        }
        
    }
}
