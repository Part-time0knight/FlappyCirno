using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float force;
    private Rigidbody2D rigid;
    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Fall()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector3(0, -force, 0));
    }

    public void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector3(0, force, 0));
    }
}
