using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeLight : MonoBehaviour
{
    public float speed;
    public Light it;
    private int time;
    private int updateInterval = 0;
    private string cycleOption = "0";
    
    void Start()
    {
        //Get local time
        time = DateTime.Now.Hour;

        ChangeCycleOption(cycleOption);
    }

    void Update ()
    {
        if (cycleOption.Equals("2"))
        {
            //Get local time
            if (updateInterval < 300) updateInterval += 1;
            else
            {
                updateInterval = 0;
                time = DateTime.Now.Hour;
            }

            //Change light
            if (time >= 6 && time <= 19)
            {
                if (it.intensity < 3) it.intensity += speed;
            }
            else if (it.intensity > 1f)
                it.intensity -= speed;
        }
    }

    public void ChangeCycleOption(string num)
    {
        cycleOption = num;
        if (cycleOption.Equals("0"))
        {
            it.intensity = 3;
        } else if (cycleOption.Equals("1"))
        {
            it.intensity = 1f;
        } else if (cycleOption.Equals("2"))
        {
            //Change light
            if (time >= 6 && time <= 19)
                it.intensity = 3;
            else it.intensity = 1f;
        }
    }
    
}
