namespace FactoryDesignPattern
{
    public interface IBurger
    {
        //can be methods or properties
        string GetIngredients();

        int GetPrice();

        int GetCalories();
    }
}