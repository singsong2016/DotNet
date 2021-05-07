 
 -------------------------利用index可以实现参数  方法逻辑  属性  的统一------------------------- 
 public static void PropertiesDemo()
        {
            var a = new GetSet();
            Console.WriteLine(a["wang"]);
            Console.WriteLine(a[3]);
        }
        class GetSet
        {
            public string this[string s]
            {
                get => s + " hello Get Set,this is a string from get";
                set
                {

                }
            }

            public bool this[int n]
            {
                get { return true; }
                set { }
            }
        }
