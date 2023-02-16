using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<GameObject> UIPanels;

    [SerializeField]
    private Button PauseQuitButton; 

    void Start()
    {
        EventsManager.ResetUI();
        invokeMenuUI(0);
        PauseQuitButton.onClick.AddListener(delegate{ invokeMenuUI(0); });
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !EventsManager.isPaused)
        {
            invokeMenuUI(1);
        }
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
        EventsManager.ResetUI();
        Cursor.visible = false;
    }

    [ContextMenu("Quit Game")]
    public void QuitGame()
    {
        Application.Quit();
    }

}
