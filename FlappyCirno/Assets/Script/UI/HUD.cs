using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HUD : MonoBehaviour, IHUD
{
    private IGameController game;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject inGameHud;

    private bool _pause = false;
    public bool pause
    {
        get
        {
            return _pause;
        }
        set
        {
            game.pause = value;
            if (value)
            {
                HidePanels();
                ShowPanel(pauseMenu);
            }
            else
            {
                HidePanels();
                ShowPanel(inGameHud);
            }
        }
    }
    [Inject]
    private void Construct(IGameController game)
    {
        this.game = game;
    }
    public void EndGame()
    {
        HidePanels();
        ShowPanel(endMenu);
    }

    private void HidePanels()
    {
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        inGameHud.SetActive(false);
    }
    private void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
