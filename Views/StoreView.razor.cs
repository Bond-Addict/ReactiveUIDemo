using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
{
    public partial class StoreView
    {
        public StoreView()
        {
            ViewModel = new StoreViewModel();
        }
    }
}
