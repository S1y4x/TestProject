using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using System;

public class WeaponChanger : MonoBehaviour
{
    private int currentWeapon = 0;
    private List<IWeapon> weapons;

    public static Action<int> OnWeaponChanged;
    private void Start()
    {
        weapons = GetComponentsInChildren<IWeapon>(true).ToList();

        UpdateWeapon();
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
            NextWeapon();
        else if (Input.mouseScrollDelta.y < 0)
            PreviousWeapon();
    }

    private void NextWeapon()
    {
        currentWeapon++;
        if (currentWeapon >= weapons.Count)
            currentWeapon = 0;

        UpdateWeapon();
    }

    private void PreviousWeapon()
    {
        currentWeapon--;
        if (currentWeapon < 0)
            currentWeapon = weapons.Count - 1;

        UpdateWeapon();
    }

    private void UpdateWeapon()
    {
        if(weapons == null) return;

        for (int i = 0; i < weapons.Count; i++)
        {
            MonoBehaviour weapon = weapons[i] as MonoBehaviour;
            weapon.gameObject.SetActive(i == currentWeapon);
            if (i == currentWeapon)
            {
                OnWeaponChanged?.Invoke(weapon.GetComponent<Weapon>().GetMagSize());
                Debug.Log(weapon.GetComponent<Weapon>().GetMagSize());
            }
        }
    }
}
