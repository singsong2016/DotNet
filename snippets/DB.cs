
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace console
{

    public class DB
    {

        private static string constr = "data source=localhost;user id=root;password=123456;database=mysql";
     
        public static DataTable getData(string sql, out string msg)
        {
            var con = new MySqlConnection(constr);
            try
            {
                con.Open();
                var dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(dt);
                dt.TableName = "return data table";
                msg = "";
                return dt;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static int executeSql(string sql, out string msg)
        {
            var con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                int n = cmd.ExecuteNonQuery();
                msg = "";
                return n;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
