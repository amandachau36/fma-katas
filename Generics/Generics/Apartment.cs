namespace Generics
{
    public class Apartment : IProperty<Apartment>
    {
        public int ApartmentArea { get; set; }
        
        public bool IsEqual(Apartment property)
        {
            return ApartmentArea == property.ApartmentArea;
        }
    }
}