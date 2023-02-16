using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField]
    private float maxFuel = 100f;

    CharacterController characterController;

    public static float remainingFuel;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventsManager.onJetpackStart += fly;
        EventsManager.onJetpackOff += dontFly;
    }

    private void OnDisable()
    {
        EventsManager.onJetpackStart -= fly;
        EventsManager.onJetpackOff -= dontFly;
    }

    private void Start()
    {
        remainingFuel = maxFuel;
        EventsManager.JetpackON = false;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.isGrounded && !EventsManager.JetpackON)
            regenFuel();
    }
    private void fly()
    {
        if (remainingFuel > 0)
        {
            EventsManager.JetpackON = true;
            remainingFuel -= 1;
        }
        else
            EventsManager.JetpackON = false;

        Debug.Log("Remaining Fuel is:" + remainingFuel);
    }

    private void dontFly()
    {
        EventsManager.JetpackON = false;
    }

    private void regenFuel()
    {
        if (characterController.isGrounded && remainingFuel <= maxFuel)
        {
            remainingFuel += 3;
            Debug.Log("Refueling Fuel: " + remainingFuel);
        }
    }
}
