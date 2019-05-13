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
    [Activity(Label = "SecondScreen")]
    public class RegisterScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            var txtUserName = FindViewById<EditText>(Resource.Id.txtUserName); 
            var txtPassWord = FindViewById<EditText>(Resource.Id.txtPassWord);
            var txtPassWord2 = FindViewById<EditText>(Resource.Id.txtPassWord2);
            var regBtn = FindViewById<Button>(Resource.Id.registerBtn);

            // 点击注册按钮
            regBtn.Click += (sender, e) =>
            {
                // 获取文本值
                var userName = txtUserName.Text;
                var passWord = txtPassWord.Text;
                var passWord2 = txtPassWord2.Text;
                if(userName.Length == 0||passWord.Length==0||passWord2.Length==0)
                {
                    // 错误提示
                    Toast.MakeText(this, "The username or password cannot be empty!", ToastLength.Short).Show();
                    return;
                }
                // 判断两次输入密码是否一致
                if(passWord == passWord2)
                {
                    if(passWord.Length < 6)
                    {
                        Toast.MakeText(this, "The length of password should be greater than 6", ToastLength.Short).Show();
                        return;
                    }
                    // 判断用户名是否已经被注册
                    // 查询操作
                    LocalSqliteOpenHelper sqlHelper = new LocalSqliteOpenHelper(this);
                    SQLiteDatabase db = sqlHelper.WritableDatabase;
                    string sql = "select UserName from UserInfo where UserName=?";
                    ICursor cursor = db.RawQuery(sql, new string[] { userName });
                    bool ret = cursor.MoveToFirst();
                    if (ret)
                    {
                        db.Close();
                        Toast.MakeText(this, "Username already exists！", ToastLength.Short).Show();
                    }
                    else
                    {                                           
                        // 插入数据
                        db.ExecSQL("INSERT INTO UserInfo VALUES(null,?,?)", new Java.Lang.Object[] { userName, passWord });
                        db.Close();
                        Toast.MakeText(this, "Successful!", ToastLength.Short).Show();
                        // 跳转到登录页面                        
                        Intent intent = new Intent(this, typeof(LoginScreen));                       
                        // 打开第二个页面
                        StartActivity(intent);
                    }

                }
                else
                {
                    // 错误提示
                    Toast.MakeText(this, "The two password differ!", ToastLength.Short).Show();
                }
            };

        }
    }
}