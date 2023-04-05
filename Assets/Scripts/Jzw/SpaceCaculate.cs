using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceCaculate : MonoBehaviour
{
    //��ʱ���ļ���������ռ�
    private int fileSpace=0;

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
                if ( pos[i].transform.GetChild(0).name.Contains("С"))
                {
                    fileSpace+=1;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 2;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 4;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name == "��ͨ�ļ�")
                {
                    fileSpace += 1;
                }
            }

        }
        Debug.Log(fileSpace);
        //CaculateSpace();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fileSpace);
        GameObject.Find("�洢��").GetComponent<Image>().fillAmount = fileSpace / 50f;
        if (fileSpace < 10)
        {
            countText.text = "0" + fileSpace + "/50";
        }
        else
        {
            countText.text = fileSpace + "/50";
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
            if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("С"))
                {
                    fileSpace += 1;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 2;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 4;
                }
            }
            else if (pos[i].transform.childCount > 0)
            {
                if (pos[i].transform.GetChild(0).name == "��ͨ�ļ�")
                {
                    fileSpace += 1;
                }
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
            if (dpos[i].transform.childCount > 0)
            {
                if (dpos[i].transform.GetChild(0).name.Contains("С"))
                {
                    fileSpace += 1;
                }
            }
            else if (dpos[i].transform.childCount > 0)
            {
                if (dpos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 2;
                }
            }
            else if (dpos[i].transform.childCount > 0)
            {
                if (dpos[i].transform.GetChild(0).name.Contains("��"))
                {
                    fileSpace += 4;
                }
            }
            else if (dpos[i].transform.childCount > 0)
            {
                if (dpos[i].transform.GetChild(0).name=="��ͨ�ļ�")
                {
                    fileSpace += 1;
                }
            }
        }
    }
}
