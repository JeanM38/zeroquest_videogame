using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float flickerIntensity = 0.2f;
    public float flickerPerSecond = 3.0f;
    public float speedRandomness = 1.0f;

    private float time, startingIntensity;
    private Light flickerLight;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        startingIntensity = flickerLight.intensity;
    }

    private void Update()
    {
        time += Time.deltaTime * (1 - Random.Range(-speedRandomness, speedRandomness)) * Mathf.PI;
        flickerLight.intensity = startingIntensity + Mathf.Sin(time * flickerPerSecond) * flickerIntensity;
    }
}
