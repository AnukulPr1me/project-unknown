using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options= new List<string>();
        int currentResolutionIndex = 0;
        for (int i =0; i<resolutions.Length; i++)
        {
            string option  = resolutions[i].width+"x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value= currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
        

    public void SetFullScreen(bool isFullScreen)
    {
        ControlFreak2.CFScreen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        ControlFreak2.CFScreen.SetResolution(resolution.width, resolution.height, Screen.fullScreen)ControlFreak2.CFScreen.fullScreen);
    }
}
