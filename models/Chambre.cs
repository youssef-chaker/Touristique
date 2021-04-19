using System;
namespace TouristiqueDbContext.models
{
    public class Chambre
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public string Type { get; set; } 
        public float Prix { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}