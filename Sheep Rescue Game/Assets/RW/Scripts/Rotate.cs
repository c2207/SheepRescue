using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We are only rotating in the y axis by a factor of 50
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
