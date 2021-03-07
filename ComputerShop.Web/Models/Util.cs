namespace ComputerShop.Web.Models
{
    public static class Util
    {
        public static string GetPluralString(int count, string one, string other)
        {
            return count + " " + (count == 1 ? one : other);
        }
    }
}