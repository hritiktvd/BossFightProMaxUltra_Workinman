using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public List<GameObject> UIPanels;
    public TextMeshProUGUI HealthText;

    [SerializeField]
    private Button PauseQuitButton;
    [SerializeField]
    private Button ResumeButton;

    private void OnEnable()
    {
        EventsManager.onGameOver += () => invokeMenuUI(0);
        EventsManager.onGameStart += () => invokeMenuUI(2);
    }
    private void OnDisable()
    {
        EventsManager.onGameOver -= () => invokeMenuUI(0);
        EventsManager.onGameStart -= () => invokeMenuUI(2);
    }
    void Start()
    {
        EventsManager.ResetUI();
        invokeMenuUI(0);
        PauseQuitButton.onClick.AddListener(delegate{ invokeMenuUI(0); });
        ResumeButton.onClick.AddListener(delegate{ Resume(); });
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !EventsManager.isPaused)
        {
            invokeMenuUI(1);
        }
        HealthText.text = "HEALTH " + EventsManager.playerHealth;
    }

    private void invokeMenuUI(int ListID)
    {
        hideAllMenus();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (ListID == 0)
        {
            EventsManager.ShowMainMenu();
            EventsManager.isMainMenu = true;
        }

        else if (ListID == 1)
        {
            Debug.Log("Game Paused");
            EventsManager.PauseGame();
            EventsManager.isPaused = true;
        }

        UIPanels[ListID].SetActive(true);

    }

    [ContextMenu("Hide All UI Elements")]
    private void hideAllMenus()
    {
        foreach(var UI in UIPanels)
        {
            UI.SetActive(false);
        }
    }

    [ContextMenu("Resume Game")]

    public void Resume()
    {
        hideAllMenus();
        EventsManager.ResumeGame();
        invokeMenuUI(2);
        EventsManager.ResetUI();
        Cursor.visible = false;
    }

    [ContextMenu("Quit Game")]
    public void QuitGame()
    {
        Application.Quit();
    }

}
