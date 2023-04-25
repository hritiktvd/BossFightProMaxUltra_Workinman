using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private void OnEnable()
    {
        EventsManager.onBossCollision += DamagePlayer;
        EventsManager.onGameStart += StartGame;
    }

    private void OnDisable()
    {
        EventsManager.onBossCollision -= DamagePlayer;
        EventsManager.onGameStart -= StartGame;
    }
    // Start is called before the first frame update
    private void StartGame()
    {
        EventsManager.playerHealth = 100;
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
        EventsManager.playerHealth -= 0.5f;
        Debug.Log("Remaining:" + EventsManager.playerHealth);
        if (EventsManager.playerHealth == 0)
        {
            EventsManager.setGameOver();
        }
    }
}
