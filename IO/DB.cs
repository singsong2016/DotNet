    public class DB
    {
         //nuget: Oracle.ManagedDataAccess.Client
        private static readonly string db = "data source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = x)(PORT = x)))   (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = x) )  );user id=x; password=x; persist security info=true;

        private static OracleConnection con=new OracleConnection(db);

        public static Task<DataTable> GetData(string sql)
        {
            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }

            
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
          if (string.IsNullOrEmpty(sql))
            {
                return null;
            }

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
--------------------------------------SQL  server------------------------------------
    //nuget: system.data.sqlclient
       private static readonly string db =
            "data source=10.10.2.122;user id=sa; password=sql@123; persist security info=true;Initial Catalog=jkey";

        private static readonly SqlConnection con = new SqlConnection(db);

        public static Task<DataTable> GetData(string sql)
        {
            try
            {
                con.Open();
                var dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
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
                var cmd = new SqlCommand(sql, con);
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



