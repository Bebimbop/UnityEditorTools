using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButton : MonoBehaviour
{
    public int value;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnKeypadButtonPressed);
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnKeypadButtonPressed()
    {
        Debug.Log(value);
    }
}
