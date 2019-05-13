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
using Android.Database.Sqlite;
using Android.Database;

namespace _04_Xamarin
{
    [Activity(Label = "ListView_3_Screen", MainLauncher = false)]
    public class ListMessageScreen : ListActivity
    {
        ICursor cursor = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // 接收消息            
            string type = Intent.GetStringExtra("type");
            string userName = Intent.GetStringExtra("userName");

           

            // Create your application here
            // 数据查询
            LocalSqliteHelper_2_ sqlhelper = new LocalSqliteHelper_2_(this);
            string sql = "";
            //sql = "SELECT _id ,title,desc,image,user from Message where user = " + userName;
            if(type == "all")
            {
                sql = "SELECT _id ,title,desc,image,user from Message";

                cursor = sqlhelper.WritableDatabase.RawQuery(sql, null);
            }
            else
            {
                sql = "SELECT _id ,title,desc,image,user from Message where user=?";

                cursor = sqlhelper.WritableDatabase.RawQuery(sql, new string[] { userName });

            }
            // 管理游标
            StartManagingCursor(cursor);

            // 构造SimpleCursorAdapter对象，并绑定到适配器
           this.ListAdapter =  new SimpleCursorAdapter(this, Resource.Layout.ListView_3_, cursor,
                new string[] {"title", "desc" ,"image"},
                new int[] { Resource.Id.txtTitle, Resource.Id.txtDesc, Resource.Id.image });

            // 选项点击事件
            this.ListView.ItemClick += (sender, e) =>
            {
                // 从游标里去获取相关信息
                cursor.MoveToPosition(e.Position);
                string[] values = { cursor.GetString(1) ,cursor.GetString(2), cursor.GetString(3),cursor.GetString(4) };
                // 打开新页面
                Intent intent = new Intent(this, typeof(ShowMessageScreen));
                intent.PutExtra("Message", values);
                StartActivity(intent);
            };
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            StopManagingCursor(cursor);
            cursor.Close();
        }

    }
}