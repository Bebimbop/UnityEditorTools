using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class GPUMonitor : MonoBehaviour
{
    public Text GPU_Type;
    public Text GPU_DeviceVersion;
    public Text GPU_MemorySize;
    public Text GPU_MemoryUsed;

    private PerformanceCounter _gpuCounter;
    private float _curMemoryUsed;

	// Use this for initialization
	void Start ()
	{
        _gpuCounter = new PerformanceCounter("Memory", "Available MBytes");

	    if (GPU_Type != null)
	        GPU_Type.text = SystemInfo.graphicsDeviceName;

	    if (GPU_DeviceVersion != null)
	        GPU_DeviceVersion.text = SystemInfo.graphicsDeviceVersion;

	    if (GPU_MemorySize != null)
	        GPU_MemorySize.text = SystemInfo.graphicsMemorySize.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    _curMemoryUsed = _gpuCounter.NextValue();

	    if (GPU_MemoryUsed != null)
	        GPU_MemoryUsed.text = (_curMemoryUsed / SystemInfo.graphicsMemorySize).ToString() + "%";
	}
}
