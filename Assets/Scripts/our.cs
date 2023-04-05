using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class our : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject ourPanel;
    public Sprite ourEnter, ourExit;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = ourEnter;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = ourExit;
    }
    private void Awake()
    {
        ourPanel.SetActive(false);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ourPanel.SetActive(true);
        });
    }
}