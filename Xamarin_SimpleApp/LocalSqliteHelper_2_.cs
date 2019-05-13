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
    class LocalSqliteHelper_2_ : SQLiteOpenHelper
    {
        // 构造函数
        // 上下文，数据库名字，，数据库版本
        public LocalSqliteHelper_2_(Context context):base(context,"msglib",null,1)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            // 创建表
            db.ExecSQL("CREATE TABLE Message(_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,title TEXT NOT NULL,desc TEXT NOT NULL,image TEXT NOT NULL,user TEXT)");

            // 添加数据
            //db.ExecSQL("INSERT INTO Message (title,desc,image) VALUES ('顺丰快递','这里有个顺丰快递已经抵达快来帮忙吧',"+ Resource.Drawable.img3 + ")");
            //db.ExecSQL("INSERT INTO Message (title,desc,image) VALUES ('中通快递','这里有个中通快递已经抵达快来帮忙吧'," + Resource.Drawable.img0 + ")");
            //db.ExecSQL("INSERT INTO Message (title,desc,image) VALUES ('全一快递','这里有个全一快递已经抵达快来帮忙吧'," + Resource.Drawable.img1 + ")");
            //db.ExecSQL("INSERT INTO Message (title,desc,image) VALUES ('顺丰快递','这里有个顺丰快递已经抵达快来帮忙吧'," + Resource.Drawable.img2 + ")");

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            // 判断表是否存在，存在删除并新建
            db.ExecSQL("DROP TABLE IF EXISTS Message");
            OnCreate(db);
        }

       

    }
}