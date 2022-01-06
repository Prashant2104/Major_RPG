using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject InstructionPanel;
    public GameObject PauseMenu;
    public GameObject CreditsPanel;
    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnInstructionButton()
    {
        if (!InstructionPanel.activeInHierarchy)
        {
            InstructionPanel.SetActive(true);
            PauseMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(InstructionPanel.transform.GetChild(1).gameObject);
        }
        else
        {
            InstructionPanel.SetActive(false);
            PauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseMenu.transform.GetChild(0).gameObject);
        }
    }
    public void OnCreditButton()
    {
        if (!CreditsPanel.activeInHierarchy)
        {
            CreditsPanel.SetActive(true);
            PauseMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(CreditsPanel.transform.GetChild(1).gameObject);
        }
        else
        {
            CreditsPanel.SetActive(false);
            PauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(PauseMenu.transform.GetChild(0).gameObject);
        }
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
}