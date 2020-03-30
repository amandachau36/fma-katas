namespace FactoryDesignPattern
{
    public abstract class FactoryAbstract
    {
        private FactoryAbstract() // protected will enable access in the derived class
        {
            
        }
    }

    // public class ConcreteFactory : FactoryAbstract
    // {
    //     public ConcreteFactory() : base ()
    //     {
    //         //cannot access private constructor 
    //     }
    // }
}