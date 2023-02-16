using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField]
    private float maxFuel = 100f;

    CharacterController characterController;

    private float remainingFuel;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventsManager.onJetpackStart += Fly;
        EventsManager.JetpackON = false;
    }

    private void OnDisable()
    {
        EventsManager.onJetpackStart -= Fly;
    }

    private void Update()
    {
        if (characterController.isGrounded && !EventsManager.JetpackON)
            regenFuel();
    }

    private void Start()
    {
        remainingFuel = maxFuel;
        characterController = GetComponent<CharacterController>();
    }
    private void Fly()
    {
        if (remainingFuel > 0)
        {
            EventsManager.JetpackON = true;
            remainingFuel -= 1;
            Debug.Log("Remaining Fuel is:" + remainingFuel);
        }
        else
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
