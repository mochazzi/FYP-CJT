using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuModuleTwo : MonoBehaviour
{
    [Header("UI Page")]
    public GameObject mainMenu;

    [Header("Main Menu Buttons")]
    public Button menuButton; //Main Menu Button
    public Button quitButton;

    public List<Button> returnButtons;


    void Start()
    {
        EnableMainMenu();

        //Hook events
        menuButton.onClick.AddListener(StartMainMenu);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Scene Transitions to module 1 when respective button is pressed
    public void StartMainMenu()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }
    public void HideAll()
    {
        mainMenu.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
    }

}
