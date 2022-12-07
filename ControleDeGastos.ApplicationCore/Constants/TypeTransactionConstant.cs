namespace ControleDeGastos.ApplicationCore.Constants
{
    public class TypeTransactionConstant
    {
        public const int Credit = 1;
        public const int Debt = 2;

        public static int GetTypeTransaction(string type)
        {
            foreach (var  field in typeof(TypeTransactionConstant).GetFields())
            {
                if ((string?)field.GetValue(null) == type)
                {
                    return Convert.ToInt32(field.Name);
                }
            }
            return 0;
        }

        public static int GetCountItems()
        {
            int count = 0;
            foreach (var field in typeof(TypeTransactionConstant).GetFields())
            {
               count++;
            }
            return count;
        }

        public static string GetDescription(int type)
        {
            string descricao = string.Empty;

            foreach (var p in typeof(TypeTransactionConstant).GetFields())
            {
                if (Convert.ToInt32(p.GetValue(null)) == type)
                {
                    descricao = p.Name;
                }
            }
            return descricao;
        }
        
    }
}
