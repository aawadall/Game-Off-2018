using System;

namespace Creatures
{
    public class Genom
    {
        public Trait Trait {get; private set;}
        public double Value {get; private set;}
        public Genom(double value, Guid traitUUID)
        {
            this.Trait = GenomPool.Instance.GetTrait(traitUUID);
            this.Value = value;
        }
    }
}