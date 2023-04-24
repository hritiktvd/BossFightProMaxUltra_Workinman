using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tower1")
        {
            Debug.Log("Reached Tower 1");
            EventsManager.TowerID = 0;
            EventsManager.EnterTower();
            EventsManager.TowerReached = true;
        }

        else if (other.gameObject.tag == "Tower2")
        {
            Debug.Log("Reached Tower 2");
            EventsManager.TowerID = 1;
            EventsManager.TowerReached = true;
            EventsManager.EnterTower();
        }

        else if (other.gameObject.tag == "Tower3")
        {
            Debug.Log("Reached Tower 3");
            EventsManager.TowerID = 2;
            EventsManager.TowerReached = true;
            EventsManager.EnterTower();
        }
        else if (other.gameObject.tag == "Tower4")
        {
            Debug.Log("Reached Tower 4");
            EventsManager.TowerID = 3;
            EventsManager.TowerReached = true;
            EventsManager.EnterTower();
        }
        else if (other.gameObject.tag == "Tower5")
        {
            Debug.Log("Reached Tower 5");
            EventsManager.TowerID = 4;
            EventsManager.TowerReached = true;
            EventsManager.EnterTower();
        }

        if(other.gameObject.tag == "BadGuy")
        {
            EventsManager.CollideBoss();
        }
        else
        {
            EventsManager.isBossColliding = false;
        }
    }

}
