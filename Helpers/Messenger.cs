using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Messenger
    {
        public string IncommingChannelName { get; set; }
        public string OutgoingChannelName { get; set; }

        private MessageQueue _incomingQueue;
        private MessageQueue _outgoingQueue;
        private MessageQueue _responseQueue;

        public Messenger(string incommingChannelName = null, string outgoingChannelName = null)
        {
            IncommingChannelName = PrepareChannelName(incommingChannelName);
            OutgoingChannelName = PrepareChannelName(outgoingChannelName);

            ChannelCreator.CreateChannel(IncommingChannelName);
            ChannelCreator.CreateChannel(OutgoingChannelName);
        }

        public T Receive<T>()
        {
            _incomingQueue = new MessageQueue(IncommingChannelName);
            var message = _incomingQueue.Receive();
            _responseQueue = message.ResponseQueue;

            // Set formatter, otherwise doesn't work
            message.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });

            return (T)message.Body;
        }

        public void Reply<T>(T body)
        {
            var message = new Message(body);

            if (IncommingChannelName != null)
                message.ResponseQueue = new MessageQueue(IncommingChannelName);

            _responseQueue.Send(message);
        }

        public void Send<T>(T body)
        {
            _outgoingQueue = new MessageQueue(OutgoingChannelName);
            var message = new Message(body);
            message.ResponseQueue = new MessageQueue(IncommingChannelName);
            _outgoingQueue.Send(message);
        }

        private string PrepareChannelName(string name)
        {
            return name == null ? null : $@".\Private$\{name}";
        }

    }
}
