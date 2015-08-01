using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWifeDomain;

namespace CortanaMyWife.Voice
{
    public class AutoVoiceCommand : IVoiceCommand
    {
        private readonly string cName;
        public AutoVoiceCommand(string commandName)
        {
            cName = commandName;
        }

        public string CommandName => cName;

        public void Execute(object args)
        {
            
        }
    }
}
