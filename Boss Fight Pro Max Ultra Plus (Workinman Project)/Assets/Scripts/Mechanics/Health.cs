using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int playerHealth;

    private void OnEnable()
    {
        EventsManager.onBossCollision += DamagePlayer;
    }

    private void OnDisable()
    {
        EventsManager.onBossCollision -= DamagePlayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        EventsManager.isBossDead = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Q) && !EventsManager.isBossDead)
    //    {
    //        bossHealth -= 1;
    //        Debug.Log("health:" + bossHealth);
    //    }

    //    if(bossHealth == 0)
    //    {
    //        EventsManager.setGameOver();
    //        EventsManager.isBossDead = true;
    //        Debug.Log("Dead");
    //    }
    //}

    private void DamagePlayer()
    {
        playerHealth -= 1;
        Debug.Log("Remaining:" + playerHealth);
        if (playerHealth == 0)
        {
            EventsManager.setGameOver();
        }
    }
}
