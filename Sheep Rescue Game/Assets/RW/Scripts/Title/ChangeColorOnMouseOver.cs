using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;
    public Color normalColor;
    public Color hoverColor;

    void Start()
    {
        model.material.color = normalColor;
    }

    // Called  when the pointer enters the attached GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    // Called  when the pointer enters the attached GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }
}
