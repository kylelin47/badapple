using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ApartmentHunter
{
	[Activity (Label = "ApartmentHunter", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		static Apartment GPlace = new Apartment ("Gainesville Place", 500, 10);
		static Apartment Estates = new Apartment ("The Estates", 300, 5);
		Apartment[] Apartments = new Apartment [] {
			GPlace,
			Estates
		};

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner);

			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				              this, Resource.Array.attributes_array, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("The attribute is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
			String sortBy = (String)spinner.GetItemAtPosition (e.Position);
			ApartmentSorter sorter = new ApartmentSorter ();
			sorter.sort (Apartments, sortBy, 0, Apartments.Length - 1);
		}
	}
}


