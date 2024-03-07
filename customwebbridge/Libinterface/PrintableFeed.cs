using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customwebbridge.Libinterface
{
    internal class PrintableFeed
    {
        FeedItem feed;//we only have the number of line the feed need to do in here
        //default constructor
        public PrintableFeed(FeedItem feed)
        {
            this.Feed = feed;
           // Convert_dots();//dots not supported to be disccused in windows api
        }
        //getter and setter
        public FeedItem Feed { get => feed; set => feed = value; }
    }
}
