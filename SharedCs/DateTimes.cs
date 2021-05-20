----------------pase  any format of date time--------------

var format = "ddMMMyy";

var a = DateTime.ParseExact("08MAY21", format, CultureInfo.InvariantCulture);

Console.WriteLine(a);
