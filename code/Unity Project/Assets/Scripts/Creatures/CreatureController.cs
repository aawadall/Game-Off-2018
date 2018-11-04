using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Creatures;

// <summary>
// Where a creature's traits/DNA/etc. are defined and put together to make a Creature object 
// </summary>

public class CreatureController : MonoBehaviour {

    // Need to input: 
    // - values for each trait (which are stored in genomes)
    // - the name of the creature 
    // These are passed to the Creature constructor.

    #region Input Variables 

    public string creatureName;
    public float flight;
    public float strength;
    public float agility;

    #endregion

    private TMPro.TextMeshPro attributeText;

    // Use this for initialization
    private void Start () {

        // Generate the creature's DNA
        DNA creatureDNA = new DNA( new List<Genom> { new Genom( flight, GenomPool.Instance.GetTrait("Flight").Id ),
                                                    new Genom( strength, GenomPool.Instance.GetTrait("Strength").Id ),
                                                    new Genom( agility, GenomPool.Instance.GetTrait("Agility").Id )    }, creatureName );

        // Update nameText so that it records the creature's name and attributes
        attributeText = GetComponentInChildren<TMPro.TextMeshPro>();

        attributeText.text = creatureName;
        foreach ( Genom genom in creatureDNA.Genoms )
        {
            attributeText.text += "\r\n" + genom.Trait.Name + ": " + genom.Value.ToString();
        }

        // Initially set inactive 
        attributeText.gameObject.SetActive(false);

	}

    // Activate the text element when hovering mouse over
    private void OnMouseEnter()
    {
        attributeText.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        attributeText.gameObject.SetActive(false);
    }
}
