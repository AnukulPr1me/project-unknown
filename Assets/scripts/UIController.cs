using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    /*public Text orbText;*/
    // Start is called before the first frame update
    void Start()
    {
        /*UpdateOrbsCount();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 /*   public void UpdateOrbsCount()
    {
        orbText.text = Level_Manage.Instance.orbsCollected.ToString();
    }*/
}
