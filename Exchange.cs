namespace MONEYfy
{
    class Exchange
    {
        public static void FromAZNtoUSD(Account account)
        {
            account.Income /= 1.7;
            account.Expense /= 1.7;
            //double ?res = Program.Balance(account.Income, account.Expense);
            //res /= 1.7;
            //return res;
        }
        public static void FromAZNtoEUR(Account account)
        {
            account.Income /= 1.88;
            account.Expense /= 1.88;
        }
       
        public static void FromUSDtoAZN(Account account)
        {
            account.Income *= 1.7;
            account.Expense *= 1.7;
        }
        public static void FromEURtoAZN(Account account)
        {
            account.Income *= 1.88;
            account.Expense*= 1.88;
        }
       
    }
}