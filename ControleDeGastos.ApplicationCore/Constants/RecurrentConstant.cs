namespace ControleDeGastos.ApplicationCore.Constants
{
    public class RecurrentConstant
    {
        /// <summary>
        /// Semanal
        /// </summary>
        public const int Weekly = 1;
        /// <summary>
        /// Quinzenal
        /// </summary>
        public const int Fortnightly = 2;
        /// <summary>
        /// Mensal
        /// </summary>
        public const int Monthly = 3;

        /// <summary>
        /// Bimestral
        /// </summary>
        public const int Bimonthly = 4;


        public static DateTime GetData(string sit)
        {
            foreach (var field in typeof(RecurrentConstant).GetFields())
            {
                if ((string)field.GetValue(null) == sit)
                {
                    switch (Convert.ToInt32(field.Name))
                    {
                        case 1:
                            return DateTime.Now.AddDays(7);
                        case 2:
                            return DateTime.Now.AddDays(15);
                        case 3:
                            return DateTime.Now.AddMonths(1);
                        case 4:
                            return DateTime.Now.AddMonths(6);
                        default:
                            return DateTime.Now;
                    }
                }
            }
            return DateTime.Now;
        }
    }
}
