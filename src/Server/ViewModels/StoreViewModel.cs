using System;
using Bogus;
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

        public StoreViewModel() {
            //I assume I need to do something here.....
        }

        public StoreViewModel Initialize()
        {
            var locationFaker = new Faker<Location>()
         .RuleFor(l => l.Id, f => f.IndexFaker + 1)
         .RuleFor(l => l.Name, f => f.Address.City())
         .RuleFor(l => l.State, f => f.Address.State());

            // Faker for Item
            var itemFaker = new Faker<Item>()
                .RuleFor(i => i.Id, f => f.IndexFaker + 1)
                .RuleFor(i => i.Name, f => f.Commerce.ProductName())
                .RuleFor(i => i.CreatedDate, f => DateOnly.FromDateTime(f.Date.Past()))
                .RuleFor(i => i.SoldAtLocations, f =>
                {
                    var locations = new ObservableCollectionExtended<Location>();
                    locations.AddRange(locationFaker.Generate(f.Random.Int(1, 5))); // Random number of locations
                    return locations;
                });

            // Faker for Department
            var departmentFaker = new Faker<Department>()
                .RuleFor(d => d.Id, f => f.IndexFaker + 1)
                .RuleFor(d => d.Name, f => f.Commerce.Department())
                .RuleFor(d => d.Item1, f => itemFaker.Generate())
                .RuleFor(d => d.Item2, f => itemFaker.Generate())
                .RuleFor(d => d.Item3, f => itemFaker.Generate())
                .RuleFor(d => d.Item4, f => itemFaker.Generate());

            // Faker for StoreViewModel
            var storeViewModelFaker = new Faker<StoreViewModel>()
                .RuleFor(s => s.Departments, f =>
                {
                    var departments = new ObservableCollectionExtended<Department>();
                    departments.AddRange(departmentFaker.Generate(f.Random.Int(2, 5))); // Random number of departments
                    return departments;
                });

            // Generate the StoreViewModel with fake data
            var fakeStore = storeViewModelFaker.Generate();

            return fakeStore;
        }
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
