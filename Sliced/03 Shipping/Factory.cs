using LiteDB;

namespace _03_Shipping
{
	public static class Factory
	{
		// This factory would usually be replaced by the Dependency Injection
		// framework used. E.g., as an extension of the IServiceCollection.
		//
		// In this case the project is still easy to test as LiteDB offers an
		// in-memory database which can be used by passing some configuration.
		// In other cases, a hexagonal approach - where the repository interface
		// is exposed would be easier to test.
		public static ShippingController CreateController(string dbLocation)
			=> new ShippingController(
				new ShippingService(
					new ShippingRepository(new LiteDatabase(dbLocation))));
	}
}