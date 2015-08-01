using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.SpeechRecognition;
using Windows.UI.Popups;

namespace MyWifeDomain
{
    public class InternetLauncherCommand : IVoiceCommand
    {
        public string CommandName => "MyWifeIsA";

        public async void Execute(object args)
        {
            try
            {
                //unfortunately this will crash when not running in a debugger, I believe because either: I am not running it from the UI thread, or because I do not have the app signed.
                var sem = args as SpeechRecognitionSemanticInterpretation;
                var thing = sem.Properties["isA"][0];
//                return Windows.System.Launcher.LaunchUriAsync(new Uri("http://lookatmyhorsemyhorseisamazing.com/"));
                 await Windows.System.Launcher.LaunchUriAsync(new Uri("https://www.youtube.com/watch?v=gDU7kTdLfF0"));
            }
            catch (Exception ex)
            {
                Debugger.Launch();
                Debugger.Break();
                throw;
            }
            
        }
    }
}