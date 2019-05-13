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
    [Activity(Label = "ListView_2_Screen", MainLauncher = false)]
    public class ListView_2_Screen : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //SetContentView(Resource.Layout.ListView_2_);
            // 1. 根据需要定义ListView每一行所实现的布局

            // 2. 定义一个javaDictionary构成的列表集合，将数据以键值对的方式存放在里面
            List<IDictionary<string, object>> list = new List<IDictionary<string, object>>();
            JavaDictionary<string, object> item1 = new JavaDictionary<string, object>();
            item1.Add("img", Resource.Drawable.img0);
            item1.Add("title", "中通快递");
            item1.Add("desc", "您的中通快递到啦");

            JavaDictionary<string, object> item2 = new JavaDictionary<string, object>();
            item2.Add("img", Resource.Drawable.img1);
            item2.Add("title", "全一快递");
            item2.Add("desc", "您的全一快递到啦");

            JavaDictionary<string, object> item3 = new JavaDictionary<string, object>();
            item3.Add("img", Resource.Drawable.img2);
            item3.Add("title", "邮政快递");
            item3.Add("desc", "您的邮政快递快递到啦");

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            // 构造一个SimpleAdapter对象
             this.ListAdapter =  new SimpleAdapter(this,list, 
                                Resource.Layout.ListView_2_,
                                new string[] { "img", "title", "desc" }, 
                                new int[] { Resource.Id.imageView1, Resource.Id.txtTitle, Resource.Id.txtDesc });

            // 项目点击事件
            this.ListView.ItemClick += (sender, e) =>
            {
                string val = list[e.Position]["desc"].ToString();
                Toast.MakeText(this, val, ToastLength.Long).Show();
            };

            // 按钮单击事件 err 不能直接去获取按钮
            //var btn = FindViewById<Button>(Resource.Id.button1);
            //btn.Click += (sender, e) =>
            //{
            //    Toast.MakeText(this, "更多内容", ToastLength.Long).Show();

            //};

        }
    }
}