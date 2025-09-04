using UnityEngine;
public class PlayerCtrl : MonoBehaviour
{
    Vector2 screenBoundaries;
    Vector2 viewPos;
    public float speed;

    private float horizontalInput;
    private float verticalInput;

    private SpriteRenderer spriteRenderer;
    Vector2 characterHalfSize;
    private void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horExtent = vertExtent * Camera.main.aspect;
        screenBoundaries = new Vector2(horExtent, vertExtent);

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            characterHalfSize = spriteRenderer.bounds.extents;
        else
            characterHalfSize = Vector2.one * .5f;

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;
    }

    private void CharacterMove()
    {
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0));
    }
    private void FixedUpdate()
    {
        CharacterMove();
    }

    private void LateUpdate()
    {
        viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBoundaries.x + characterHalfSize.x, screenBoundaries.x - characterHalfSize.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBoundaries.y + characterHalfSize.y, screenBoundaries.y - characterHalfSize.y);
        transform.position = viewPos;
    }
}
