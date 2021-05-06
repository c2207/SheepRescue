using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;

    private void UpdateMovement()
    {
        // If the user pressed any of the horizontal arrows
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // We move only if we are pressing the left key and the object is inside the horizontal boundary
        // If not, we would have lots of bullets
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            // Move to the left
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            // Move to the right
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    private void ShootHay()
    {
        // Create a new instance of the prefab (bullet), in the position determined by haySpawnpoint
        // And the quaternion is for the rotation, it is like a Vector3 with the identity
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        // Only shoot if we have exceeded the time between shots when pressing the space key
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
