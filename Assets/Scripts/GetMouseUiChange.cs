using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetMouseUiChange : MonoBehaviour
{

    
    [SerializeField] private GameObject MouseDelete;
    [SerializeField] private GameObject Mouse;
    [SerializeField] private GameObject KeyFolder;
    private float PressedTime = 0f;
    private float DorationTime = 0f;
    private string Folder;
    private bool canChanged=true;
    private Vector3 LastPosation;

    internal void DisableMouseChange()
    {
        throw new NotImplementedException();
    }

    private float dist;
    public void Start()
    {
        Cursor.visible = false;
        Mouse.transform.position = Input.mousePosition;
        MouseDelete.SetActive(false);
        LastPosation = KeyFolder.transform.position;
    }

    public void MouseChange()
    {
        if (Input.GetMouseButton(0))
        {

            PressedTime += Time.deltaTime;
            if (PressedTime >= DorationTime)
            {
                Mouse.SetActive(false);
                MouseDelete.SetActive(true);
                MouseDelete.transform.position = Input.mousePosition;
                MouseDelete.GetComponent<Image>().fillAmount += PressedTime * 0.005f;
            }

        }
        else
        {
            MouseDelete.GetComponent<Image>().fillAmount = 0f;
            PressedTime = 0f;
            Mouse.SetActive(true);
            MouseDelete.SetActive(false);
        }
    }

    public void CanChange()
    {
        GameObject SelectFolder = GameObject.FindGameObjectWithTag("Folder");
        if (SelectFolder == null) return;

        dist = Vector3.Distance(Input.mousePosition, SelectFolder.transform.position);
        if (dist <= 100)
        {
            MouseChange();
        }
        else
        {
            MouseDelete.SetActive(false);
            Mouse.SetActive(true);
            MouseDelete.GetComponent<Image>().fillAmount = 0;
        }
    }


    public void Update()
    {
        
        if (KeyFolder.transform.position!=LastPosation)
        {
            canChanged = false;
            print(canChanged);

        }
        Cursor.visible = false;
        Mouse.transform.position = Input.mousePosition;
        if (canChanged)
        {
            CanChange();
        }
 
    }
    
    


    public void Reset()
    {
        Mouse.SetActive(true);
        MouseDelete.SetActive(false);
    }


}
