namespace BarberShopMvc.Services.Excptions
{
    public class DbConcurrencyException :ApplicationException
    {
        public DbConcurrencyException(string message):base(message)
        {
            
        }
    }
}
