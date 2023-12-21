using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public AudioSource audioSource;
    public AudioClip switchSound;
    public TMP_Text lightLevelText; 

    private float batteryLevel = 120f;
    private const float maxBatteryLevel = 120f; 

    public bool isOn;

    void Start()
    {
        if (light == null)
        {
            light = GetComponentInChildren<Light>();
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (light == null)
        {
            Debug.LogError("Light component not found. Make sure the flashlight has a Light component attached.");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Make sure the flashlight has an AudioSource component attached.");
        }

        
        isOn = false;
        light.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashlight();
        }

        if (isOn)
        {
            batteryLevel -= Time.deltaTime;
            batteryLevel = Mathf.Max(0.0f, batteryLevel);

            
            if (batteryLevel == 0.0f)
            {
                ToggleFlashlight();
            }
        }

        
        UpdateLightLevelText();

       
        if (batteryLevel == 0.0f)
        {
            DisableFlashlight();
            enabled = false;
        }
    }

    void ToggleFlashlight()
    {
        isOn = !isOn;

        if (isOn)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }

        if (audioSource != null && switchSound != null)
        {
            audioSource.PlayOneShot(switchSound);
        }
    }

    void DisableFlashlight()
    {
        isOn = false;
        light.enabled = false;
    }

    void UpdateLightLevelText()
    {
        if (lightLevelText != null)
        {
            float lightPercentage = (batteryLevel / maxBatteryLevel) * 100.0f;
            lightLevelText.text = "Light level: " + Mathf.RoundToInt(lightPercentage) + "%";
        }
    }
}
