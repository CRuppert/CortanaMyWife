using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel.Activation;

namespace MyWifeDomain.VoiceCommandHandlers
{
    public class DefaultVoiceCommandHandler : IVoiceCommandHandler
    {
        public DefaultVoiceCommandHandler()
        {
            var cmds = GetType().GetTypeInfo().Assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IVoiceCommand)) ).ToList();
            Commands = new List<IVoiceCommand>();
            foreach (var c in cmds)
            {
//                if(c.GetInterfaces().Length > 0)
                Commands.Add((IVoiceCommand)Activator.CreateInstance(c));
            }
        }
        protected IList<IVoiceCommand> Commands{get;set;}

        public async void HandleCommand(VoiceCommandActivatedEventArgs args)
        {
            var speechRecogResult = args.Result;
            var cmdName = speechRecogResult.RulePath[0];
            var textSpoken = speechRecogResult.Text;

            string commandMode = speechRecogResult.SemanticInterpretation.Properties["commandMode"].ToString();

            var cmd = Commands.FirstOrDefault(t => t.CommandName.ToLower().Equals(cmdName.ToLower()));

            cmd?.Execute(speechRecogResult.SemanticInterpretation);
        }
    }
}