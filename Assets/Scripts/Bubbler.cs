using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbler : MonoBehaviour
{
    public GameObject bubble;

    private float delay = 0.08f;
    private float delayNow;

    // Start is called before the first frame update
    void Start()
    {
        delayNow = delay;
    }

    // Update is called once per frame
    void Update()
    {
        delayNow -= Time.deltaTime;

        if (delayNow <= 0)
        {
        }
    }
}
