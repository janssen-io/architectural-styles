using LiteDB;

namespace _03_Shipping
{
    public static class Factory
    {
        public static IShippingService CreateShippingService(string dbLocation)
            => new ShippingService(
                new ShippingRepository(
                    new LiteDatabase(dbLocation)));
    }
}
