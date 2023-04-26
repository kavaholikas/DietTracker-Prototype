using CommunityToolkit.Mvvm.Messaging.Messages;
using DietTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietTracker.Messages
{
    internal class UpdateEntryNameMessage : ValueChangedMessage<DietEntryModel>
    {
        public UpdateEntryNameMessage(DietEntryModel value) : base(value)
        {
        }
    }
}
