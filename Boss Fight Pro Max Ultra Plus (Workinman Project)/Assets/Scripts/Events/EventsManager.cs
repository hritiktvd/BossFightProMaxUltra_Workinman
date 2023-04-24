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

    public delegate void Jetpack();
    public static event Jetpack onJetpackStart;
    public static event Jetpack onJetpackOff;

    public delegate void GameOver();
    public static event GameOver onGameOver;

    public delegate void TowerEnter();
    public static event TowerEnter onTowerEnter;

    public delegate void BossCollision();
    public static event BossCollision onBossCollision;

    public static bool isPaused;
    public static bool isMainMenu;
    public static bool isResumed;
    public static bool JetpackON;
    public static bool isBossDead;
    public static bool TowerReached;
    public static int TowerID;
    public static bool isBossColliding;

    public static void PauseGame() { onGamePaused?.Invoke(); }
    public static void ShowMainMenu() { onMainMenu?.Invoke(); }
    public static void ResumeGame() { onResume?.Invoke(); }
    public static void JetpackStart() { onJetpackStart?.Invoke(); }
    public static void JetpackOff() { onJetpackOff?.Invoke(); }
    public static void setGameOver() { onGameOver?.Invoke(); }
    public static void EnterTower() { onTowerEnter?.Invoke(); }
    public static void CollideBoss() { 
        onBossCollision?.Invoke();
        isBossColliding = true;
    }
    public static void ResetUI()
    {
        isPaused = false;
        isMainMenu = false;
    }

}
