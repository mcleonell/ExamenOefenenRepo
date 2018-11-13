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
        /// <param name="_orderBy">Colum which the returned values will be ordered by (tpyicaly ID) </param>
        /// <returns></returns>
        public ArrayList GetColumn(string _table, string _column, string _orderBy)
        {
            // TODO - Make it accept more columns at once

            ArrayList tempList = new ArrayList();

            SqlConnection con = GetSqlConnectiont();

            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT " + _column + " FROM " + _table + " ORDER BY " + _orderBy, con);

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

        /// <summary>
        /// Adds string input to selected column of table in database
        /// </summary>
        /// <param name="_table">Table you want to put data in</param>
        /// <param name="_column">Column you want to put data in</param>
        /// <param name="_input">User input (Value to add to database)</param>
        /// <returns></returns>
        public void AddToColumn(string _table, string _column, string _input)
        {
            // TODO - Make it accept more multiple values per column && multiple columns at once

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
