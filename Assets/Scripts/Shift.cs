using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{
    string[] thingsToShift = { "Object", "LowFish" , "SchoolFish", "Background", "Sand", "HighFish", "Bubble", "Heart" }; //Add new things here

    void Update()
    {
        foreach (string tag in thingsToShift)
        {
            GameObject[] things = GameObject.FindGameObjectsWithTag(tag);

            //Shift and destroy objects
            for (var i = 0; i < things.Length; i++)
            {
                things[i].transform.Translate(Vector3.left * (things[i].GetComponent<Attributes>().shiftSpeed) * Time.deltaTime);

                //Destroy fish and objects
                if (tag == "Object" || tag == "LowFish" || tag == "SchoolFish" || tag == "HighFish")
                {
                    if (things[i].transform.position.x < -30 || things[i].transform.position.x > 30) Destroy(things[i]);
                }
                //Move goal of low fish
                if (tag == "LowFish")
                {
                    things[i].GetComponent<LowFish>().goal.x -= things[i].GetComponent<Attributes>().shiftSpeed * Time.deltaTime;
                }
                //Move bubble starting position
                if (tag == "Bubble")
                {
                    things[i].GetComponent<Bubbles>().startingPosition -= things[i].GetComponent<Attributes>().shiftSpeed * Time.deltaTime;
                }

                //Reset background and sand position
                if (tag == "Background" || tag == "Sand")
                {
                    if (things[i].transform.position.x <= -50)
                    {
                        things[i].transform.position = new Vector3(0, things[i].transform.position.y, things[i].transform.position.z);
                    }
                }
            }
        }
    }
}
