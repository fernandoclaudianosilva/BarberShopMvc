namespace BarberShopMvc.Services.Excptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message):base(message)
        {
            
        }
    }
}
