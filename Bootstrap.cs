using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Data.Xml.Dom;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Enumeration;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using CortanaMyWife.Voice;
using MyWifeDomain;
using MyWifeDomain.VoiceCommandHandlers;

namespace CortanaMyWife
{
    public partial class App : Application
    {
        public IVoiceCommandHandler VoiceHandler { get; set; }
        public async void RegisterVoiceCommands()
        {
            VoiceHandler = new DefaultVoiceCommandHandler();
            var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///HeyCortanaMyWife.xml"));
            var doc = await XmlDocument.LoadFromFileAsync(storageFile);
            WriteAutoCommandsToHandler(doc);
            await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(storageFile);
            
            
            
        }

        protected void WriteAutoCommandsToHandler(XmlDocument voiceXml)
        {
            var commandSet = voiceXml.GetElementsByTagName("Command").Where(n => n.Attributes.GetNamedItem("Name").NodeValue.ToString().StartsWith("auto"));
            foreach (var c in commandSet)
            {

                VoiceHandler.AddCommand(GenerateAutoVoiceCommand(c));
            }
        }

        protected AutoVoiceCommand GenerateAutoVoiceCommand(IXmlNode node)
        {
            var name = node.Attributes.GetNamedItem("Name").NodeValue.ToString();
            return new AutoVoiceCommand(name);
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
