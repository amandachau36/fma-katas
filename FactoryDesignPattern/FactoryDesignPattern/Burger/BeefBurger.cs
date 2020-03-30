namespace FactoryDesignPattern
{
    public class BeefBurger : IBurger
    {
        public string GetIngredients()
        {
            return "Beef, cheese, onions";
        }

        public int GetPrice()
        {
            return 6;
        }

        public int GetCalories()
        {
            return 1500;
        }
    }
}