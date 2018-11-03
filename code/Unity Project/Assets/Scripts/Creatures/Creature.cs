namespace Creatures
{
    /// <summary>
    /// A creature could be either a monster or a plant
    /// </summary>
    public abstract class Creature
    {
        public DNA DNA {get; private set;}
        public string Name {get; private set;}
        
    }
}