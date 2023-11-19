using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuModuleOne : MonoBehaviour
{
    [Header("UI Page")]
    public GameObject mainMenu;

    [Header("Main Menu Buttons")]
    public Button menuButton; //Main Menu Button
    public Button twoButton; //Module 2 Button
    public Button quitButton;

    public List<Button> returnButtons;


    void Start()
    {
        EnableMainMenu();

        //Hook events
        menuButton.onClick.AddListener(StartMainMenu);
        twoButton.onClick.AddListener(StartModuleTwo);
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

    //Scene transitions to module 2 when respective button is pressed
    public void StartModuleTwo()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(2);
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
