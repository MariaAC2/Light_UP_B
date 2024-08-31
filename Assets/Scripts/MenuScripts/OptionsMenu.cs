using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] TMP_Dropdown dropdown;

    Resolution[] resolutions;

    [SerializeField] Toggle checkToggle;
    Image background;
    public Color color = new Color(0.4641509f, 0.4641509f, 0.4641509f);
    Color originalColor;

    private void Start()
    {
        // Get the Image component of the Background child object of the Toggle
        background = checkToggle.transform.Find("Background").GetComponent<Image>();

        // Store the original color of the Background
        originalColor = background.color;

        // Get available screen resolutions
        resolutions = Screen.resolutions;

        // Clear any existing options in the dropdown
        dropdown.ClearOptions();

        // Create a list to hold resolution options
        List<string> options = new List<string>();

        int currResolutionIndex = 0;

        // Loop through all available resolutions and add them to the dropdown options
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            // Check if this resolution is the current screen resolution
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currResolutionIndex = i;
            }
        }

        // Add the resolution options to the dropdown and set the current value
        dropdown.AddOptions(options);
        dropdown.value = currResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void CheckFullScreen(bool fullScreen)
    {
        if (fullScreen)
        {
            background.color = color;
        }
        else
        {
            background.color = originalColor;
        }
    }
}
