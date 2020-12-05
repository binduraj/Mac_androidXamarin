using System;
using System.Collections;
using System.Collections.Generic;

namespace SharedLibrary
{
    public class VideoLibrary
    {
        public string name { get; set; }
        public string description { get; set; }
        public string ImageUrl { get; set; }

        public List<VideoLibrary> playList = new List<VideoLibrary>();

        public void AddPlayList()
        {
            playList.Add(new VideoLibrary()
            {
                name = "My Songs",
                description = "List of my songs",
                ImageUrl = "https://www.gstatic.com/webp/gallery3/4.png"
            });

            playList.Add(new VideoLibrary()
            {
                name = "My Tutorials",
                description = "List of my tutorials",
                ImageUrl = "https://www.gstatic.com/webp/gallery3/5_webp_ll.png"
            });

            playList.Add(new VideoLibrary()
            {
                name = "My Dances",
                description = "List of my Dances",
                ImageUrl = "https://www.gstatic.com/webp/gallery3/2_webp_ll.png"
            });
        }

        public List<VideoLibrary> GetPlayList()
        {
            return playList;
        }
    }
}
