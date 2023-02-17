using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 100;
        EventsManager.isBossDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && !EventsManager.isBossDead)
        {
            bossHealth -= 1;
            Debug.Log("health:" + bossHealth);
        }

        if(bossHealth == 0)
        {
            EventsManager.setGameOver();
            EventsManager.isBossDead = true;
            Debug.Log("Dead");
        }
    }
}
