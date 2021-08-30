using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float range = 2f;
    private Rigidbody2D body;
    private Vector3 startPosition;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        body.velocity = new Vector2(-1f * speed, 0f);
        startPosition = transform.position;
        transform.position = new Vector3(startPosition.x, startPosition.y + Random.Range(-range, range), startPosition.z);
    }
}
