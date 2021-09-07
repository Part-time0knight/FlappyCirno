using UnityEngine;
using Zenject;

public class PlayerCollision : MonoBehaviour
{
    private IPlayerController player;
    [Inject] private void Construct(IPlayerController player)
    {
        this.player = player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetPoint();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.Hit();
    }
}
