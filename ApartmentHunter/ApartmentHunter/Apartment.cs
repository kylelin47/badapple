using System;

namespace ApartmentHunter
{
	public class Apartment
	{
		int[] attributes;

		public Apartment (int[] attributes)
		{
			/*price, mile from campus*/
			this.attributes = attributes;
		}

		public void setPrice(int newPrice)
		{
			attributes [0] = newPrice;
		}

		public void setMiles(int newMiles)
		{
			attributes [1] = newMiles;
		}
	}
}
