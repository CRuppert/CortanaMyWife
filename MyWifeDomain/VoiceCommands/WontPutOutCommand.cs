using System;
using System.Diagnostics;

namespace MyWifeDomain
{
    public class WontPutOutCommand : IVoiceCommand
    {
        public string CommandName => "myWifeWontPutOut";

        public async void Execute(object args)
        {
            

        }
    }
}