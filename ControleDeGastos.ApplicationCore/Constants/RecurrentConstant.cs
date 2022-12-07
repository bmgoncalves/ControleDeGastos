namespace ControleDeGastos.ApplicationCore.Constants
{
    public class RecurrentConstant
    {
        public const int None = 0;

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

        public static string GetDescription(int type)
        {
            string descricao = string.Empty;

            foreach (var p in typeof(RecurrentConstant).GetFields())
            {
                if (Convert.ToInt32(p.GetValue(null)) == type)
                {
                    descricao = p.Name;
                }
            }
            return descricao;
        }

        public static int GetCountItems()
        {
            int count = 0;  
            foreach (var p in typeof(RecurrentConstant).GetFields())
            {
                count++;
            }
            return count;
        }


        public static DateTime GetData(int type)
        {

            foreach (var p in typeof(RecurrentConstant).GetFields())
            {
                if (Convert.ToInt32(p.GetValue(null)) == type)
                {
                    return Convert.ToInt32(p.GetValue(null)) switch
                    {
                        0 => DateTime.Now.AddDays(1),
                        1 => DateTime.Now.AddDays(7),
                        2 => DateTime.Now.AddDays(15),
                        3 => DateTime.Now.AddMonths(1),
                        4 => DateTime.Now.AddMonths(6),
                        _ => DateTime.Now,
                    };
                }
            }
            return DateTime.Now;

        }



    }
}
