using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void GamePaused();
    public static event GamePaused onGamePaused;

    public delegate void MainMenu();
    public static event MainMenu onMainMenu;

    public delegate void Resume();
    public static event Resume onResume;

    public static bool isPaused;
    public static bool isMainMenu;
    public static bool isResumed;

    public static void PauseGame() { onGamePaused?.Invoke(); }
    public static void ShowMainMenu() { onMainMenu?.Invoke(); }
    public static void ResumeGame() { onResume?.Invoke(); }
    public static void ResetUI()
    {
        isPaused = false;
        isMainMenu = false;
    }

}
