using UnityEngine;

public class MouseCtrl : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition );

        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;
        float angle = Mathf.Atan2( direction.x, direction.y ) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler( 0f, 0f, angle * -1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
    }
}
