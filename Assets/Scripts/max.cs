using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class max : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite maxEnter, maxExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = maxEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = maxExit;
    }
}