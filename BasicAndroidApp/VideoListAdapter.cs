using System;
using System.Collections.Generic;
using System.Net;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using SharedLibrary;

namespace BasicAndroidApp
{
    public class VideoListAdapter : BaseAdapter<VideoLibrary>
    {
        List<VideoLibrary> videos;
        Activity context;
        public VideoListAdapter(Activity context, List<VideoLibrary> videos)
        {
            this.context = context;
            this.videos = videos;
        }
        public override VideoLibrary this[int position]
        {
            get
            {
                return videos[position];
            }
        }

        public override int Count
        {
            get
            {
                return videos.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var item = videos[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.lstItems, null);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtDescription).Text = item.description;
            var imageBitmap = GetImageBitmapFromUrl(item.ImageUrl);
            //view.FindViewById<ImageView>(Resource.Id.imgPhoto).SetImageResource(item.ImageResourceId);
            view.FindViewById<ImageView>(Resource.Id.imgPhoto).SetImageBitmap(imageBitmap);
            return view;

        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            if (!(url == "null"))
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

            return imageBitmap;
        }

    }
}
