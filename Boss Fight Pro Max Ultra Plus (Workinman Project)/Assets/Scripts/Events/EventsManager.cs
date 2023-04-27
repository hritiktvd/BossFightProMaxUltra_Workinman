using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public delegate void GameStarted();
    public static event GameStarted onGameStart;

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

    public delegate void GameWin();
    public static event GameWin onGameWin;

    public delegate void TowerEnter();
    public static event TowerEnter onTowerEnter;

    public delegate void BossCollision();
    public static event BossCollision onBossCollision;

    public delegate void Difficulty();
    public static event Difficulty onDifficultyChange;

    public static bool isPaused;
    public static bool isMainMenu;
    public static bool isResumed;
    public static bool JetpackON;
    public static bool isBossDead;
    public static bool TowerReached;
    public static int TowerID;
    public static bool isBossColliding;
    public static float maxFuel;
    public static float playerHealth;
    public static float maxHealthPerLevel;

    public static void ChangeDifficulty() { onDifficultyChange?.Invoke(); }
    public static void GameStart() { onGameStart?.Invoke(); } 
    public static void PauseGame() { onGamePaused?.Invoke(); }
    public static void ShowMainMenu() { onMainMenu?.Invoke(); }
    public static void ResumeGame() { onResume?.Invoke(); }
    public static void JetpackStart() { onJetpackStart?.Invoke(); }
    public static void JetpackOff() { onJetpackOff?.Invoke(); }
    public static void setGameOver() { onGameOver?.Invoke(); }
    public static void EnterTower() { onTowerEnter?.Invoke(); }
    public static void WinGame() { onGameWin?.Invoke(); }
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
