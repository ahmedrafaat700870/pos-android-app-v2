namespace App.ViewModel.Product
{
    public partial class BackFromGroupModel : ObservableObject
    {
        [ObservableProperty]
        private string name;


        private Action BackToGroup;

        public BackFromGroupModel(Action BackToGroup ) 
        {
            this.BackToGroup = BackToGroup;
        }


        [RelayCommand]
        private void ClickBack()
        {
            BackToGroup.Invoke();
        }
    }
}
