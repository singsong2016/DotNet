 public  class dataMethods
    {
        /// <summary>
        /// md5 encrypt
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Md5Password(string password)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] pwdByte = System.Text.Encoding.Default.GetBytes(password);
            string pwdHash = BitConverter.ToString(md5.ComputeHash(pwdByte)).Replace("-", string.Empty);
            return pwdHash;
        }


        #region combination
        public static void combinationDemo()
        {
            var a = Combination("a", "b", "c");

            foreach (var item in a.Keys)
            {
                Console.Write(item + ":");
                foreach (var i in a[item])
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }
        public static Dictionary<int, List<string>> Combination(params string[] s)
        {
            var re = new Dictionary<int, List<string>>();

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    re.Add(i, s.ToList());
                }

                if (i > 0)
                {
                    var ad = new List<string>();
                    foreach (var item in re[i - 1])
                    {
                        foreach (var j in s)
                        {
                            if (!item.Contains(j))
                            {
                                ad.Add(item + j);
                            }
                        }
                    }
                    re.Add(i, ad);
                }
            }

            return re;
        } 
        #endregion
    }
