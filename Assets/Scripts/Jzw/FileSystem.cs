using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public GameObject fileSystem;
    private string currentFolder;

    private void Start()
    {
        currentFolder = "文件夹";
       
        
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 检查鼠标左键是否按下
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // 检查击中的游戏对象的标签是否与预设的值相匹配
                if (hit.collider.gameObject.CompareTag("Folder"))
                {
                    //Debug.Log("Clicked object with matching tag: " + hit.collider.gameObject.name);
                    currentFolder = hit.collider.gameObject.transform.parent.parent.name;
                    fileSystem.transform.Find(hit.collider.gameObject.name).gameObject.SetActive(true);
                    hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);


                }
                else if (hit.collider.gameObject.name=="返回键")
                {
                    fileSystem.transform.Find(currentFolder).gameObject.SetActive(true);
                    hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);
                }
            }

        }

       
    }

}
