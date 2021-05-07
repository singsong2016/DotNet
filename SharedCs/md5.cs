        public static string Md5Password(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] pwdByte = System.Text.Encoding.Default.GetBytes(password);
            string pwdHash = BitConverter.ToString(md5.ComputeHash(pwdByte)).Replace("-", string.Empty);
            return pwdHash;
        }
