using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBounds : MonoBehaviour
{
    private BoxCollider2D topCollider;
    private BoxCollider2D bottomCollider;
    private BoxCollider2D leftCollider;
    private BoxCollider2D rightCollider;

    private void Start()
    {
        // Get the colliders
        topCollider = transform.Find("Top").GetComponent<BoxCollider2D>();
        bottomCollider = transform.Find("Bottom").GetComponent<BoxCollider2D>();
        leftCollider = transform.Find("Left").GetComponent<BoxCollider2D>();
        rightCollider = transform.Find("Right").GetComponent<BoxCollider2D>();

        // Get the screen bounds
        // float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        // float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        // float screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        // float screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        // // Adjust the colliders
        // AdjustCollider(topCollider, 0, screenTop, screenRight - screenLeft, 1);
        // AdjustCollider(bottomCollider, 0, screenBottom, screenRight - screenLeft, 1);
        // AdjustCollider(leftCollider, screenLeft, 0, 1, screenTop - screenBottom);
        // AdjustCollider(rightCollider, screenRight, 0, 1, screenTop - screenBottom);
    }

    private void AdjustCollider(BoxCollider2D collider, float x, float y, float width, float height)
    {
        collider.offset = new Vector2(x, y);
        collider.size = new Vector2(width, height);
    }
}
