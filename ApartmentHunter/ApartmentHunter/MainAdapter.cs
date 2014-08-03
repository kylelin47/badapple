﻿using System;
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
			view.FindViewById<TextView>(Resource.Id.Text1).Text = (String) item.getAttribute("Price");
			view.FindViewById<TextView>(Resource.Id.Text2).Text = (String) item.getAttribute("Distance from Campus");
			view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
			return view;
		}
	}
}