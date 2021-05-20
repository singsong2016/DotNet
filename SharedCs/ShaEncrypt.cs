/// <summary>
/// SHA512加密
/// </summary>
public static string Sha512Encode(string source)
{
    string result = "";
    byte[] buffer = Encoding.UTF8.GetBytes(source);//UTF-8 编码
    //64字节,512位
    SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
    byte[] h5 = SHA512.ComputeHash(buffer);
    result = BitConverter.ToString(h5).Replace("-", string.Empty);
    return result.ToLower();
}

/// <summary>
/// SHA256加密
/// </summary>
public string Sha256HashFromString(string strData)
{
    byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(strData);
    try
    {
       SHA256 sha256 = new SHA256CryptoServiceProvider();
       byte[] retVal = sha256.ComputeHash(bytValue);
       StringBuilder sb = new StringBuilder();
       for (int i = 0; i < retVal.Length; i++)
       {
           sb.Append(retVal[i].ToString("x2"));
       }
       return sb.ToString();
    }
    catch (Exception ex)
    {
       throw new Exception(ex.Message);
    }
}

