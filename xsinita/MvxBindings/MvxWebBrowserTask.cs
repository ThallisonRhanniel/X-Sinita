using Android.Content;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Plugins.WebBrowser;

namespace xsinita
{
    public class MvxWebBrowserTask : MvxAndroidTask, IMvxWebBrowserTask
    {
        public void ShowWebPage(string url)
        {
            var intent = new Intent(Intent.ActionView, global::Android.Net.Uri.Parse(url));
            StartActivity(intent);
        }
    }
}