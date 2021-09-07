using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour, IMovement
{
    private float force;
    private Rigidbody2D rigid;
    private bool _fly = false;
    private bool _freeze = false;
    private Vector2 velocityTemp = Vector2.zero;
    private Settings settings;
    public bool freeze
    {
        get { return _freeze; }
        set
        {
            _freeze = value;
            if(value)
            {
                rigid.gravityScale = 0f;
                velocityTemp = rigid.velocity;
                rigid.velocity = Vector2.zero;
            }
            else
            {
                rigid.velocity = velocityTemp;
                fly = _fly;
            }
        }
    }
    public bool fly
    {
        get { return _fly; }
        set
        {
            _fly = value;
            if (rigid)
                if (value)
                {
                    rigid.gravityScale = 0f;
                    rigid.velocity = Vector2.zero;
                }
                else
                    rigid.gravityScale = 1f;
        }
    }
    [Inject]
    private void Construct(Settings settings)
    {
        this.settings = settings;
        force = settings.jumpForce;
    }
    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        fly = _fly;
    }

    public void Fall()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector3( 0f, -force, 0f));
    }

    public void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(new Vector3(0f, force, 0f));
    }
}
