using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFish : MonoBehaviour
{
    private float maxSpeed = 20f;
    private float acceleration = 5f;
    private float currentSpeed = 0;

    public Vector2 goal;
    private Vector2 startPosition;
    private float distance;
    private float moveTimer;

    private bool moving = false;

    float sprite_width;

    void Start()
    {
        startPosition = transform.position;
        goal = startPosition;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        sprite_width = sprite.rect.width / sprite.pixelsPerUnit;

        moveTimer = Random.Range(1f, 4f);
    }

    void Update()
    {

        if (moving == false)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0)
            {
                StartMoving(new Vector2(startPosition.x + (Random.Range(-6f, 6f)), Random.Range(-4f, 0f)));
            }
        }

        else if (moving)
        {
            if (Vector2.Distance(transform.position, goal) > distance / 2)
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
            else if (Vector2.Distance(transform.position, goal) < distance / 2)
            {
                currentSpeed -= acceleration * Time.deltaTime;
            }
            if (currentSpeed > maxSpeed) { currentSpeed = maxSpeed; }
            if (currentSpeed < 0) { currentSpeed = 0; }

            transform.position = Vector2.MoveTowards(transform.position, goal, currentSpeed*Time.deltaTime);
            if (currentSpeed <= 0)
            {
                moving = false;
                moveTimer = Random.Range(1f, 4f);
            }
        }

        //Destroy
        Vector2 edge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        float xpos = -(edge.x + sprite_width / 2);
        if (transform.position.x < xpos) Destroy(this.gameObject);
    }

    public bool isMoving()
    {
        return moving;
    }
    public void StartMoving(Vector2 g)
    {
        startPosition = transform.position;                                                     //Get starting position of this movement

        goal = g;
        var direction = Mathf.Sign(goal.x - transform.position.x);                              //Set direction
        transform.localScale = new Vector2(-direction, 1);                                   //Flip sprite

        distance = Vector2.Distance(startPosition, goal);

        moving = true;
    }
}
