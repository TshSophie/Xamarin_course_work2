using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace _04_Xamarin
{
    [Activity(/*Label = "@string/app_name", Theme = "@style/AppTheme",*/ MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // 接收消息            
            string userName = Intent.GetStringExtra("userName");

            var BroseBtn = FindViewById<Button>(Resource.Id.browseBtn);
            var PostBtn = FindViewById<Button>(Resource.Id.postDemandBtn);
            var modifyPasswdBtn = FindViewById<Button>(Resource.Id.modifypasswdBtn);
            var myPostBtn = FindViewById<Button>(Resource.Id.myPostBtn);

            modifyPasswdBtn.Click += (sender, e) =>
            {
                // 跳转到修改密码页面
                Intent intent = new Intent(this, typeof(ModifyPassWordScreen));
                intent.PutExtra("userName", userName);
                StartActivity(intent);
            };


            BroseBtn.Click += (sender, e) =>
            {
                // 跳转到列表页面
                Intent intent = new Intent(this, typeof(ListMessageScreen));
                intent.PutExtra("type", "all");
                intent.PutExtra("userName", userName);
                StartActivity(intent);
            };

            PostBtn.Click += (sender, e) =>
             {
                 // 跳转到发布需求页面
                 Intent intent = new Intent(this, typeof(InsertMessageScreen));
                 intent.PutExtra("userName", userName);
                 StartActivity(intent);
             };

            myPostBtn.Click += (sender, e) =>
            {
                // 跳转到列表页面
                Intent intent = new Intent(this, typeof(ListMessageScreen));
                intent.PutExtra("type", "mypost");
                intent.PutExtra("userName", userName);
                StartActivity(intent);
            };
        }
    }
}