namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            if (count % 100 / 10 != 1)
            {
                if (count % 10 == 1)
                {
                    return "рубль";
                }
                else if (count % 10 > 1 && count % 10 < 5)
                {
                    return "рубля";
                }
            }
            return "рублей";
        }
	}
}