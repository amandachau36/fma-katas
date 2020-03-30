namespace FactoryDesignPattern
{
    public class BurgerFactory 
    {
        public static IBurger CreateBurger(string burgerType)
        {
            if (burgerType == "chicken")
            {
                return new ChickenBurger();
            }
            
            return new BeefBurger();
            
        }
    }
}

//Factory Pattern - return different types of Objects based on different parameters through the static method