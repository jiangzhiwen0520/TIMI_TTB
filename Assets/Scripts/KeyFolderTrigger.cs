using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFolderTrigger : MonoBehaviour
{
    [SerializeField] private GameObject KeyFolder;
    private void KeyFolderMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (KeyFolder.transform.position == Input.mousePosition)
            {
                GetComponent<GetMouseUiChange>().enabled = false;
            }
        }
        
    }
    private void Update()
    {
        KeyFolderMove();
    }
}
