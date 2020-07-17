namespace BoardGame.Infrastructure.Exceptions
{
    public static class Throw
    {
        public static void IsNull(object argument, string text)
        {
            if (argument == null)
            {
                throw new NullException(text);
            }
        }
    }
}
