using System;

namespace _03_Shipping
{
	public interface IShippingController
	{
		Guid Ship(Guid productId);
	}
}