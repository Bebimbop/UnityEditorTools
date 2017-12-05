using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public List<KeypadButton> keypadButtons = new List<KeypadButton>();

    private int[] enteredNumber = new int[4];

	// Use this for initialization
	void Start ()
    {
        foreach (KeypadButton kb in FindObjectsOfType(typeof(KeypadButton)))
        {
            keypadButtons.Add(kb);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


}
