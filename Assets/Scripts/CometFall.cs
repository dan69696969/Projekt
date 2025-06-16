using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometFall : MonoBehaviour
{
    Rigidbody2D rb;
    float randomForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomForce = Random.Range(6, 8);
        Destroy(gameObject, 2);
    }

    void Update()
    {
        rb.AddForce(Vector2.right * randomForce, ForceMode2D.Impulse);
    }
}
