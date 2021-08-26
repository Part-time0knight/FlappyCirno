using UnityEngine;
using Zenject;
public class PlayerController : MonoBehaviour, IController
{
    [Inject] private IMovement movement;
    [Inject] private IViewController view;
    [Inject] private ICollision collision;

    private void Awake()
    {
        collision.Init(this);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            view.PlayJump();
            movement.Jump();
        }
    }
    public void Hit()
    {
        Die();
    }
    private void Die()
    {
        Debug.Log("you die!");
    }
}
