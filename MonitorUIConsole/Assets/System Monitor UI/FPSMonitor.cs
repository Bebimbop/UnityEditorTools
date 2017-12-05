using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSMonitor : MonoBehaviour
{
    [Tooltip("Rate at which the FPS will update.")]
    public float updateRate = 1.0f;

    public Text FPS_Text;

    private uint frameCount = 0;
    private double deltaTime = 1;
    private double fps;

	// Use this for initialization
	void Start ()
	{
	    if (FPS_Text != null)
	        FPS_Text.text = (frameCount / deltaTime).ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    frameCount++;
	    deltaTime += Time.deltaTime;

	    if (deltaTime > 1.0 / updateRate)
	    {
	        fps = (frameCount / deltaTime);
	        frameCount = 0;
	        deltaTime -= 1.0 / updateRate;
	    }


	    FPS_Text.text = string.Format("{0:0.00}", fps);
    }
}
