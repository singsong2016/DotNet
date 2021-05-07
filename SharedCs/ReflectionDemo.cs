   -------------------利用反射对对象的property进行取值 赋值操作
   public static void GetSetReflectionValues()
        {
            var a = new bool[2];
            var propers = DemoClass.GetType().GetProperties();//same to fields
            for (int i = 0; i < propers.Length; i++)
            {
                a[i] = Convert.ToBoolean(propers[i].GetValue(DemoClass));
                propers[i].SetValue(DemoClass, false);
            }


        }

        public static readonly ReflectionDemoClass DemoClass = new ReflectionDemoClass() { GoodBad = false, Expensive = true };

        public class ReflectionDemoClass
        {
            public bool GoodBad { get; set; }
            public bool Expensive { get; set; }
        }
