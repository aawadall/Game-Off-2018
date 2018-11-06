using System;
using System.Collections.Generic;
using UnityEngine;

namespace Creatures
{
    /// <summary>
    /// Collection of all Traits
    /// </summary>
    public class GenomPool : MonoBehaviour
    {
        #region Singleton Implementation and registration of traits

        public static GenomPool Instance;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
                Instance = this;

            else if (Instance != this)
                Destroy(gameObject);

            // Register traits here
            Traits = new List<Trait>();
            for (int i = 0; i < traitNames.Length; i++)
            {
                RegisterTrait(traitNames[i], traitDescriptions[i]);
            }
        }
        #endregion

        public string[] traitNames;
        public string[] traitDescriptions;

        public List<Trait> Traits { get; private set; }

        public void RegisterTrait(string name, string description) {
            Trait trait = new Trait(name, description); 
            Traits.Add(trait);
        }

        public Trait GetTrait(Guid traitUUID)
        {
            return Traits.Find(trait => trait.Id == traitUUID);
        }
        // Override for finding based on name 
        public Trait GetTrait( string name )
        {
            foreach( Trait trait in Traits )
            {
                if (trait.Name == name)
                    return trait;
            }

            return null;
        }
    }
}