
-----图论算法，为图论问题的节点新建其描述类：1.节点名称string  2.节点能连接的点和其值的dictionary 以及定义两个节点相加的operator
-----在此基础上计算从A到终点的最大或最低路径，或满足某个条件的路径问题
-----------------------------------------------------B-----------------
--------------------------------------------------A<--->D--------------
-----------------------------------------------------C----------------

static void Main(string[] args)
    {
        var A = new Path { StartPoint = "A" };
        A.AddPaths.Add("B", 1);
        A.AddPaths.Add("C", 2);

        var B = new Path { StartPoint = "B" };
        B.AddPaths.Add("C", 3);
        B.AddPaths.Add("D", 4);

        var C = new Path() { StartPoint = "C" };
        C.AddPaths.Add("B", 3);
        C.AddPaths.Add("D", 5);

        var p1 = A + B;
        var p2 = A + C;


        foreach (var keyValuePair in p1.AddPaths)
        {
            Console.WriteLine(p1.StartPoint + " " + keyValuePair);
        }

        foreach (var keyValuePair in p2.AddPaths)
        {
            Console.WriteLine(p2.StartPoint + " " + keyValuePair);
        }

    }

    class Path
    {
        public string StartPoint { get; set; } = nameof(StartPoint);
        public Dictionary<string, int> AddPaths { get; set; } = new Dictionary<string, int>();

        public static Path operator +(Path a, Path b)
        {
            var combinedPath = new Path();
            combinedPath.StartPoint = a.StartPoint;
            foreach (var keyValuePair in a.AddPaths)
            {
                foreach (var bAddPath in b.AddPaths)
                {
                    if (keyValuePair.Key != bAddPath.Key && keyValuePair.Key == b.StartPoint)
                    {
                        combinedPath.AddPaths.Add(keyValuePair.Key + bAddPath.Key, keyValuePair.Value + bAddPath.Value);
                    }

                }
            }
            return combinedPath;
        }
    }
