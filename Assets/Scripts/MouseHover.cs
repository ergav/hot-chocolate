using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnMouseEnter, onMouseExit;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnEnter");
        OnMouseEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("OnExit");
        onMouseExit.Invoke();
    }
}
