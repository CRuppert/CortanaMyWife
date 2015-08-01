using System.Threading.Tasks;
using Windows.Foundation;

namespace MyWifeDomain
{
    public interface IVoiceCommand
    {
        string CommandName { get; }
        void Execute(object args);
    }
}
