using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    public GameObject fileSystem;
    public GameObject fileMap;
    //private string currentFolder;
    private ArrayList fileTrace=new ArrayList();

    public Sprite point;
    public Sprite fileIcon;
    private void Start()
    {
        //currentFolder = "文件夹1.1";
        fileTrace.Add("文件夹1.1");
        //Debug.Log(fileTrace.Count);
        
        fileSystem.transform.Find("文件夹1.1").gameObject.SetActive(true);

        fileMap.transform.Find("文件夹1.1").gameObject.GetComponent<SpriteRenderer>().sprite = fileIcon;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null|| GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 检查鼠标左键是否抬起
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // 检查击中的游戏对象的标签是否与预设的值相匹配
                if (hit.collider.gameObject.CompareTag("Folder"))
                {
                    //点击文件夹音效
                    GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(3);
                    //Debug.Log("Clicked object with matching tag: " + hit.collider.gameObject.name);
                    //currentFolder = hit.collider.gameObject.transform.parent.parent.name;
                    //Debug.Log(currentFolder);
                    fileSystem.transform.Find(hit.collider.gameObject.name).gameObject.SetActive(true);
                    hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);

                    fileTrace.Add(hit.collider.gameObject.name);
                    //Debug.Log(fileTrace.Count);

                    //小地图部分
                    fileMap.transform.Find(hit.collider.gameObject.name).gameObject.GetComponent<SpriteRenderer>().sprite = fileIcon;
                    fileMap.transform.Find(fileTrace[fileTrace.Count - 2].ToString()).gameObject.GetComponent<SpriteRenderer>().sprite = point;

                    hit.collider.gameObject.GetComponent<FileChoose>().isMouseOver = false ;

                }
                else if (hit.collider.gameObject.name == "返回键")
                {
                    GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(0);
                    //debug.log("按下返回键");
                    //filesystem.transform.find(currentfolder).gameobject.setactive(true);
                    //hit.collider.gameobject.transform.parent.parent.gameobject.setactive(false);
                    if (fileTrace.Count > 1)
                    {
                        //Debug.Log(fileTrace.Count);
                        fileSystem.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.SetActive(false);
                        fileMap.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.GetComponent<SpriteRenderer>().sprite = point;

                        fileTrace.RemoveAt(fileTrace.Count - 1);

                        //Debug.Log(fileTrace.Count);
                        fileSystem.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.SetActive(true);
                        fileMap.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.GetComponent<SpriteRenderer>().sprite = fileIcon;

                    }
                    else
                    {
                        fileSystem.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.SetActive(true);
                        fileMap.transform.Find(fileTrace[fileTrace.Count - 1].ToString()).gameObject.GetComponent<SpriteRenderer>().sprite = fileIcon;
                    }

                }
            }

        }

       
    }

}
