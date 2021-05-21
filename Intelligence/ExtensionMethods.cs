public static class ExtensionMethod
{
    public static bool IsNumeric<T>(this T t)
        {
            var c = t.ToString();
            var n = t is int || t is double || t is float || t is decimal || t is byte || t is long || t is short || t is uint;

            n = n || int.TryParse(c, out _) || short.TryParse(c, out _) || double.TryParse(c, out _) || long.TryParse(c, out _) || uint.TryParse(c, out _) || byte.TryParse(c, out _) || float.TryParse(c, out _);

            return n;
        }
}


enum MeaningOfNumber
{
    Amount, Indexer, Degree, Length, Position, Place, AgreementMeaning
}
