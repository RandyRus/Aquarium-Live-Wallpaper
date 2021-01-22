using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreen : MonoBehaviour
{
    Vector2 touchPos;
    Touch touch;
    public GameObject bubble, heart;
    public Camera cam;
    private float delay = 0.1f;
    private float delayNow;
    private bool createBubbles = false;


    void Start()
    {
        delayNow = delay;
    }
    void Update()
    {
        if (delayNow >= delay)
        {
            if (Input.touchCount > 0) {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    int layer_mask = LayerMask.GetMask("LowFish","HighFish");
                    RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(touch.position), Vector2.zero, 100, layer_mask);
                    if (hit.collider != null)
                    {
                        CreateHeart(hit.collider.gameObject.transform.position);
                        createBubbles = false;
                    }
                    else
                    {
                        createBubbles = true;
                    }
                }

                if (createBubbles)
                {
                    touchPos = touch.position;
                    Vector2 gamePos = cam.ScreenToWorldPoint(touchPos);
                    Instantiate(bubble, gamePos, Quaternion.identity);
                }
                //Reset delay
                delayNow = 0;
            }
        } else
        {
            delayNow += Time.deltaTime;
        }
    }

    private void CreateHeart(Vector2 position)
    {
        Instantiate(heart, new Vector2(position.x, position.y + 0.6f), Quaternion.identity);
    }
}
