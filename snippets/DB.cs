
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace console
{

    public class DB
    {

        private static readonly string db = "data source=data.db";

        private static SQLiteConnection con=new SQLiteConnection(db);

        public static DataTable GetData(string sql)
        {
            try
            {
                con.Open();
                var dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con);
                da.Fill(dt);
                dt.TableName = "return data table";
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static int ExecuteSql(string sql)
        {
          
            try
            {
                con.Open();
                var cmd = new SQLiteCommand(sql, con);
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
