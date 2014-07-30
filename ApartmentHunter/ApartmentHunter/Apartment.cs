using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApartmentHunter
{
    static class Dictionaries
    {
        static Dictionary<string, int> dictAttributes = new Dictionary<string, int>()
        {
            {"Price", 0},
			{"Distance from Campus", 1},
        };
        public static int getValue(string value)
        {
            // Try to get the result in the static Dictionary
            if (dictAttributes.ContainsKey(value))
            {
                return dictAttributes[value];
            }
            else
            {
                return 0;
                /*error handling is hard*/
            }
        }
    }

	public class Apartment
	{
		private int[] attributes = new int[5];
        private string name;

		public Apartment (string name, int[] attributes)
		{
			/*price, mile from campus*/
			this.attributes = attributes;
            this.name = name;
		}
        
        public Apartment (string name, int price, int distance)
        {
            attributes[0] = price;
            attributes[1] = distance;
            this.name = name;
        }

		public void setAttribute(string attribute, int newValue)
		{
			attributes [Dictionaries.getValue(attribute)] = newValue;
		}
        
        public void setName(string name)
        {
            this.name = name;
        }
        
        public IComparable getAttribute(string attribute)
        {
            if (attribute == "name")
            {
                return name;
            }
            return attributes [Dictionaries.getValue(attribute)];
        }
        
        public string getName()
        {
            return name;
        }
	}
    
    public class ApartmentSorter
    {   
        public ApartmentSorter()
        {
            /*still thinking on what this class will do*/
        }

        public void sort(Apartment[] apartments, string sortBy, int left, int right)
		{
            int i = left, j = right;

            IComparable pivot = apartments[(left + right) / 2].getAttribute(sortBy);

            while (i <= j)
            {
                while (apartments[i].getAttribute(sortBy).CompareTo(pivot) < 0)
                {
                    i++;
                }
 
                while (apartments[j].getAttribute(sortBy).CompareTo(pivot) > 0)
                {
                    j--;
                }
                if (i <= j)
                {
                    Apartment tmp = apartments[i];
                    apartments[i] = apartments[j];
                    apartments[j] = tmp;
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
            {
                sort(apartments, sortBy, left, j);
            }
 
            if (i < right)
            {
                sort(apartments, sortBy, i, right);
            }
		}
    }
}
