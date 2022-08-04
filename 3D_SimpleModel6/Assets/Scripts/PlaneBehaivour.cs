using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaivour : MonoBehaviour
{
    private int TIMER_COUNTER = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TIMER_COUNTER < 300)
		{
            var move = new Vector3(0.0f, 0.01f, 0.0f);
            transform.localPosition += move;
            TIMER_COUNTER++;
        }
    }
}
