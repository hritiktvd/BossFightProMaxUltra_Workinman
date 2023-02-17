using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCGLevelGenerator : MonoBehaviour
{
    private enum Difficulty { Baby, Easy, Medium, Hard, Titan}
    Difficulty difficulty;

    [SerializeField]
    private GameObject PCGCube;

    // Start is called before the first frame update
    void Start()
    {

        difficulty = Difficulty.Baby;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Difficulty:" + difficulty);
        if (Input.GetKey(KeyCode.C))
        {
            difficulty = (Difficulty)Random.Range(0,4);
            Debug.Log("Difficulty:" + difficulty);
        }
    }

    private void GenerateBlock()
    {
        
    }
    
    private void GenerateLevel()
    {

    }
}
