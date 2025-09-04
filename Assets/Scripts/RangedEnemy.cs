using System.Collections;
using UnityEngine;

public class RangedEnemy : EnemyLogic
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private float offset = 4f;

    private bool canCast = true;
    public override void MoveToPlayer()
    {
        Vector2 playerPos = player.transform.position;
        if (Mathf.Abs(Vector2.Distance(playerPos, transform.position)) >= distance + offset)
        {
            Vector2 enemyPos = transform.position;
            Vector2 direction = (playerPos - enemyPos).normalized;
            transform.Translate(direction * speed, Space.World);
        }
        else if (canCast)
        {
            StartCoroutine(CastFireBall(playerPos));
        }
    }

    private IEnumerator CastFireBall(Vector2 playerPos)
    {
        canCast = false;
        GameObject projectile = Instantiate(fireBall, transform.position, transform.rotation);
        projectile.GetComponent<FireBallLogic>().Initialize(playerPos);
        yield return new WaitForSeconds(5f);
        canCast = true;
    }
}
