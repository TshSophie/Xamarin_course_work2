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
    [Activity(Label = "ShowLinkManScreen")]
    public class ShowLinkManScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ShowLinkMan);
            // 接收信息
            string [] values = Intent.GetStringArrayExtra("LinkMan");

            FindViewById<EditText>(Resource.Id.editName).Text = "姓名：" + values[0];
            FindViewById<EditText>(Resource.Id.editTel).Text = "电话：" + values[1];

        }
    }
}