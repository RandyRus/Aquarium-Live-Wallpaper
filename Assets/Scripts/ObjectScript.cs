using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    float sprite_width;
    
    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        sprite_width = sprite.rect.width / sprite.pixelsPerUnit;
    }

    void Update ()
    {
        Vector2 edge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        float xpos = -(edge.x + sprite_width / 2);
        if (transform.position.x < xpos) Destroy(this.gameObject);
    }
}
