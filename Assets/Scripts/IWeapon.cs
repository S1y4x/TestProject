using UnityEngine;

public interface IWeapon
{
    void Shoot();
    void Reload();
    int GetMagSize();
}
