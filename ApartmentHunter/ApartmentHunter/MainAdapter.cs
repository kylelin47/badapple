using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ApartmentHunter
{
	public class MainAdapter : BaseAdapter {
		Apartment[] items;
		Activity context;
		public MainAdapter(Activity context, Apartment[] items)
			: base()
		{
			this.context = context;
			this.items = items;
		}
		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}
		public override long GetItemId(int position)
		{
			return position;
		}

		public override int Count
		{
			get { return items.Length; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);

			view.FindViewById<TextView>(Resource.Id.Heading).Text = item.getAttribute("Name").ToString();
			view.FindViewById<TextView>(Resource.Id.Text1).Text = "Price: $" + item.getAttribute("Price").ToString();
			view.FindViewById<TextView> (Resource.Id.Text2).Text = "Distance: " +
																   item.getAttribute ("Distance from Campus").ToString() +
																   " miles";
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);

			Button b = view.FindViewById<Button> (Resource.Id.Button1);
			b.Tag = position;
			b.Click -= SwitchScreen;
			b.Click += SwitchScreen;
			return view;
		}
		void SwitchScreen (object sender, EventArgs e)
		{
			int position = (int)((Button)sender).Tag;
			var item = items [position];
			var intent = new Intent (context, typeof(ExpandedApartmentActivity));
			intent.PutExtra ("name", item.getName ());
			context.StartActivity (intent);
		}
	}
}