using UnityEngine;
using UnityEngine.UI;
public class CanvasUpdate : MonoBehaviour
{
    public Text bulletText;

    private void OnEnable()
    {
        Weapon.OnShotMade += UpdateCanvas;
        WeaponChanger.OnWeaponChanged += UpdateCanvas;
    }
    private void OnDisable()
    {
        Weapon.OnShotMade -= UpdateCanvas;
        WeaponChanger.OnWeaponChanged -= UpdateCanvas;
    }
    void UpdateCanvas(int bullets)
    {
        if (bulletText != null)
        {
            bulletText.text = $"Bullets x{bullets}";
        }
    }
}
