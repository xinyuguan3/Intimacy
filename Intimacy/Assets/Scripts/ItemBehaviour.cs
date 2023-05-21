using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 2f;
    private float rotationSpeed;
    private void Start()
    {
        if (gameObject.tag == "Green")
        {
            GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.8f, 0.4f, 1.0f); // Change to a low saturation green
        }
        else if (gameObject.tag == "Red")
        {
            GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.4f, 0.4f, 1.0f); // Change to a low saturation red
        }

        StartCoroutine(AnimateScale());

        // Random rotation speed between -90 and 90 degrees per second
        rotationSpeed = Random.Range(-90f, 90f);
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed));
    }

    private void Update()
    {
        // Rotate the item
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    IEnumerator AnimateScale()
    {
        Vector3 initialScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 finalScale = new Vector3(1.0f, 1.0f, 1.0f);
        float duration = 0.5f; // The duration of the animation

        for (float t = 0.0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            transform.localScale = Vector3.Lerp(initialScale, finalScale, normalizedTime);
            yield return null;
        }

        transform.localScale = finalScale; // Ensure the final scale is correct
    }
}
