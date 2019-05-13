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

namespace _04_Xamarin
{
    [Activity(Label = "ShowMessageScreen")]
    public class ShowMessageScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ShowMessage);
            // 接收信息
            string[] values = Intent.GetStringArrayExtra("Message");

            Toast.MakeText(this, values[0], ToastLength.Long).Show();

            FindViewById<TextView>(Resource.Id.title).Text = values[0];
            FindViewById<TextView>(Resource.Id.detail).Text = values[1];
            FindViewById<ImageView>(Resource.Id.image).SetImageDrawable(GetDrawable(int.Parse(values[2])));
            FindViewById<TextView>(Resource.Id.from).Text = "From:" + values[3];
        }
    }
}