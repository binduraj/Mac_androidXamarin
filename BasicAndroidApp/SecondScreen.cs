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
using SharedLibrary;

namespace BasicAndroidApp
{
    [Activity(Label = "SecondScreen")]
    public class SecondScreen : Activity
    {
        VideoLibrary videos = new VideoLibrary();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SecondScreen);
            //email value is passed from main screen
            /* multi line comment */            
            var email =  Intent.GetStringExtra("email");
            TextView textView = FindViewById<TextView> (Resource.Id.txtEmail);
            textView.Text = email;

            videos.AddPlayList();

            ListView listView = FindViewById<ListView>(Resource.Id.lstVideos);
            listView.Adapter = new VideoListAdapter(this, videos.GetPlayList());


            listView.TextFilterEnabled = true;
            listView.ItemClick += ListView_ItemClick;

            Button btnClose = FindViewById<Button>(Resource.Id.btnClose);
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = videos.playList[e.Position];

            Toast.MakeText(Application, t.name, ToastLength.Short).Show();
        }
    }
}
