using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace _04_Xamarin
{
    [Activity(Label = "FirstScreen", MainLauncher = true)]
    public class LoginScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);
            var txtName = FindViewById<EditText>(Resource.Id.editText1);
            var txtPass = FindViewById<EditText>(Resource.Id.editText2);
            var loginBtn = FindViewById<Button>(Resource.Id.loginBtn);

            // 注册
            var register = FindViewById<TextView>(Resource.Id.register);
            register.Click += (sender, e) =>
            {
                // 显示注册页面
                // 实例化一个Intent对象
                Intent intent = new Intent(this, typeof(RegisterScreen));               
                // 打开第二个页面
                StartActivity(intent);
            };

            // 登陆按钮单击事件
            loginBtn.Click += (sender, e) =>
            {
                // 获取用户名和密码
                string userName = txtName.Text;
                string passWord = txtPass.Text;

                // 查询操作
                LocalSqliteOpenHelper sqlHelper = new LocalSqliteOpenHelper(this);
                SQLiteDatabase db = sqlHelper.WritableDatabase;
                string sql = "select UserName from UserInfo where UserName=? and PassWord=?";
                ICursor cursor = db.RawQuery(sql, new string[] { userName, passWord });
                bool ret = cursor.MoveToFirst();
                // 判断
                if(ret)
                {
                    //用户名密码正确，打开第二个页面,显示登陆成功的用户
                    // 从结果中取出数据
                    string dbUserName = cursor.GetString(0);
                    Toast.MakeText(this, "Successful!", ToastLength.Long).Show();

                    // 打开主页
                    Intent intent = new Intent(this, typeof(MainActivity));
                    // 传递消息到第二个页面
                    intent.PutExtra("userName", dbUserName);
                    // 打开第二个页面
                    StartActivity(intent);
                }
                else
                {
                    // 提示用户名或密码错误
                    Toast.MakeText(this, "Username or password cannot match!", ToastLength.Long).Show();
                }

                // 关闭游标和数据库对象
                cursor.Close();
                db.Close();

                // 清空输入框
                txtName.Text = "";
                txtPass.Text = "";
            };

        }
    }
}