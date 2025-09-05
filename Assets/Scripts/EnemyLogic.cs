using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    protected GameObject player;
    protected float speed = .2f;
    protected float distance = 1f;
    protected float damage = 10f;

    private void Start()
    {
        try
        {
            player = FindFirstObjectByType<PlayerCtrl>().gameObject;
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    private void FixedUpdate()
    {
        if (player == null) return;

       MoveToPlayer();
    }

    public virtual void MoveToPlayer()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 enemyPos = transform.position;
        Vector2 direction = (playerPos - enemyPos).normalized;

        transform.Translate(direction * speed, Space.World);

        if (Mathf.Abs(Vector2.Distance(playerPos, transform.position)) <= distance)
        {
            player.GetComponent<HealthLogic>().DamageDelt(damage);
            Destroy(gameObject);
        }
    }
}
