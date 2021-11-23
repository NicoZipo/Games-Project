using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenus : MonoBehaviour
{
    
    public GameObject NotebookUI;
    bool NotebookIsOpen = false;
    public static bool openNotebookAgain = false;

    public GameObject PauseMenuUI;
    bool GamePaused = false;    

    void Start() {
        NotebookUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PauseMenuUI.SetActive(false);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {

            if (NotebookIsOpen) {
                ResumeNotebook();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                if (!GamePaused && !Dialogues.dialogueIsOpen) {
                    PauseNotebook();
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GamePaused) {
                ResumeGame();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                ResumeNotebook();
                PauseGame();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }

    }

     public void ResumeNotebook() {
        NotebookUI.SetActive(false);
        Time.timeScale = 1;
        NotebookIsOpen = false;
        openNotebookAgain = true;
    }

    public void PauseNotebook() {
        NotebookUI.SetActive(true);
        Time.timeScale = 0;
        NotebookIsOpen = true;
    }

    public void ResumeGame() {
        PauseMenuUI.SetActive(false);
        if (!Dialogues.dialogueIsOpen) {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 0;
        }
        GamePaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }

    public void LoadMenu() {
        Debug.Log("Loading Menu...");
        //Time.timeScale = 1f; // should be activated when StartMenu is implemented!
        //SceneManager.LoadScene("[VariableForStartMenu]");
    }

    public void GameState() {
        Debug.Log("Saving Game...");
        // call function for saving game
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}
