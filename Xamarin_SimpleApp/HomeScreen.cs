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
    [Activity(Label = "HomeScreen", MainLauncher = false)]
    public class HomeScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Home);
           
            var delBtn = FindViewById<Button>(Resource.Id.delBtn);
            var changeBtn = FindViewById<Button>(Resource.Id.changeBtn);
            var loginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            var listBtn = FindViewById<Button>(Resource.Id.listBtn);
            // 1、获取当前用户
            // 接收消息
            var msg = FindViewById<TextView>(Resource.Id.showMsg);
            string userName = Intent.GetStringExtra("userName");
            msg.Text = "当前用户是:" + userName;

            delBtn.Click += (sender, e) =>
            {               
                // 2、删除该用户
                LocalSqliteOpenHelper dbHelper = new LocalSqliteOpenHelper(this);
                SQLiteDatabase db = dbHelper.WritableDatabase;
                db.ExecSQL("DELETE FROM UserInfo where UserName=?", new Java.Lang.Object[]{ userName});
                // 关闭数据库对象
                db.Close();

                Toast.MakeText(this, "删除" + userName + "成功!", ToastLength.Short).Show();
            };

            // 点击修改密码按钮
            changeBtn.Click += (sender, e) =>
            {
                // 跳转到修改密码页面
                Intent intent = new Intent(this, typeof(ModifyPassWordScreen));
                intent.PutExtra("userName", userName);
                StartActivity(intent);
            };

            loginBtn.Click += (sender, e) =>
            {
                // 跳转到修改密码页面
                Intent intent = new Intent(this, typeof(LoginScreen));
                
                StartActivity(intent);
            };

            listBtn.Click += (sender, e) =>
            {
                // 跳转到修改密码页面
                Intent intent = new Intent(this, typeof(ListMessageScreen));

                StartActivity(intent);
            };

        }
    }
}