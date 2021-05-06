using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Inherits from IPointerClickHandler so that the class recieve OnPointerClick callbacks from the event system
public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Load the game scene
        SceneManager.LoadScene("Game");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
