using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenu : MonoBehaviour, IMenu
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Toggle toggleMusic;
    [SerializeField] private Toggle toggleSfx;
    private ISceneController sceneController;
    private ILoadController load;
    private ISoundController sound;
    private Settings settings;
    private bool _music = true;
    private bool _sfx = true;
    public bool music
    {
        get
        {
            return _music;
        }
        set
        {
            _music = value;
            settings._music = value;
            if (sound != null)
                sound.music = value;
            load.SafeSetting();
        }
    }
    public bool sfx
    {
        get
        {
            return _sfx;
        }
        set
        {
            _sfx = value;
            settings._sfx = value;
            if (sound != null)
                sound.sfx = value;
            load.SafeSetting();
        }
    }

    [Inject]
    private void Construct(ISceneController sceneController, Settings settings, ISoundController sound, ILoadController load)
    {
        this.sceneController = sceneController;
        this.settings = settings;
        this.sound = sound;
        this.load = load;
    }
    private void Start()
    {
        load.LoadSetting();
        music = settings._music;
        sfx = settings._sfx;
        toggleSfx.isOn = sfx;
        toggleMusic.isOn = music;
        
    }
    private void CloseMenu()
    {
        mainPanel.SetActive(false);
        scorePanel.SetActive(false);
        settingPanel.SetActive(false);
    }
    public void Exit()
    {
        sceneController.Exit();
    }

    public void GoMineMenu()
    {
        CloseMenu();
        mainPanel.SetActive(true);
    }

    public void GoScore()
    {
        CloseMenu();
        scorePanel.SetActive(true);
    }

    public void GoSetting()
    {
        CloseMenu();
        settingPanel.SetActive(true);
    }
}
