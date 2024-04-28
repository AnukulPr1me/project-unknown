using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manage : MonoBehaviour
{
    public static Level_Manage Instance;

    public float waitToRespawn;

    /*public int orbsCollected;*/


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());


    }



    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(waitToRespawn);



        PlayerController.Instance.gameObject.SetActive(false);

        playerHealthController.instance.gameObject.SetActive(true);

        PlayerController.Instance.transform.position = CheckpointController.instance.spawnPoint;

        playerHealthController.instance.currentHealth = playerHealthController.instance.maxHealth;

        HealthBar.instance.slider.value = playerHealthController.instance.maxHealth;

/*        mana_Orb.instance.gameObject.SetActive(false);
        mana_Orb.instance.gameObject.SetActive(true);
        mana_Orb.instance.currentMana = mana_Orb.instance.maxMana;
        manaBar.instance.slider.value = mana_Orb.instance.maxMana;*/

        playerHealthController.instance.anim.SetTrigger("player_Spawn");
        PlayerController.Instance.moveSpeed = 8;
        PlayerController.Instance.jumpForce = 10;


    }
}
   