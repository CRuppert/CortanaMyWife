using System.Collections;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;

namespace MyWifeDomain
{
    public interface IVoiceCommandHandler
    {
        IList<IVoiceCommand> Commands { get; }
        void HandleCommand(VoiceCommandActivatedEventArgs args);
        void AddCommand(IVoiceCommand command);
    }
}