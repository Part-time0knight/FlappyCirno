using System.Collections;
using UnityEngine;
using Zenject;

public class InputClick : MonoBehaviour, IInput
{
    private IGameController gameController;
    private IPlayerController playerController;
    private bool makeJump = true;
    private bool start = false;
    private bool _pause = false;

    public bool pause
    {
        get { return _pause; }
        set { _pause = value; StopAllCoroutines(); }
    }
    [Inject] private void Construct(IGameController game, IPlayerController playerController)
    {
        this.playerController = playerController;
        gameController = game;
    }
    private void Update()
    {
        if (!_pause && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(DelayToJump());
        }
    }
    public void GetClick()
    {
        makeJump = false;
    }
    private IEnumerator DelayToJump()
    {
        yield return new WaitForEndOfFrame();
        if (makeJump)
        { 
            playerController.MakeJump();
            if (!start)
            {
                gameController.StartGame();
                start = true;
            }
        }
        makeJump = true;
    }
}
