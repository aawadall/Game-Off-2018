using System;
using System.Collections.Generic;

namespace Creatures
{
    /// <summary>
    /// DNA class contains creature traits
    /// </summary>
    public class DNA
    {
        public List<Genom> Genoms {get; private set;}
        public string Name {get; private set;}
        public Guid ID {get; private set;}
        public DNA(List<Genom> genoms, string name)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            foreach(Genom g in genoms)
            {
                this.Genoms.Add(g);
            }
        }
    }
}