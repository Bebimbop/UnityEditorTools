using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class CPUMonitor : MonoBehaviour
{
    public Text CPU_Type;
    public Text CPU_ProcessorCount;
    public Text CPU_ProcessorFrequency;
    public Text CPU_Used;

    private PerformanceCounter cpuCounter;
    private float _usedCPU;

	// Use this for initialization
	void Start ()
	{
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "Total", true);

	    if (CPU_Type != null)
	        CPU_Type.text = SystemInfo.processorType;

	    if (CPU_ProcessorCount != null)
	        CPU_ProcessorCount.text = SystemInfo.processorCount.ToString();

	    if (CPU_ProcessorFrequency != null)
	        CPU_ProcessorFrequency.text = SystemInfo.processorFrequency.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
        _usedCPU = cpuCounter.NextValue();

        if (CPU_Used != null)
	        CPU_Used.text =  _usedCPU + "%";
	}
}
