using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyLightControl : MonoBehaviour {

    public UnityEngine.Rendering.Universal.Light2D lightToFade;  // The light that will be faded
    public float fadeInTime;  // The time it takes for the light to fade in (in seconds)
    public float fadeOutTime;  // The time it takes for the light to fade out (in seconds)
    public float holdTime;  // The time the light will stay at its brightest (in seconds)
    public float maxIntensity;  // The maximum intensity that the light should reach during the fade-in

    public float timer;  // The time since the current fade started

    public enum LightState {
        FadingIn,
        Holding,
        FadingOut,
        Silent
    }

    public LightState light;

    void Start() {
        //timer = UnityEngine.Random.Range(0, fadeOutTime);
        timer = 0;
        lightToFade.intensity = 0;
        holdTime += fadeInTime;
        fadeOutTime += holdTime;
    }

    void Update() {

        if (timer < fadeInTime) {
            light = LightState.FadingIn;
        } else if (timer > fadeInTime && timer < holdTime) {
            light = LightState.Holding;
        } else if (timer > holdTime && timer < fadeOutTime) {
            light = LightState.FadingOut;
        } else if (timer > fadeOutTime && timer < fadeOutTime + holdTime) {
            light = LightState.Silent;
        }


        switch(light) {
            case LightState.FadingIn:
                if (lightToFade.intensity < maxIntensity)
                    lightToFade.intensity = maxIntensity * (timer / fadeInTime);
                break;
            case LightState.Holding:
                lightToFade.intensity = maxIntensity;
                break;
            case LightState.FadingOut:
                if (lightToFade.intensity > 0.01) {
                    lightToFade.intensity = maxIntensity * (1 - ((timer - holdTime) / (fadeOutTime - holdTime)));
                } else {
                    lightToFade.intensity = 0;
                    //Destroy(this);
                }
                break;
            case LightState.Silent:
                lightToFade.intensity = 0;
                break;

        }

        timer += Time.deltaTime;
    }
}
