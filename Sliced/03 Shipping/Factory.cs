namespace _03_Shipping
{
    public static class Factory
    {
        public static IShippingService CreateShippingService()
        {
            return new ShippingService();
        }
    }
}
