using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;
    public float timeToReachTarget;
    private float startScale;
    private float percentScaled;

    void Start()
    {
        // Get the value of the scale in the X-axis and store it in startScale
        startScale = transform.localScale.x; 
    }

    void Update()
    {
        // If the percent scaled is not 100%, we add the time between current frame and previous divided by the
        // amount of time needed
        if (percentScaled < 1f)
        {
            // Mathf.Lerp performs a linear interpolation between startScale and targetScale with the perecntage percentScaled
            // at which the output value needs to be returned
            percentScaled += Time.deltaTime / timeToReachTarget;
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
