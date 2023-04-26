using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietTracker.Messages
{
    class OnResumeMessage : ValueChangedMessage<App>
    {
        public OnResumeMessage(App value) : base(value)
        {
        }
    }
}
