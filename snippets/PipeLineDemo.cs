using System;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {

            double input = 1024.1024;

            // 构建并使用管道
            var result = input.Step(new DoubleToIntStep()).Step(new IntToStringStep());
            Console.WriteLine(result);
        }
    }

    public interface IPipelineStep<TInput, TOutput>
    {
        TOutput Proc(TInput input);
    }

    public class DoubleToIntStep : IPipelineStep<double, int>
    {
        public int Proc(double input)
        {
            return Convert.ToInt32(input);
        }
    }

    public class IntToStringStep : IPipelineStep<int, string>
    {
        public string Proc(int input)
        {
            return input.ToString();
        }
    }

    public static class Pi      //扩展方法   只能写在static一个单独类中
    {
        public static OUTPUT Step<INPUT, OUTPUT>(this INPUT input, IPipelineStep<INPUT, OUTPUT> st)
        {
            return st.Proc(input);
        }
    }
}
