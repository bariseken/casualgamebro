using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float swiperate;
    // Start is called before the first frame update
    void Start()
    {

    }

    Vector2 currentTouchPosition, preTouchPosition;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentTouchPosition = Input.mousePosition;
            preTouchPosition = currentTouchPosition;
        }

        else if (Input.GetMouseButton(0))

        {
            currentTouchPosition = Input.mousePosition;
            swiperate = (currentTouchPosition - preTouchPosition).y;
        }
        else if (Input.GetMouseButtonUp(0)) ;
        {

        }
        SetScale();


    }

    float minScale = 0.5f, maxScale = 3f;
    float minInputValue = -1220f, maxInputValue = 120f;


    void SetScale()

    {
        //transform.localScale = Vector3.one * scaleMult;

        float yScaleMult = Normalize(swiperate, minInputValue, maxInputValue, minScale, maxScale);
        float xScaleMult = Normalize(-swiperate, minInputValue, maxInputValue, minScale, maxScale);

        Vector3 newScale = new Vector3(xScaleMult, yScaleMult, 1);

        transform.localScale = newScale;

    }

    float Normalize(float value, float min, float max, float minNew, float maxNew)

    {
        value = Mathf.Clamp(value, min, max);
        return minNew + ((value - min) * (maxNew - minNew) / (max - min));
    }
}

