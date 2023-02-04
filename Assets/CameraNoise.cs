using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraNoise : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin noise;

    public float noiseAmount;
    public float noiseReduction;

    public void AddNoise(float amount){
        noiseAmount = Mathf.Clamp(noiseAmount + amount,0,10);
    }

    private void Start(){

        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if(noiseAmount > 0)
            noiseAmount = Mathf.Clamp(noiseAmount - noiseReduction,0,10);
        
        noise.m_AmplitudeGain = noiseAmount;
    }
}
