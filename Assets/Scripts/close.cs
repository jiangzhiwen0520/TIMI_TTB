using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class close : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite closeEnter, closeExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = closeEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = closeExit;
    }
}