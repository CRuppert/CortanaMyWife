using System;
using System.Diagnostics;

namespace MyWifeDomain
{
    public class CookingCommand : IVoiceCommand
    {
        public string CommandName => "myWifeIsCooking";

        public async void Execute(object args)
        {
        }
    }
}