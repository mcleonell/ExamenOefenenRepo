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


namespace ExamenOefenen
{
    class Database
    {
        /// <summary>
        /// Deletes record(s) from table with given condition
        /// </summary>
        /// <param name="_table">Table you want to delete record(s) from</param>
        /// <param name="_condition">Condition</param>
        public static void Delete(string _table, string _condition)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM " + _table + " WHERE " + _condition, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns true if input exists in selected column of table in database
        /// SELECT COUNT(1) FROM _table WHERE _column = '_input'
        /// </summary>
        /// <param name="_table">Table you want to check</param>
        /// <param name="_column">Column you want to check</param>
        /// <param name="_input">User input (value to check)</param>
        /// <returns></returns>
        public bool Exists(string _table, string _column, string _input)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(1) from " + _table + " where " + _column + " = @Input", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input;
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        /// <summary>
        /// Returns true if input exists in selected column of table in database
        /// SELECT COUNT(1) FROM _table WHERE _column = '_input' AND _culumnID = _id
        /// </summary>
        /// <param name="_table">Table you want to check</param>
        /// <param name="_column">Column you want to check</param>
        /// <param name="_input">User input (value to check)</param>
        /// <param name="_columnID">ID column name you want to check with</param>
        /// <param name="_id">ID you want to check with</param>
        /// <returns></returns>
        public bool Exists(string _table, string _column, string _input, string _columnID, int _id)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(1) from " + _table + " where " + _column + " = @Input AND " + _columnID + " = @ID", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _id;
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Returns true if input exists in selected column of table in database (Not case sensitive)
        /// SELECT COUNT(1) FROM _table WHERE lower(_column) = '_input.ToLower()'
        /// </summary>
        /// <param name="_table">Table you want to check</param>
        /// <param name="_column">Column you want to check</param>
        /// <param name="_input">User input (value to check)</param>
        /// <returns></returns>
        public bool ExistsAllCase(string _table, string _column, string _input)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(1) from " + _table + " where lower(" + _column + ") = @Input", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input.ToLower();
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        /// <summary>
        /// Returns true if input exists in selected column of table in database (Not case sensitive)
        /// SELECT COUNT(1) FROM _table WHERE lower(_column = '_input') AND _culumnID = _id
        /// </summary>
        /// <param name="_table">Table you want to check</param>
        /// <param name="_column">Column you want to check</param>
        /// <param name="_input">User input (value to check)</param>
        /// <param name="_columnID">ID column name you want to check with</param>
        /// <param name="_id">ID you want to check with</param>
        /// <returns></returns>
        public bool ExistsAllCase(string _table, string _column, string _input, string _columnID, int _id)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT count(1) from " + _table + " where lower(" + _column + ") = @Input AND " + _columnID + " = @ID", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input.ToLower();
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _id;
                    int count = (int)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        
        /// <summary>
        /// Returns a ArrayList of column items retrieved from database
        /// SELECT _column FROM _table WHERE _equation
        /// </summary>
        /// <param name="_table">Table from which you want to retrieve data</param>
        /// <param name="_column">Column from which you want to retrieve data</param>
        /// <param name="_condition">Narrow down the returned list use 1 = 1 for all results for column</param>
        /// <returns></returns>
        public ArrayList GetColumn(string _table, string _column, string _condition)
        {
            // TODO - Make it accept more columns at once

            ArrayList tempList = new ArrayList();

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT " + _column + " FROM " + _table + " WHERE " + _condition, con);

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
        /// INSERT INTO _table(_column) VALUES(_input)
        /// </summary>
        /// <param name="_table">Table you want to put data in</param>
        /// <param name="_column">Column you want to put _input in</param>
        /// <param name="_input">User input (value to add to database)</param>
        /// <returns></returns>
        public static void Insert(string _table, string _column, string _input)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO " + _table + " (" + _column + ") VALUES (@Input)", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Adds string input to selected column of table in database
        /// INSERT INTO _table(_column,_idColumn) VALUES(_input, _id)
        /// </summary>
        /// <param name="_table">Table you want to put data in</param>
        /// <param name="_column">Column you want to put _input in</param>
        /// <param name="_idColumn">Columnt you want to put _id in</param>
        /// <param name="_input">User input1 (first value to add to database)</param>
        /// <param name="_id">int ID (Integer value to add to database)</param>
        /// <returns></returns>
        public static void Insert(string _table, string _column, string _idColumn, string _input, int _id)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO " + _table + " (" + _column + "," + _idColumn + ") VALUES (@Input, @ID)", con))
                {
                    cmd.Parameters.Add("@Input", SqlDbType.VarChar).Value = _input;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Adds string input to selected column of table in database + ID
        /// INSERT INTO _table(_column1, _column2, _idColumn) VALUES(_input1, _input2, _id)
        /// </summary>
        /// <param name="_table">Table you want to put data in</param>
        /// <param name="_column1">Column you want to put _input1 in</param>
        /// <param name="_column2">Column you want to put _input2 in</param>
        /// <param name="_idColumn">Column you want to put _id in</param>
        /// <param name="_input1">User input1 (first value to add to database)</param>
        /// <param name="_input2">User input2 (second value to add to database)</param>
        /// <param name="_id">int ID (Integer value to add to database)</param>
        /// <returns></returns>
        public static void Insert(string _table, string _column1, string _column2, string _idColumn, string _input1, string _input2, int _id)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO " + _table + " (" + _column1 + "," + _column2 + "," + _idColumn + ") VALUES (@Input1, @Input2, @ID)", con))
                {
                    cmd.Parameters.Add("@Input1", SqlDbType.VarChar).Value = _input1;
                    cmd.Parameters.Add("@Input2", SqlDbType.VarChar).Value = _input2;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = _id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
