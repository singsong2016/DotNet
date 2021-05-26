 static void Main(string[] args)
  {
      var a = new MyClass() { Age = 10 };

      var b = a + 20;

      Console.WriteLine(b.Age);
  }

  class MyClass
  {
      public int Age { get; set; }
      public static MyClass operator +(MyClass a, int b)
      {
          return new MyClass() { Age = a.Age + b };
      }
  }
