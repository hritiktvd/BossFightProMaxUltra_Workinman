using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static bool TowerReached;
    public static int TowerID;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tower1")
        {
            Debug.Log("Reached Tower 1");
            TowerID = 0;
            EventsManager.EnterTower();
            TowerReached = true;
        }

        else if (other.gameObject.tag == "Tower2")
        {
            Debug.Log("Reached Tower 2");
            TowerID = 1;
            TowerReached = true;
            EventsManager.EnterTower();
        }

        else if (other.gameObject.tag == "Tower3")
        {
            Debug.Log("Reached Tower 3");
            TowerID = 2;
            TowerReached = true;
            EventsManager.EnterTower();
        }
        else if (other.gameObject.tag == "Tower4")
        {
            Debug.Log("Reached Tower 4");
            TowerID = 3;
            TowerReached = true;
            EventsManager.EnterTower();
        }
        else if (other.gameObject.tag == "Tower5")
        {
            Debug.Log("Reached Tower 5");
            TowerID = 4;
            TowerReached = true;
            EventsManager.EnterTower();
        }

        if(other.gameObject.tag == "BadGuy")
        {
            Debug.Log("Health Minuss");
        }
    }

}
