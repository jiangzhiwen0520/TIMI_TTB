using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceCaculate : MonoBehaviour
{
    //暂时用文件个数代替空间
    private int fileNum=0;

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
            if (obj.CompareTag("Position"))
            {
                pos.Add(obj);
            }
        }
        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].transform.childCount > 0)
            {
                if ( pos[i].transform.GetChild(0).tag != "Folder")
                {
                    fileNum++;
                }
            }
           
        }
        Debug.Log(fileNum);
        CaculateSpace();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("存储条").GetComponent<Image>().fillAmount = fileNum / 40;
        if (fileNum < 10)
        {
            countText.text ="0"+fileNum + "/40";
        }
       // Debug.Log(fileNum);

    }

    public  void CaculateSpace()
    {
        List<GameObject> pos = new List<GameObject>();
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Position") )
            {

                pos.Add(obj);
            }
        }

        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].transform.childCount >0 )
            {
                fileNum++;
            }
        }

        List<GameObject> dpos = new List<GameObject>();
        
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("DPosition") && obj.transform.GetChild(0).tag != "Folder")
            {
                dpos.Add(obj);
            }
        }

        for (int i = 0; i < dpos.Count; i++)
        {
            if (dpos[i].transform.childCount > 1)
            {
                fileNum++;
            }
        }
    }
}
