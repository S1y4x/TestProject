using System.Collections;
using UnityEngine;

public class FireBallLogic : MonoBehaviour
{
    [SerializeField] private float damage = 5;
    [SerializeField] private float speed = 5;

    private Rigidbody2D rb;
    private Vector2 direction;
    private float lifeTime = 5f;

    public void Initialize(Vector2 moveDirection)
    {
        Vector2 position = transform.position;
        direction = (moveDirection - position).normalized;
        rb.linearVelocity = direction * speed;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthLogic>().DamageDelt(damage);
            Destroy(gameObject);
        }
    }
}
