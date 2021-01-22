using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    public float strafeWidth;
    public float startingPosition;
    private float startingTime;
    public Sprite[] bubbles;

    private void Start()
    {
        //Set starting position
        startingPosition = transform.position.x;

        //Change size of bubble
        var index = Random.Range(0, bubbles.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = bubbles[index];

        startingTime = Random.Range(0, 300);
    }

    void Update ()
    {
        Vector2 newPosition = transform.position;
        newPosition.x += Mathf.Sin(startingTime + Time.time * xSpeed) * Time.deltaTime * strafeWidth;
        newPosition.y += ySpeed * Time.deltaTime;
        transform.position = newPosition;

        //Delete bubble
        if (transform.position.y > 6) Destroy(gameObject);
    }
}
