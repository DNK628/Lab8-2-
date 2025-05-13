using Lab8.Data.RestaurantGuideMvvm.Data;
using Lab8.Models;
using Microsoft.EntityFrameworkCore;
using Lab8.Data;
using Lab8.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace RestaurantGuideMvvm.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly AppDbContext _dbContext;

        public MainViewModel()
        {
            _dbContext = new AppDbContext();
            _dbContext.Database.EnsureCreated();
            LoadRestaurants();
        }

        public ObservableCollection<Restaurant> Restaurants { get; set; } = new();

        private void LoadRestaurants()
        {
            var items = _dbContext.Restaurants.OrderBy(r => r.Name).ToList();
            Restaurants.Clear();
            items.ForEach(Restaurants.Add);
        }

        public string NewRestaurantName { get; set; }
        public string NewRestaurantAddress { get; set; }
        public decimal NewAverageBill { get; set; }

        public void AddRestaurant()
        {
            var restaurant = new Restaurant
            {
                Name = NewRestaurantName,
                Address = NewRestaurantAddress,
                AverageBill = NewAverageBill
            };
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            LoadRestaurants();
        }

        public int RestaurantCount => Restaurants.Count;
    }
}
