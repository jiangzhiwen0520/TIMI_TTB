using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public GameObject fileSystem;
    private string currentFolder;

    private void Start()
    {
        currentFolder = "�ļ���";
       
        
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����������Ƿ���
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // �����е���Ϸ����ı�ǩ�Ƿ���Ԥ���ֵ��ƥ��
                if (hit.collider.gameObject.CompareTag("Folder"))
                {
                    //Debug.Log("Clicked object with matching tag: " + hit.collider.gameObject.name);
                    currentFolder = hit.collider.gameObject.transform.parent.parent.name;
                    fileSystem.transform.Find(hit.collider.gameObject.name).gameObject.SetActive(true);
                    hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);


                }
                else if (hit.collider.gameObject.name=="���ؼ�")
                {
                    fileSystem.transform.Find(currentFolder).gameObject.SetActive(true);
                    hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);
                }
            }

        }

       
    }

}
