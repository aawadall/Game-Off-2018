using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #endregion

    // Use this for initialization
    private void Start () {

        // Update nameText so that it records the creature's name 
        GetComponentInChildren<TMPro.TextMeshPro>().text = creatureName;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
