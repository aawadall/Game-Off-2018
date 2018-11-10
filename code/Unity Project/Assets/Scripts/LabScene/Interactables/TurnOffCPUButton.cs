using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to turn off the CPU when a button is pressed
public class TurnOffCPUButton : MonoBehaviour {

    public GameObject canvas;

	public void CloseCPU()
    {
        canvas.SetActive(false);
        PlayerController.Instance.frozen = false;
    }
}
