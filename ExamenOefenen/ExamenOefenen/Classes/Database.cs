using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ExamenOefenen
{
    class Database
    {
        #region connection
        public SqlConnection GetSqlConnectiont()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
            return con;
        }
        #endregion

        #region readandwrite
        #endregion

        public Database()
        {
        }


        /// <summary>
        /// Returns a ArrayList of column items retrieved from database
        /// </summary>
        /// <param name="_table">Table from which you want to retrieve data</param>
        /// <param name="_column">Column from which you want to retrieve data</param>
        /// <returns></returns>
        public ArrayList GetColumn(string _table, string _column)
        {
            // TODO - Make it accept more columns

            ArrayList tempList = new ArrayList();

            SqlConnection con = GetSqlConnectiont();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT " + _column + " FROM " + _table, con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tempList.Add(reader.GetValue(0));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
                return tempList;
            }

        }
        public void AddToColumn(string _table, string _column, string _input)
        {
            SqlConnection con = GetSqlConnectiont();
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into " + _table + " ("+_column+") values (@Input)", con);
                cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
