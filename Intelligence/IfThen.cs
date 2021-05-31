
//If Then 类问题推理
static void Main(string[] args)
{
    var inputStr = "g:if rain then ground wet," +  //输入格式：g代表given条件，if then/reflect 代表知识
                   "if ground wet reflect rain," +
                   "today ground wet;" +
                   "f:today rain or not";  //f:代表find求

    Console.WriteLine(IfThen(inputStr));
}

private static string IfThen(string input)
{
    var given = input.Substring(2, input.IndexOf("f:", StringComparison.Ordinal)).Split(',');//已知

    var knowledge = new Dictionary<string, string>();//知识部分 if then/reflect
    int ifProblem = 0;
    foreach (var s in given)
    {
        if (s.StartsWith("if"))//knowledge
        {
            ifProblem = 1;//代表这是if then类推理问题
            AddKnowledge("then", s, knowledge);

            AddKnowledge("reflect", s, knowledge);
        }
        else//condition
        {
            if (ifProblem == 1)//如果是if then类问题
            {
                foreach (var keyValuePair in knowledge)
                {
                    if (s.Contains(keyValuePair.Key))//如果condition中有if中的条件，自动得到if中的结果
                    {
                        return keyValuePair.Value;
                    }
                }
            }

        }
    }

    //var find = input.Substring(input.IndexOf("f:", StringComparison.Ordinal) + 2);//求

    return "no result find";
}

private static void AddKnowledge(string c, string s, Dictionary<string, string> knowledge)
{
    if (s.Contains(c))
    {
        var a = s.Substring(3, s.IndexOf(c) - 3).Trim(); //if 长度3
        var b = s.Substring(s.IndexOf(c) + c.Length).Trim();
        knowledge.Add(a, b);
    }
}
