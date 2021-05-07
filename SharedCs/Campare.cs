        #region list元素根据元素属性排序方法 
        class Comparer
        {
            public static void CompareDemo()
            {
                var a = new List<MyClass>
                {
                    new MyClass() {age = 20, name = "zhang"}, new MyClass() {age = 10, name = "wang"}
                };


                a.Sort((x, y) => x.age.CompareTo(y.age));

                foreach (var myClass in a)
                {
                    Console.WriteLine(myClass.age);
                }
            }

            class MyClass
            {
                public int age;
                public string name;
            }
        }


        #endregion
