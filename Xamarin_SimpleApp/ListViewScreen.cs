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
    [Activity(Label = "ListViewScreen", MainLauncher = false)]
    public class ListViewScreen : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //SetContentView(Resource.Layout.ListView);

            // 页面标题
            this.Title = "订单详情";
            
            // 定义一个序列来存放ListView中item的内容
            List<string> orderList = new List<string>()
            {
                "订单编号:3457766",
                "订单状态:订单取消",
                "订单时间:2019/03/20",
                "订单金额:345",
                "酒店名称:未知酒店",
                "酒店地址:北京市海淀区"
            };
            // 通过实现ArrayAdapter的构造函数来创建一个ArrayAdapter的对象
            // 这里使用系统提供的简单布局
            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, orderList);

            //// 单选按钮
            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemSingleChoice, orderList);
            //// 设置列表选择模式
            //this.ListView.ChoiceMode = ChoiceMode.Single;

            //// 复选框
            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, orderList);
            //// 设置列表选择模式
            //this.ListView.ChoiceMode = ChoiceMode.Multiple;

            // 选择框
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemChecked, orderList);
            // 设置列表选择模式
            this.ListView.ChoiceMode = ChoiceMode.Multiple;

            // 通过ListView的Adapter属性绑定ArrayAdapter
            // 本页面直接继承的ListActivity
            this.ListAdapter = adapter;

            // ListView事件
            this.ListView.ItemClick += (sender, e) =>
            {
                // 显示选择的内容
                Toast.MakeText(this, "点击" + orderList[e.Position], ToastLength.Long).Show();
            };
        }
    }
}