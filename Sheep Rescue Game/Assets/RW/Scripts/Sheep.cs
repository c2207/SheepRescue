using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    private SheepSpawner sheepSpawner;

    public float heartOffset;
    public GameObject heartPrefab;

    // Used to avoid that OnTriggerEnter is called twice
    private bool canDrop = true;

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true;
        runSpeed = 0;
        // Destroy the Sheep after the delay time is exceeded
        Destroy(gameObject, gotHayDestroyDelay);

        // Create a new heart
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        // Add a TweenScale component to the sheep and put a reference of it
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        SoundManager.Instance.PlaySheepHitClip();

        GameStateManager.Instance.SavedSheep();
    }

    private void OnTriggerEnter (Collider other)
    {
        // If the tag that collides with the sheep is Hay, we destroy the Hay and the Sheep
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
        }

        else if (other.CompareTag("DropSheep") && canDrop)
        {
            canDrop = false;
            Drop();
        }
    }

    private void Drop()
    {
        GameStateManager.Instance.DroppedSheep();
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        sheepSpawner.RemoveSheepFromList(gameObject);
        Destroy(gameObject, dropDestroyDelay);

        SoundManager.Instance.PlaySheepDroppedClip();
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the sheep forward
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }
}
