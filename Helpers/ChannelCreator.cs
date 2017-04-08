using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
namespace Helpers
{
    public class ChannelCreator
    {
        public static void CreateChannel(string channelName)
        {
            if (!MessageQueue.Exists(channelName))
                MessageQueue.Create(channelName);
        }
    }
}
