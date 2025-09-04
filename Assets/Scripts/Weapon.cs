using System;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject muzzle;

    protected Transform shootingPosition;

    public int defaultMagSize;
    protected int magSize;

    public static Action<int> OnShotMade;
    private void Awake()
    {
        if(muzzle != null)
            shootingPosition = muzzle.transform;
        magSize = defaultMagSize;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();

        if (Input.GetMouseButtonDown(1))
            Reload();
    }
    public void Reload() 
    {
        magSize = defaultMagSize;
        OnShotMade?.Invoke(magSize);
    }
    public virtual void Shoot()
    {
        if (bullet == null || shootingPosition == null || magSize <= 0)
            return;

        Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
        magSize--;
        OnShotMade?.Invoke(magSize);
    }

    public int GetMagSize()
    {
        return magSize;
    }
}