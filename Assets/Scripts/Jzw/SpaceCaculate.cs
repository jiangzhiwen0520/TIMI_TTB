using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceCaculate : MonoBehaviour
{  
    private int fileSpace=0;
    public GameObject defeatWindow;

    public TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Position").Length);
        //GameObject[] pos= Resources.FindObjectsOfTypeAll<GameObject>().

        List<GameObject> pos = new List<GameObject>();
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Position")|| obj.CompareTag("DPosition"))
            //if (obj.CompareTag("Position") )
            {
                pos.Add(obj);
                //Debug.Log(obj.name);
            }
        }

        for(int i = 0; i < pos.Count; i++)
        {
            //Debug.Log(pos[i].transform.parent.parent);
        }
        //Debug.Log("jj"+pos.Count);
        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].transform.childCount > 0)
            {
                if ( pos[i].transform.GetChild(0).name.Contains("小"))
                {
                    fileSpace+=1;
                }
                else if (pos[i].transform.GetChild(0).name.Contains("中"))
                {
                    fileSpace += 2;
                }
                else if (pos[i].transform.GetChild(0).name.Contains("大"))
                {
                    fileSpace += 4;
                }
                else if (pos[i].transform.GetChild(0).name == "普通文件")
                {
                    fileSpace += 1;
                }
            }
           

        }

        //Debug.Log(fileSpace);
        //CaculateSpace();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fileSpace);
        if (fileSpace <= 50)
        {
            GameObject.Find("存储条").GetComponent<Image>().fillAmount = fileSpace / 50f;
            if (fileSpace < 10)
            {
                countText.text = "0" + fileSpace + "/50";
            }
            else
            {
                countText.text = fileSpace + "/50";
            }
        }
        else
        {
            defeatWindow.SetActive(true);
            Time.timeScale = 0;
        }
       // Debug.Log(fileNum);

    }

    public  void CaculateSpace()
    {
        fileSpace = 0;
        List<GameObject> pos = new List<GameObject>();
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Position") || obj.CompareTag("DPosition"))
            {             
                pos.Add(obj);
            }
        }

        
        //Debug.Log(pos.Count);
        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("小"))
                {
                    fileSpace += 1;
                }
                else if (pos[i].transform.GetChild(0).name.Contains("中"))
                {
                    fileSpace += 2;
                }
                else if (pos[i].transform.GetChild(0).name.Contains("大"))
                {
                    fileSpace += 4;
                }
                else if (pos[i].transform.GetChild(0).name == "普通文件")
                {
                    fileSpace += 1;
                }
            }


        }

        //List<GameObject> dpos = new List<GameObject>();

        //foreach (GameObject obj in allGameObjects)
        //{
        //    if (obj.CompareTag("DPosition") && obj.transform.GetChild(0).tag != "Folder")
        //    {
        //        dpos.Add(obj);
        //    }
        //}

        //for (int i = 0; i < dpos.Count; i++)
        //{
        //    if (dpos[i].transform.childCount > 0)
        //    {
        //        if (dpos[i].transform.GetChild(0).name.Contains("小"))
        //        {
        //            fileSpace += 1;
        //        }
        //    }
        //    else if (dpos[i].transform.childCount > 0)
        //    {
        //        if (dpos[i].transform.GetChild(0).name.Contains("中"))
        //        {
        //            fileSpace += 2;
        //        }
        //    }
        //    else if (dpos[i].transform.childCount > 0)
        //    {
        //        if (dpos[i].transform.GetChild(0).name.Contains("大"))
        //        {
        //            fileSpace += 4;
        //        }
        //    }
        //    else if (dpos[i].transform.childCount > 0)
        //    {
        //        if (dpos[i].transform.GetChild(0).name=="普通文件")
        //        {
        //            fileSpace += 1;
        //        }
        //    }
        //}
    }
}
