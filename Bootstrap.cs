using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Xaml;
using MyWifeDomain;
using MyWifeDomain.VoiceCommandHandlers;

namespace CortanaMyWife
{
    public partial class App : Application
    {
        public IVoiceCommandHandler VoiceHandler { get; set; }
        public async void RegisterVoiceCommands()
        {
            var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///HeyCortanaMyWife.xml"));
            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(storageFile);
            
            VoiceHandler = new DefaultVoiceCommandHandler();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            switch (args.Kind)
            {
                case ActivationKind.VoiceCommand:
                    var commandArgs = args as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
                    VoiceHandler.HandleCommand(commandArgs);
                    break;
                default:
                    break;
            }
           
            
        }
        
    }
}
