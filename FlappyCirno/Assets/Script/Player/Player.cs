using UnityEngine;
using Zenject;
public class Player : MonoBehaviour, IPlayerController
{
    private IMovement movement;
    private IViewController view;
    private ISoundController sound;
    private IGameController gameController;
    IScoreController score;
    private Settings settings;
    private int scoreForTube;
    private int hp = 1;
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
            movement.freeze = value;
            view.freeze = value;
        }
    }
    [Inject]
    private void Construct(IGameController game, IMovement movement,
        IViewController view, ISoundController sound, Settings settings,
        IScoreController score)
    {
        this.movement = movement;
        this.view = view;
        gameController = game;
        this.sound = sound;
        this.settings = settings;
        scoreForTube = settings.scoreForTube;
        this.score = score;
    }
    public void MakeJump()
    {
        view.PlayJump();
        movement.Jump();
        sound.PlayJump();
    }
    public void Hit()
    {
        hp--;
        if (DieCheck())
            Die();
    }
    private bool DieCheck()
    {
        if (hp <= 0)
            return true;
        return false;
    }
    private void Die()
    {
        gameController.EndGame();
        movement.Fall();
        view.PlayFall();
        sound.PlayDie();
    }

    public void FlyMode()
    {
        movement.fly = true;
        view.PlayFly = true;
    }

    public void JumpMode()
    {
        movement.fly = false;
    }

    public void GetPoint()
    {
        score.score += scoreForTube;
        sound.PlayPoint();
    }
}
