using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _04_Xamarin
{
    [Activity(Label = "InsertMessageScreen")]
    public class InsertMessageScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
           
            // 接收消息            
            string userName = Intent.GetStringExtra("userName");
            SetContentView(Resource.Layout.InsertMessage);


            var submitBtn = FindViewById<Button>(Resource.Id.submitBtn);          
            var titleTxt = FindViewById<EditText>(Resource.Id.titleTxt);
            var descTxt = FindViewById<EditText>(Resource.Id.descTxt);
            int selectPosition = 0;
            // 缓存照片
            int[] brandImg = { Resource.Drawable.img0, Resource.Drawable.img1, Resource.Drawable.img2, Resource.Drawable.img3 };

            
            string[] myData = new string[] { "中通快递", "全一快递", "邮政快递", "顺丰快递" };

            Spinner spinner1 = (Spinner)FindViewById(Resource.Id.spinner1);
            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, myData);
            spinner1.Adapter = adapter;


            // 下拉框选择事件
            spinner1.ItemSelected += (sender, e) =>
            {
                //记录选项
                selectPosition = spinner1.SelectedItemPosition;
            };

            // 提交
            submitBtn.Click += (sender, e) =>
            {
                //检测参数是否为空
                if (titleTxt.Text.Length == 0 || descTxt.Text.Length == 0)
                {
                    Toast.MakeText(this, "The title or description cannot be empty!", ToastLength.Short).Show();
                    return;
                }

                // 将数据插入数据库
                LocalSqliteHelper_2_ sqlHelper = new LocalSqliteHelper_2_(this);
                SQLiteDatabase db = sqlHelper.WritableDatabase;
                // 插入数据
                db.ExecSQL("INSERT INTO Message VALUES(null,?,?,?,?)", new Java.Lang.Object[] { titleTxt.Text, descTxt.Text, brandImg[selectPosition], userName });
                db.Close();

                Toast.MakeText(this, "Successful!", ToastLength.Short).Show();
                // 跳转到列表页面
                Intent intent = new Intent(this, typeof(ListMessageScreen));
                intent.PutExtra("type", "mypost");
                intent.PutExtra("userName", userName);
                StartActivity(intent);
                // 打开第二个页面
                StartActivity(intent);

            };

        }


    }
}