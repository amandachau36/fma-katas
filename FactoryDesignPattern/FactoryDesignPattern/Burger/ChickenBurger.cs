namespace FactoryDesignPattern
{
    public class ChickenBurger : IBurger
    {
        public string GetIngredients()
        {
            return "chicken, tomato, mayo";
        }

        public int GetPrice()
        {
            return 5;
        }

        public int GetCalories()
        {
            return 1000; 
        }
    }
}