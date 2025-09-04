using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float speed;
    float damage = 5;

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthLogic>().DamageDelt(damage);
            Destroy(gameObject);
        }
    }
}
