public static class ExtensionMethod
{
    public static bool IsNumeric<T>(this T t)
    {
        return t is int || t is double || t is float || t is decimal || t is byte || t is long || t is short || t is uint;
    }
}
