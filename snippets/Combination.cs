
        public static string Md5Password(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] pwdByte = System.Text.Encoding.Default.GetBytes(password);
            string pwdHash = BitConverter.ToString(md5.ComputeHash(pwdByte)).Replace("-", string.Empty);
            return pwdHash;
        }


        public static Dictionary<int, List<List<T>>> Combination<T>(params T[] s)
        {
            var re = new Dictionary<int, List<List<T>>>();

            var init = s.Select(t => new List<T> { t }).ToList();

            re.Add(0, init);

            for (int i = 1; i < s.Length; i++)
            {
                var ad = new List<List<T>>();

                foreach (var list in re[i - 1])
                {
                    var n = new List<T>();
                    list.ForEach(n.Add);

                    foreach (var v in s)
                    {
                        if (list.Contains(v)) continue;
                        n.Add(v);
                        break;
                    }
                    ad.Add(n);
                }
                re.Add(i, ad);
            }
            return re;
        }
    
