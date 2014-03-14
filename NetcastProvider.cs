using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Coding101RSS
{
    class NetcastProvider
    {
        public string CoverArtUrl
        {
            get
            {
                return @"http://twit.tv/files/coverart/code1400_0.jpg";
            }
        }

        public string AudioUri
        {
            get
            {
                return RetrieveRssAudioUri();
            }
        }

        static string RetrieveRssAudioUri()
        {
            string uri = "http://twit.tv/node/feed";

            XmlReader xr = XmlReader.Create(uri);
            SyndicationFeed feed = SyndicationFeed.Load(xr);

            Console.WriteLine("Feed title:{0}", feed.Title.Text);

            List<SyndicationItem> items = new List<SyndicationItem>();

            foreach (SyndicationItem item in feed.Items)
            {
                if (item.Title.Text.Contains("Coding 101"))
                {
                    items.Add(item);
                }
            }

            string audio = "";
            if (items.Count > 0)
            {
                var item = items[0];
                audio = item.Id;
            }
            return audio;
        }
    }
}
