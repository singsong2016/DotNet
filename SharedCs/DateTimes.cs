----------------pase  any format of date time--------------

var format = "ddMMMyy";

var a = DateTime.ParseExact("08MAY21", format, CultureInfo.InvariantCulture);

Console.WriteLine(a);


-------------------------try parse  exact-----------------
  CultureInfo enUS = new CultureInfo("en-US");
  DateTime d;
  var a = DateTime.TryParseExact("202105", "yyyyMMdd", enUS, DateTimeStyles.None, out d);

  Console.WriteLine(d.Year);//true:2021  false:1
