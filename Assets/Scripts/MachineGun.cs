using System.Collections;
using UnityEngine;

public class MachineGun : Weapon
{
    float timeBetweenShots = .1f;
    public override void Shoot()
    {
        if (bullet == null || shootingPosition == null || magSize <= 0)
            return;

        StartCoroutine("ShootThreeBullets");
    }

    private IEnumerator ShootThreeBullets()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
            magSize--;
            OnShotMade?.Invoke(magSize);
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
