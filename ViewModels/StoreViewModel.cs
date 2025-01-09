using System;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData.Binding;
using ReactiveUI;

namespace ServerSideExample.ViewModels
{
    public class StoreViewModel : ReactiveObject
    {
        private IObservableCollection<Department> _department;

        public IObservableCollection<Department> Departments
        {
            get => _department;
            set => this.RaiseAndSetIfChanged(ref _department, value);
        }

        public StoreViewModel() { }
    }


    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Item Item1 { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }

    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedDate { get; set; }
        public IObservableCollection<Location> SoldAtLocations { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

    }
}
