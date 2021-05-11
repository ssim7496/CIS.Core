using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CIS.Core.Services
{
    public static class DBHelper
    {
        //private readonly static string CONNECTION_STRING = "Data Source=Siyo-HP; Initial Catalog=CIS; Integrated Security=true;";
        private static string CONNECTION_STRING;
        public static void SetConnectionString(string conn)
        {
            CONNECTION_STRING = conn;
        }
                
        //=============================================================================================================================
        #region ExecuteParamerizedSelectCommand()
        internal static DataTable ExecuteParamerizedSelectCommand(string commandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;

                    cmd.Parameters.AddRange(param);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }

            return table;
        }
        #endregion
        //=============================================================================================================================
        #region ExecuteSelectCommand()
        internal static DataTable ExecuteSelectCommand(string commandName, CommandType cmdType)
        {
            DataTable table = null;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }
        #endregion
        //=============================================================================================================================
        #region ExecuteNonQuery()
        internal static int ExecuteNonQuery(string commandName, CommandType cmdType, SqlParameter[] param)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;
                    cmd.Parameters.AddRange(param);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        internal static int ExecuteNonQuery(string commandName, CommandType cmdType)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }
        #endregion
        //=============================================================================================================================
        #region ExecuteScalar()
        internal static int ExecuteScalar(string commandName, CommandType cmdType, SqlParameter[] param)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;
                    cmd.Parameters.AddRange(param);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    result = (int)cmd.ExecuteScalar();
                }
            }

            return result;
        }

        internal static int ExecuteScalar(string commandName, CommandType cmdType)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandName;
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 600000;

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    result = (int)cmd.ExecuteScalar();
                }
            }

            return result;
        }
        #endregion
        //=============================================================================================================================
    }
}
