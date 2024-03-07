namespace App.ViewModel.Product
{
    public partial class GroupModel : ObservableObject
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string img;
        private inventory_productgroups group;

        private Action<int? > LoadDataGroup;

        public GroupModel(inventory_productgroups group , Action<int? > LoadDataGroup )
        {
            this.group = group;
            Name = group.name;
            Img = string.Empty;
            this.LoadDataGroup = LoadDataGroup;
        }

        [RelayCommand]
        private void ClickGroup()
        {
            LoadDataGroup.Invoke(group.id );
        }

    }
}
