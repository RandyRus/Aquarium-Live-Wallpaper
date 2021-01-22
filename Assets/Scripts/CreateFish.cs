using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFish : MonoBehaviour
{
    public GameObject[] lowFish;
    public GameObject[] schoolFish;
    public GameObject[] highFish;

    private int lowFishFrequency = 10;
    private int schoolFishFrequency = 12;
    private int highFishFrequency = 18;

    private float lowFishTimer, schoolFishTimer, highFishTimer;

    private Vector2 pos;

    private void Start()
    {
        lowFishTimer =    Random.Range(2, lowFishFrequency);
        schoolFishTimer = Random.Range(0, schoolFishFrequency);
        highFishTimer =   Random.Range(3, highFishFrequency);
    }

    private void Update()
    {
        lowFishTimer    -= Time.deltaTime;
        schoolFishTimer -= Time.deltaTime;
        highFishTimer   -= Time.deltaTime;

        //Low Fish
        if (lowFishTimer <= 0)
        {
            var index = Random.Range(2, lowFish.Length);
            pos = GetPosition(lowFish[index].GetComponent<SpriteRenderer>().sprite, -4f);

            Instantiate(lowFish[index], pos, Quaternion.identity);
            lowFishTimer = Random.Range(0, lowFishFrequency);
        }

        //School Fish
        if (schoolFishTimer <= 0)
        {
            //Get start side
            int direction;
            if (Random.Range(0, 2) == 0) direction = -1;
            else direction = 1;

            var index = Random.Range(0, schoolFish.Length);
            pos = GetPosition(schoolFish[index].GetComponent<SpriteRenderer>().sprite, 0f);
            pos = new Vector2((pos.x + 1) * direction, pos.y);

            int schoolFishCount = Random.Range(3, 11);
            for (int i = 0; i < schoolFishCount; i++)
            {
                float offsetx = Random.Range(-1f, 1f);
                float offsety = Random.Range(-1f, 1f);
                Vector2 newPos = new Vector2(pos.x + offsetx, pos.y + offsety);
                GameObject fish = Instantiate(schoolFish[index], newPos, Quaternion.identity);
                fish.GetComponent<SchoolFish>().direction = -direction;
            }
            schoolFishTimer = Random.Range(0, schoolFishFrequency);
        }
        //High Fish
        if (highFishTimer <= 0)
        {
            //Get start side
            int direction;
            if (Random.Range(0, 2) == 0) direction = -1;
            else direction = 1;

            var index = Random.Range(0, highFish.Length);
            pos = GetPosition(highFish[index].GetComponent<SpriteRenderer>().sprite, 0f);
            pos = new Vector2(pos.x * direction, pos.y);

            GameObject fish = Instantiate(highFish[index], pos, Quaternion.identity);
            fish.GetComponent<HighFish>().direction = -direction;

            highFishTimer = Random.Range(3, highFishFrequency);
        }
    }

    Vector2 GetPosition(Sprite sprite, float min)
    {
        Vector2 edge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        float sprite_width = sprite.rect.width / sprite.pixelsPerUnit;
        Vector2 pos = new Vector2(edge.x + sprite_width/2 , Random.Range(min, 4f));
        return pos;
    }
}
