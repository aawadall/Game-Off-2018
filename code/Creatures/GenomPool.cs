using System;
using System.Collections.Generic;

namespace Creatures
{
    /// <summary>
    /// Collection of all Traits
    /// </summary>
    public static class GenomPool
    {
        public static List<Trait> Traits {get; private set;}
        public static void RegisterTrait(Trait trait){
            Traits.Add(trait);
     }

        public static Trait GetTrait(Guid traitUUID)
        {
            return Traits.Find(trait => trait.Id == traitUUID);
        }
    }
}