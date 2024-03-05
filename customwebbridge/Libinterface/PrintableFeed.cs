using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Libinterface
{
    internal class PrintableFeed
    {
        FeedItem feed;

        public PrintableFeed(FeedItem feed)
        {
            this.Feed = feed;
           // Convert_dots();//dots not supported to be disccused in windows api
        }

        public FeedItem Feed { get => feed; set => feed = value; }

       /* private void Convert_dots()
        {
            if(Feed.Unit!=0)
            {
                Feed.Line = Feed.Unit / 10;
            }
            //feed(int32 feed.Line);
        }*/
    }
}
