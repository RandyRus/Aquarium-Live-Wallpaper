using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolFish : MonoBehaviour
{
    private float speed = 2.5f;
    public int direction;

    float sprite_width;

    private void Start()
    {
        transform.localScale = new Vector3(-direction, 1, 1);

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        sprite_width = sprite.rect.width / sprite.pixelsPerUnit;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (speed * direction * Time.deltaTime), transform.position.y, transform.position.z);
        //transform.localScale = new Vector3(-direction, 1, 1);

        //Destroy
        Vector2 edge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));

        float xpos = (edge.x + sprite_width / 2) + 2;
        if (transform.position.x > xpos) Destroy(this.gameObject);

        xpos = -(edge.x + sprite_width / 2) -2;
        if (transform.position.x < xpos) Destroy(this.gameObject);
    }
}
