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
                if ((string)field.GetValue(null) == type)
                {
                    return Convert.ToInt32(field.Name);
                }
            }
            return 0;
        }
    }
}
