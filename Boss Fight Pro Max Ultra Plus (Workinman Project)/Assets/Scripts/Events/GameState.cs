using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private void Start()
    {
        EventsManager.onGamePaused += PauseGame;
        EventsManager.onMainMenu += PauseGame;
        EventsManager.onResume += ResumeGame;
    }

    private void OnDestroy()
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

}
