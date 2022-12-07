namespace ControleDeGastos.ApplicationCore.Constants
{
    public class StatusEntryConstant
    {
        public const int Paid = 1;
        public const int Received = 2;
        public const int Delayed = 3;

        public static int GetId(string description)
        {
            foreach (var field in typeof(StatusEntryConstant).GetFields())
            {
                if ((string?)field.GetValue(null) == description)
                {
                    return Convert.ToInt32(field.Name);
                }
            }
            return 0;
        }

        public static int GetCountItems()
        {
            int count = 0;
            foreach (var field in typeof(StatusEntryConstant).GetFields())
            {
                count++;
            }
            return count;
        }

        public static string GetDescription(int id)
        {
            string description = string.Empty;

            foreach (var p in typeof(StatusEntryConstant).GetFields())
            {
                if (Convert.ToInt32(p.GetValue(null)) == id)
                {
                    description = p.Name;
                }
            }
            return description;
        }



    }
}
