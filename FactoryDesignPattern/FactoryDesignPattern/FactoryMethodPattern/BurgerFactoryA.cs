namespace FactoryDesignPattern
{
    public abstract class BurgerFactoryA
    {
        //create burger but no implementation detail here
        protected abstract IBurger MakeBurger();

        public IBurger CreateBurger()
        {
            return MakeBurger();
        }
    }
}