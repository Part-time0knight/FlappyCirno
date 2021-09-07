using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Game : MonoBehaviour, IGameController
{
    //[SerializeField] private float gameSpeed = 3;
    private IPlayerController playerController;
    private ILevelController levelController;
    private ILoadController load;
    private IInput input;
    private IHUD HUDController;
    private Settings settings;
    private readonly List<ISubscriber> subscribers = new List<ISubscriber>();
    private bool _pause = false;
    public bool pause
    {
        get
        {
            return _pause;
        }
        set
        {
            _pause = value;
            playerController.pause = value;
            input.pause = value;
            levelController.pause = value;
        }
    }
    [Inject]
    private void Construct(IPlayerController player, ILevelController level,
        ILoadController load, IInput input, IHUD HUD, Settings settings)
    {
        this.load = load;
        playerController = player;
        this.input = input;
        HUDController = HUD;
        levelController = level;
        this.settings = settings;
    }
    private void Start()
    {
        playerController.FlyMode();
        levelController.InitLevel(settings.gameSpeed);
        load.LoadGame();
    }
    public void EndGame()
    {
        levelController.StopLevel();
        input.pause = true;
        HUDController.EndGame();
    }

    public void StartGame()
    {
        playerController.JumpMode();
        levelController.StartLevel();
    }
}
