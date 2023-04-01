using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FolderMove : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Folder;
    [SerializeField] private GameObject Mouse;
    [SerializeField] private GameObject MousePos;
    [SerializeField] private float Speed;
    private bool isdrag=false;
    private bool isenterdsecound = false;
    private bool isenterdfirst=false;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void Update()
    {
        
        if (isenterdfirst)//记得一定删除
        {
            ccc();
            if (isdrag)
            {
                //Cursor.visible = false;
                Vector3 mousePos = Input.mousePosition;

                // 如果鼠标位置超出了屏幕边缘，则将文件夹停靠在屏幕边缘
                if (mousePos.x < 0 || mousePos.x > Screen.width || mousePos.y < 0 || mousePos.y > Screen.height)
                {
                    Vector3 folderPos = Folder.transform.position;

                    if (mousePos.x < 0) folderPos.x = 0;
                    if (mousePos.x > Screen.width) folderPos.x = Screen.width;
                    if (mousePos.y < 0) folderPos.y = 0;
                    if (mousePos.y > Screen.height) folderPos.y = Screen.height;

                    Folder.transform.position = folderPos;
                    Mouse.GetComponent<Image>().enabled = false;
                    isenterdsecound = true;
                    Folder.transform.localScale = Vector3.one;
                    Mouse.GetComponent<Image>().enabled = false;
                    //Debug.Log("1");
                    
                }
                else
                {
                    Folder.transform.position = mousePos;
                    Mouse.GetComponent<Image>().enabled = false;
                    isenterdsecound = true;
                    Folder.transform.localScale = Vector3.one;
                    Mouse.GetComponent<Image>().enabled = false;
                   
                    
                }
            }
        }
        else
        {
            //Cursor.visible = true;
        }
    }


    public void ccc()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isdrag = true;
            
        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isenterdsecound)
        {
            Folder.transform.localScale += Vector3.one * 0.5f;
            isenterdfirst = true;
            //ccc();
            
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isenterdsecound)
        {
            Folder.transform.localScale -= Vector3.one * 0.5f;
            isenterdfirst = false;
            isdrag = false;
            Mouse.GetComponent<Image>().enabled = true;
        }  
   
    }


}


