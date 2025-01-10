using ServerSideExample.ViewModels;

namespace ServerSideExample.Views
{
    public partial class StoreView
    {
        public bool ShouldShowReportButton { get; set; }
        public StoreView()
        {
            ViewModel = new StoreViewModel().Initialize();
        }

        protected override void OnInitialized()
        {
            //Basically anytime any property contained in the StoreViewModel changes, I want to hide the report button
            ViewModel.Departments.CollectionChanged += (_, _) => HideButton();
            base.OnInitialized();
        }

        public void HideButton() => ShouldShowReportButton = false;

        public void Submit() => ShouldShowReportButton = true;
    }
}
