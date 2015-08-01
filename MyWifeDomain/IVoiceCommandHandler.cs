using Windows.ApplicationModel.Activation;

namespace MyWifeDomain
{
    public interface IVoiceCommandHandler
    {
        void HandleCommand(VoiceCommandActivatedEventArgs args);
    }
}