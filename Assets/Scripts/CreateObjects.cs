using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour {

    public GameObject[] foregroundObject, middlegroundObject, backgroundObject;
    public Camera cam;

    private int maxForegroundFrequency = 10;
    private int maxMiddlegroundFrequency = 15;
    private int maxBackgroundFrequency = 30;

    private float foregroundTimer, middlegroundTimer, backgroundTimer;

    Collider2D col;

    void Start()
    {
        foregroundTimer = ResetTimer(5, maxForegroundFrequency);
        middlegroundTimer = ResetTimer(8, maxMiddlegroundFrequency);
        backgroundTimer = ResetTimer(20, maxBackgroundFrequency);
    }

    void Update()
    {
        foregroundTimer -= Time.deltaTime;
        middlegroundTimer -= Time.deltaTime;
        backgroundTimer -= Time.deltaTime;
        if (foregroundTimer <= 0) {
            Create(foregroundObject);
            foregroundTimer = ResetTimer(5, maxForegroundFrequency);
        }
        if (middlegroundTimer <= 0)
        {
            Create(middlegroundObject);
            middlegroundTimer = ResetTimer(8, maxMiddlegroundFrequency);
        }
        if (backgroundTimer <= 0)
        {
            Create(backgroundObject);
            backgroundTimer = ResetTimer(20, maxBackgroundFrequency);
        }
    }

    private int ResetTimer(int minimumFrequency, int maxFrequency)
    {
        return Random.Range(minimumFrequency, maxFrequency);
    }

    void Create(GameObject[] objectType)
    {
        //Choose random object of type
        var index = Random.Range(0, objectType.Length);

        //Get position
        Sprite sprite = objectType[index].GetComponent<SpriteRenderer>().sprite;
        Vector2 edge = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        float sprite_width = sprite.rect.width / sprite.pixelsPerUnit;
        Vector2 pos = new Vector2(edge.x + sprite_width/2, -3);

        //Check for collision in area
        Vector2 sprite_size = sprite.rect.size / sprite.pixelsPerUnit;
        int layerMask = 1 << objectType[index].layer;
        col = Physics2D.OverlapBox(pos, sprite_size, 0, layerMask); 

        //Create object if no collision was found
        if (col == null) Instantiate(objectType[index], pos, Quaternion.identity);
    }
}
