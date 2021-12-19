namespace MekajikiPtyPlayer
{
    public static class Utils
    {
        public static string GetReadableSize(long length)
        {
            if (length < 1024)
            {
                return length + "B";
            }

            if (length < 1024 * 1024)
            {
                return length / 1024d + "KiB";
            }
            
            if (length < 1024 * 1024 * 1024)
            {
                return length / (1024d * 1024d) + "MiB";
            }

            return length / (1024d * 1024d * 1024d) + "GiB";
        }
    }
}