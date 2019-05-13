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
    [Activity(Label = "ChangePassWordScreen")]
    public class ModifyPassWordScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ModifyPassWord);

            // 接收消息            
            string userName = Intent.GetStringExtra("userName");
            var showMsg = FindViewById<TextView>(Resource.Id.showMsg);
            showMsg.Text = "Current User:" + userName;

            var txtPassWord = FindViewById<EditText>(Resource.Id.passWord);
            var txtPassWord1 = FindViewById<EditText>(Resource.Id.passWord1);
            var txtPassWord2 = FindViewById<EditText>(Resource.Id.passWord2);          

            var submitBtn = FindViewById<Button>(Resource.Id.submitBtn);

            // 点击提交按钮
            submitBtn.Click += (sender, e) =>
            {
                // 判断原密码是否输入正确
                // 获取用户名和密码              
                string passWord0 = txtPassWord.Text;
                string passWord1 = txtPassWord1.Text;
                string passWord2 = txtPassWord2.Text;
                if(passWord2.Length < 6)
                {
                    Toast.MakeText(this, "The length of password should be greater than 6", ToastLength.Short).Show();
                    return;
                }
                // 查询操作
                LocalSqliteOpenHelper sqlHelper = new LocalSqliteOpenHelper(this);
                SQLiteDatabase db = sqlHelper.WritableDatabase;
                string sql = "select UserName from UserInfo where UserName=? and PassWord=?";
                ICursor cursor = db.RawQuery(sql, new string[] { userName, passWord0 });
                bool ret = cursor.MoveToFirst();
                // 判断
                if (ret)
                {
                    // 存在，进行下一步,判断两次密码是否输入一致
                    if(passWord1 == passWord2)
                    {
                        // 更新数据
                        db.ExecSQL("UPDATE UserInfo SET PassWord=? WHERE UserName=?", new Java.Lang.Object[] { passWord2, userName});
                        db.Close();
                        Toast.MakeText(this, "Successful！", ToastLength.Short).Show();
                    }
                    else
                    {
                        db.Close();
                        Toast.MakeText(this, "The two password differ!", ToastLength.Short).Show();
                    }
                }
                else
                {
                    db.Close();
                    Toast.MakeText(this, "The old password is wrong!", ToastLength.Short).Show();
                }
            };

        }
    }
}