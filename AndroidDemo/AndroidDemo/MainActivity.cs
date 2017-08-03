using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using System;
namespace AndroidDemo
{
    [Activity(Label = "AndroidDemo", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);
            //设定要加载的用户界面
            SetContentView(Resource.Layout.Main);
            //获取界面按钮对象
            var button = FindViewById<Button>(Resource.Id.button1);
            //事件添加  处理按钮单击
            //button.Click += delegate
            //{
            //    button.Text = string.Format("这是第{0} 单击!", count++);
            //};
             // lambda表达式
            button.Click += (sender, e) =>
            {
                button.Text = string.Format("单击{0}次", count++);

            };







            //获取webview内容
            var webView = FindViewById<WebView>(Resource.Id.webView1);
            //申明webView的配置
            WebSettings settings = webView.Settings;
            //设置允许执行JS
            settings.JavaScriptEnabled = true;
            //设置可以通过JS打开窗口
            settings.JavaScriptCanOpenWindowsAutomatically = true;
            //创建WebView客户端类
            var webc = new MyCommWebClient();
            //设置自己的WebView客户端
            webView.SetWebViewClient(webc);
            webView.LoadUrl("你的地址");
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }

    class MyCommWebClient : WebViewClient
    {
        //重写页面加载的方法
        public override bool ShouldOverrideUrlLoading(WebView view, String url)
        {
            //使用本控件加载
            view.LoadUrl(url);
            //并返回true
            return true;
        }
    }
}

