using GuitarStore.Entities.Entities;
using System.Data;

namespace GuitarStore.Models.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public List<Item> Item { get; set; }
    }
}
