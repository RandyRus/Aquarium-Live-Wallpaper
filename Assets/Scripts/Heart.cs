using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float speed = 0.7f;
    private float alphaSpeed = 0.5f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Color c = transform.GetComponent<SpriteRenderer>().color;
        c.a -= alphaSpeed * Time.deltaTime;

        if (c.a <= 0)
        {
            Destroy(gameObject);
        }

        transform.GetComponent<SpriteRenderer>().color = c;
    }
}
