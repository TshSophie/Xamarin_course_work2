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


namespace _04_Xamarin
{
    class LocalSqliteOpenHelper:SQLiteOpenHelper
    {
        // 构造函数
        public LocalSqliteOpenHelper(Context context):base(context,"Lib",null,1)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            // 初始，创建表
            db.ExecSQL("CREATE TABLE UserInfo(Id INTEGER PRIMARY KEY,UserName TEXT NOT NULL,PassWord TEXT NOT NULL)");

        }

        public override void OnUpgrade(SQLiteDatabase db,int oldVersion,int newVersion)
        {
            // 判断表是否存在，存在删除并重新创建
            db.ExecSQL("DROP TABLE IF EXISTS UserInfo");
            OnCreate(db);
        }

    }
}