using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 movementSpeed;
    public Space space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The second parameter is to take into account the coordinates of the world or of the object itself
        // In this case we leave space as world, so we are taking the world coordinates
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
