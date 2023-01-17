using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDb.StoreDbContext.Entities.Item
{
    public class Item
    {
        public enum ItemType {Guitar, Capo, Pick, Strings, Tuner, Amplifier, Pedal, Cable}
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string Descripton { get; set; }
        public ItemType Type { get; set; }

        

    }
}
