using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using SharedLibrary;

namespace BasicAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            Button btnVideoList = FindViewById<Button>(Resource.Id.button1);
            btnVideoList.Click += btnVideoList_Click;

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            TextView txt = FindViewById<TextView>(Resource.Id.txtshowPath);
            txt.Text = new DatabaseOperations().GetDataBasePath();

            Button btnInsert = FindViewById<Button>(Resource.Id.btnInsert);
            btnInsert.Click += BtnInsert_Click;

            Button btnGet = FindViewById<Button>(Resource.Id.btnGet);
            btnGet.Click += BtnGet_Click;
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            var database = new DatabaseOperations();
            var gamers = database.GetGamers();

            TextView txtShowGamer = FindViewById<TextView>(Resource.Id.txtShowGamer);
            txtShowGamer.Text = gamers[0].Name + " -  " + gamers[0].Score.ToString();

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            GameScore newGamer = new GameScore();
            newGamer.Name = FindViewById<EditText>(Resource.Id.gamerName).Text;
            newGamer.Score = Convert.ToInt32(FindViewById<EditText>(Resource.Id.gamescore).Text);
            var database = new DatabaseOperations();
            database.insertGamerInfo(newGamer);
        }

        private void btnVideoList_Click(object sender, EventArgs e)
        {
            EditText editEmail = FindViewById<EditText>(Resource.Id.editEmail);

            var secondScreenIntent = new Intent(this, typeof(SecondScreen));
            secondScreenIntent.PutExtra("email", editEmail.Text);
            StartActivity(secondScreenIntent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {

            View view = (View)sender;
            Snackbar.Make(view, "This is a test message", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
