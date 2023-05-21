using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject maleCircle; // Male circle GameObject
    public GameObject femaleCircle; // Female circle GameObject
    public GameObject itemPrefabGreen; // Green Item Prefab
    public GameObject itemPrefabRed;   // Red Item Prefab
    public float spawnDistance = 2.0f; // Distance at which new items are spawned
    private Color originalMaleColor;
    private Color originalFemaleColor;

    private Rigidbody2D maleRb;
    private Rigidbody2D femaleRb;
    private float moveSpeed = 50f;
    private float femaleMoveSpeed = 100f;
    private void Start()
    {
        originalMaleColor = maleCircle.GetComponent<SpriteRenderer>().color;
        originalFemaleColor = femaleCircle.GetComponent<SpriteRenderer>().color;
        maleRb = maleCircle.GetComponent<Rigidbody2D>();
        femaleRb = femaleCircle.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - maleCircle.transform.position).normalized;
        maleRb.MovePosition(maleRb.position + direction * moveSpeed * Time.deltaTime);
        
        //femaleCircle should be symmetrical with the maleCircle along the center of the screen center of the screen  
        femaleRb.MovePosition(femaleRb.position - direction * femaleMoveSpeed * Time.deltaTime);
        
        maleCircle.GetComponent<SpriteRenderer>().color = originalMaleColor;
        femaleCircle.GetComponent<SpriteRenderer>().color = originalFemaleColor;

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            DestroyItems(maleCircle, femaleCircle);
            maleCircle.GetComponent<SpriteRenderer>().color = Color.yellow; // Change male color when interaction
        }
        else if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            DestroyItems(femaleCircle, maleCircle);
            femaleCircle.GetComponent<SpriteRenderer>().color = Color.yellow; // Change female color when interaction
        }
    }

    private void DestroyItems(GameObject destroyer, GameObject spawner)
    {
        Collider2D[] items = Physics2D.OverlapCircleAll(destroyer.transform.position, 1.0f);
        foreach (Collider2D item in items)
        {
            if(item.gameObject.tag!="Player"){
                Destroy(item.gameObject);
            Instantiate(item.gameObject.tag == "Green" ? itemPrefabGreen : itemPrefabRed, spawner.transform.position + Random.insideUnitSphere * spawnDistance, Quaternion.identity);
            }
            
        }
    }
}
