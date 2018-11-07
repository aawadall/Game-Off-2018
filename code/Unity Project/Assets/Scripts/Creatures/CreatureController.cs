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
    public float movementSpeed;
    public int movementFrequency; // Object will move every 'movementFrequency' frames
    private int moveOnThisFrame; // used to test whether object will move on a given frame
    private int framesToMoveFor; // How many frames to move for

    // Use this for initialization
    private void Start () {

        // Generate the creature's DNA
        DNA creatureDNA = new DNA( new List<Genom> { new Genom( flight, GenomPool.Instance.GetTrait("Flight").Id ),
                                                    new Genom( strength, GenomPool.Instance.GetTrait("Strength").Id ),
                                                    new Genom( agility, GenomPool.Instance.GetTrait("Agility").Id )    }, creatureName );

        // Update nameText so that it records the creature's name and attributes
        attributeText = GetComponentInChildren<TMPro.TextMeshPro>();

        // set attribute text 
        attributeText.text = creatureName;
        foreach ( Genom genom in creatureDNA.Genoms )
        {
            attributeText.text += "\r\n" + genom.Trait.Name + ": " + genom.Value.ToString();
        }

        // Initially set inactive 
        attributeText.gameObject.SetActive(false);
	}

    // Movement
    private void FixedUpdate()
    {
        if ( moveOnThisFrame == movementFrequency )
        {
            // Make the creature move in a random direction 
            float movementAngle = Random.Range(0f, 2 * (float)System.Math.PI);

            GetComponent<Rigidbody>().velocity = new Vector3( (float) System.Math.Cos(movementAngle),
                                                              (float) System.Math.Sin(movementAngle)  ) * movementSpeed;

            moveOnThisFrame = 0;
            framesToMoveFor = Random.Range(50, 100);
        }
        

        // Set the z position equal to 0
        gameObject.transform.position -= new Vector3(0, 0, gameObject.transform.position.z);

        // Set the position inside scene bounds 
        if ( System.Math.Abs( gameObject.transform.position.x ) > SceneController.Instance.xBound )
        {
            if (gameObject.transform.position.x > 0)
                gameObject.transform.position = new Vector3(SceneController.Instance.xBound, gameObject.transform.position.y);
            else if (gameObject.transform.position.x < 0)
                gameObject.transform.position = new Vector3(-SceneController.Instance.xBound, gameObject.transform.position.y);
        }
        if (System.Math.Abs(gameObject.transform.position.y) > SceneController.Instance.yBound)
        {
            if (gameObject.transform.position.y > 0)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, SceneController.Instance.yBound);
            else if (gameObject.transform.position.y < 0)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, -SceneController.Instance.yBound);
        }


        // Increment count 
        moveOnThisFrame++;

        // Set framesToMoveFor
        framesToMoveFor--;

        // Se if we need to stop moving 
        if (framesToMoveFor <= 0)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        
    }

    // Activate the text element when hovering mouse over
    private void OnMouseEnter()
    {
        // Set text above creature
        attributeText.gameObject.SetActive(true);
        // Set UIText 
        SceneController.Instance.activateTextPanel( attributeText.text );
    }
    private void OnMouseExit()
    {
        // Remove text above creature
        attributeText.gameObject.SetActive(false);
    }
}
