using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class quit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite quitEnter, quitExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = quitEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = quitExit;
    }
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
