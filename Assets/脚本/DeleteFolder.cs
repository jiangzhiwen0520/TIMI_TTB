using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteFolder : MonoBehaviour
{
    [SerializeField] private GameObject MouseDelete;
    [SerializeField] private GameObject SelectFolder;
    private GetMouseUiChange mouseChange;
    private bool isDeleted = false;

    private void Start()
    {
        mouseChange = GetComponent<GetMouseUiChange>();
        if (mouseChange != null)
        {
            mouseChange.Reset();
        }
    }

    public void Delete()
    {
        if (MouseDelete.GetComponent<Image>().fillAmount==1)
        {
            SelectFolder.SetActive(false);
            isDeleted = true;
            mouseChange.Reset();
        }
        else
        {
            isDeleted = false;
        }
    }

    private void Update()
    {
        Delete();
        if (isDeleted)
        {
            MouseDelete.GetComponent<Image>().fillAmount = 0; 
        }
    }
}
