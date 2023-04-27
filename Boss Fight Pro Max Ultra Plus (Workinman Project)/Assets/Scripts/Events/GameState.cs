using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int DifficultyID;


    private void OnEnable()
    {
        EventsManager.onGamePaused += PauseGame;
        EventsManager.onMainMenu += PauseGame;
        EventsManager.onResume += ResumeGame;
    }
    private void OnDisable()
    {
        EventsManager.onGamePaused -= PauseGame;
        EventsManager.onMainMenu -= PauseGame;
        EventsManager.onResume -= ResumeGame;
    }


    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void switchDifficulty()
    {
        if (DifficultyID < 5) // 5 levels of difficulty. Same as difficultyVariables.count but this is a static function
        {
            DifficultyID++;
            Debug.Log("Difficulty is: " + DifficultyID);
            EventsManager.ChangeDifficulty();
        }
        else
        {
            Debug.Log("Max Difficulty Reached");
        }
    }


}
