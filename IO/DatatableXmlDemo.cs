#region datatable xml  的互转，用于运行数据的保存和加载

/// <summary>
/// 将DataTable的内容写入到XML文件中
/// </summary>
/// <param name="dt">数据源</param>
/// <param name="address">XML文件地址</param>
public static bool SaveDatatableToXml(DataTable dt, string address)
{
    try
    {
        //如果文件DataTable.xml存在则直接删除
        if (File.Exists(address))
        {
            File.Delete(address);
        }

        dt.TableName = "a table";

        dt.WriteXml(address, XmlWriteMode.WriteSchema);
        //XML文档创建结束
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
    return true;
}

/// <summary>
/// 从XML文件中读取一个DataTable
/// </summary>
/// <param name="dt">数据源</param>
/// <param name="address">XML文件地址</param>
/// <returns></returns>
public static DataTable ReadXmlToDataTable(string address)
{

    try
    {
        if (!File.Exists(address))
        {
            throw new Exception("文件不存在!");
        }
        else
        {
            var s = new DataTable();
            s.ReadXml(address);
            return s;
        }

    }
    catch (Exception e)
    {
        return new DataTable();
    }

}
#endregion


-----------------------------------------------------文件大小判断--------------------------------------------------------------------------
3.  File.AppendAllText("a.txt", "hello world");

    var a = new FileInfo("a.txt");

    Console.WriteLine(a.Length);
-------------------------------------------------------------------------------------------------------------------------------
