namespace Lab2
{
    public static class Logic
    {
        public static int HourRate(int hour)
        {
            if (hour >= 14 && hour < 19) return 1500;
            if ((hour >= 7 && hour < 14) || (hour >= 19 && hour < 21)) return 1000;
            return 500; // 0-7 and 21-24
        }

        public static int Total(int start, int end)
        {
            int total = 0;
            for (int h = start; h < end; h++)
                total += HourRate(h);
            return total;
        }
    }
}