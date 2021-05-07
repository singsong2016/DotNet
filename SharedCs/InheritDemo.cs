
------------实际使用queue的时候可能需要enqueue的时候根据已有数量dequeue， 并求平均值，比如数据监控类应用---------

    public static void InheritDemo()
        {
            var a = new Qs<int>();

            for (var i = 0; i < 10; i++)
            {
                a.Enqueue(i);
            }

            Console.WriteLine(a.Average());
        }
        
        private class Qs<T> : Queue
        {
            public override void Enqueue(object obj)
            {
                base.Enqueue(obj);
                if (base.Count > 4)
                {
                    base.Dequeue();
                }
            }
            public int Average()
            {
                int s = 0;

                try
                {
                    foreach (var o in base.ToArray())
                    {
                        s += (int)o;
                    }
                    return s / base.Count;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
