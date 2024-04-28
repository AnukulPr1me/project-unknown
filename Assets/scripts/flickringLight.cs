using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class flickringLight : MonoBehaviour
{
    [SerializeField] float firstVariable;
    [SerializeField] float secondVariable;
    [SerializeField] float secondsBetweenFlickers;

    Light2D myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light2D>();
        StartCoroutine(LightFlicker());
    }

   

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(secondsBetweenFlickers);
        myLight.pointLightOuterRadius = Random.Range(firstVariable, secondVariable);
        StartCoroutine(LightFlicker());
    }
}
