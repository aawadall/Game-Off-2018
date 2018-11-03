using System;

namespace Creatures
{
    /// <summary>
    /// A Trait describes creature ability to perform a task, it is like a genom in DNA
    /// </summary>
    public class Trait
    {
        public Trait(string name, string description)
        {
            this.Description = description;
            this.Name = name;
        }
        public string Name { get; private set; }
        public Guid Id {get;} = Guid.NewGuid();
        public string Description {get; private set;}
    }
}