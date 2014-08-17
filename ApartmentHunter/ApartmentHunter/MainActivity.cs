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
		static Apartment GPlace = new Apartment ("Gainesville Place", 480, 10, 2130837504);
		static Apartment Estates = new Apartment ("The Estates", 550, 7, 2130837504);
		static Apartment CClub = new Apartment ("Campus Club", 330, 3, 2130837504);
		static Apartment Keys = new Apartment ("Keys", 600, 4, 2130837504);

		Apartment[] Apartments = new Apartment [] {
			GPlace,
			Estates,
			CClub,
			Keys
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

			ListView listView;
			listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
			// populate the listview with data
			listView.Adapter = new MainAdapter(this, Apartments);
			listView.ItemClick += OnListItemClick;
		}

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			ApartmentSorter sorter = new ApartmentSorter ();
			String sortBy = (String)spinner.GetItemAtPosition (e.Position);
			sorter.sort (Apartments, sortBy, 0, Apartments.Length - 1);

			ListView myListView = FindViewById<ListView> (Resource.Id.List);
			((MainAdapter)myListView.Adapter).NotifyDataSetChanged ();
		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var listView = sender as ListView;
			var t = Apartments[e.Position];
			Android.Widget.Toast.MakeText(this, (String) t.getAttribute("name"), Android.Widget.ToastLength.Short).Show();
		}
	}
}
