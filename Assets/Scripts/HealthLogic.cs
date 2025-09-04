using UnityEngine;
using UnityEngine.UI;
public class HealthLogic : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public Slider healthBar;
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void DamageDelt(float damage)
    {
        health -= damage;
        
        if(healthBar != null)
            UpdateUI();
    }

    void UpdateUI()
    {
        healthBar.value = health;
    }
}
