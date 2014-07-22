using System;
using System.Collections.Generic;

namespace ApartmentHunter
{
    static class Dictionaries
    {
        static Dictionary<string, int> dictAttributes = new Dictionary<string, int>()
        {
            {"price", 0},
            {"distance", 1},
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
		private int[] attributes;
        private string name;

		public Apartment (int[] attributes, string name)
		{
			/*price, mile from campus*/
			this.attributes = attributes;
            this.name = name;
		}

		public void setAttribute(string attribute, int newValue)
		{
			attributes [Dictionaries.getValue(attribute)] = newValue;
		}
        
        public void setName(string newName)
        {
            this.name = name;
        }
        
        public int getAttribute(string attribute)
        {
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

        public Apartment[] sort(Apartment[] apartments, string sortBy)
		{
            int attribute = Dictionaries.getValue(sortBy);

			for (i = 0; i < apartments.Length; i++) {

			}
			return apartments;
		}
    }
}
