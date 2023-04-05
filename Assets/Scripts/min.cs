using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class min : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite minEnter, minExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = minEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = minExit;
    }
}