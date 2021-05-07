
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace console
{

    public class DB
    {

        private static readonly string db = "data source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = x)(PORT = x)))   (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = x) )  );user id=x; password=x; persist security info=true;

        private static OracleConnection con=new OracleConnection(db);

        public static Task<DataTable> GetData(string sql)
        {
            try
            {
                con.Open();
                var dt = new DataTable();
                OracleDataAdapter da = new OracleDataAdapter(sql, con);
                da.Fill(dt);
                dt.TableName = "return data table";
                return Task.FromResult(dt);
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

        public static Task<int> ExecuteSql(string sql)
        {

            try
            {
                con.Open();
                var cmd = new OracleCommand(sql, con);
                int n = cmd.ExecuteNonQuery();
                return Task.FromResult(n);
            }
            catch (Exception e)
            {
                return Task.FromResult(0);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
