using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace MyWifeService
{
    public sealed class WifeHost : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

            taskInstance.Canceled += OnTaskCanceled;

            _deferral.Complete();
        }
    }
}
