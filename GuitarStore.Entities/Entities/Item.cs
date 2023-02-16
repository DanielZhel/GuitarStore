using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Entities.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public enum ItemType { Guitar, Capo, Pick, Strings, Tuner, Amplifier, Pedal, Cable }
        
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string ModelName { get; set; }
        public string Descripton { get; set; }
        public ItemType Type { get; set; }
        public string Image { get; set; }
    }
}
