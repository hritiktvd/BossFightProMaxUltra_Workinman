using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public List<bool> Endpoints;
    private int endpointsTotal, endpointsCompleted;

    private void OnEnable()
    {
        EventsManager.onGameStart += StartGame;
    }

    private void OnDisable()
    {
        EventsManager.onGameStart -= StartGame;
    }

    private void StartGame()
    {
        for (int i = 0; i < Endpoints.Count; i++)
        {
            Endpoints[i] = false;
        }
        endpointsTotal = 0;
        endpointsCompleted = 0;
        for(int i = 0; i<= Endpoints.Count; i++)
        {
            endpointsTotal += i;
        }
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Endpoint1"&& !Endpoints[0])
        {
            Endpoints[0] = true;
            CheckEndPoints(1);
            Debug.Log("Reached top 1");
            GameState.switchDifficulty();
        }

        else if (other.gameObject.tag == "Endpoint2"&&!Endpoints[1])
        {
            Endpoints[1] = true;
            CheckEndPoints(2);
            Debug.Log("Reached top 2");
            GameState.switchDifficulty();
        }

        else if (other.gameObject.tag == "Endpoint3" && !Endpoints[2])
        {
            Endpoints[2] = true;
            CheckEndPoints(3);
            Debug.Log("Reached top 3");
            GameState.switchDifficulty();
        }

        else if (other.gameObject.tag == "Endpoint4" && !Endpoints[3])
        {
            Endpoints[3] = true;
            CheckEndPoints(4);
            Debug.Log("Reached top 4");
            GameState.switchDifficulty();
        }

        else if (other.gameObject.tag == "Endpoint5" && !Endpoints[4])
        {
            Endpoints[4] = true;
            CheckEndPoints(5);
            Debug.Log("Reached top 5");
            GameState.switchDifficulty();
        }
    }

    private void CheckEndPoints(int endpointID)
    {
        endpointsCompleted += endpointID;
        Debug.Log("Total Completed:" + endpointsCompleted);
        if(endpointsCompleted == endpointsTotal) { Debug.Log("Game Over"); }
    }

}
