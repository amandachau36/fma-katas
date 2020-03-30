namespace FactoryDesignPattern
{
    //ChickBurgerFactory class (sub factory) where the actual implementation detail is located
    public class ChickenBurgerFactory : BurgerFactoryA
    {
        protected override IBurger MakeBurger()
        {
            return new ChickenBurger();
        }
    }
}