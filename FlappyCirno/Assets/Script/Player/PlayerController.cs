using UnityEngine;
using Zenject;
public class PlayerController : MonoBehaviour, IController
{
    [Inject] private IMovement movement;
    [Inject] private IViewController view;
    [Inject] private ICollision collision;
    private int hp = 1;
    private bool alive = true;
    private void Awake()
    {
        collision.Init(this);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && alive)
        {
            view.PlayJump();
            movement.Jump();
        }
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
        Debug.Log("you die!");
        alive = false;
        movement.Fall();
    }
}
