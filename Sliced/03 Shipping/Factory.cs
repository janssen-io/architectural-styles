namespace _03_Shipping
{
	public static class Factory
	{
		public static ShippingController CreateController()
			=> new ShippingController(
				new ShippingService(
					new ShippingRepository()));
	}
}