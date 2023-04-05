using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadFile : MonoBehaviour
{
    

    private ArrayList emptyPos=new ArrayList();
    private ArrayList emptyDPos = new ArrayList();

    //大中小病毒
    public GameObject virus_small;
    public GameObject virus_mid;
    public GameObject virus_big;
    //大中小垃圾
    public GameObject junk_small;
    public GameObject junk_mid;
    public GameObject junk_big;

    //大小正常
    public GameObject normal_small;
    public GameObject normal_big;
    // Update is called once per frame



    private List<List<string>> template = new List<List<string>>
        {
            new List<string> { "大病毒", "中病毒", "中垃圾","小病毒", "小病毒" },
            new List<string> { "大垃圾","中病毒", "中病毒", "小正常", "小正常" },
            new List<string> { "大正常", "中病毒", "小病毒", "小病毒", "小病毒" ,"小病毒"},
            new List<string> { "大垃圾", "中垃圾", "小病毒", "小病毒", "小病毒" ,"小病毒"},
            new List<string> { "中病毒", "中病毒", "中病毒", "中垃圾", "小病毒" ,"小病毒"},
            new List<string> { "中病毒", "中病毒", "中病毒", "中病毒", "小病毒" ,"小病毒"},
            new List<string> { "中病毒", "中病毒", "中病毒", "小病毒", "小病毒", "小垃圾","小垃圾"},
            new List<string> { "中病毒", "中病毒", "小病毒", "小病毒", "小病毒", "小病毒","小垃圾","小垃圾"},
        };


    private int tempNum;


    private void Start()
    {
        GameObject.Find("重要文件").transform.parent.tag = "KeyPosition";
        //GameObject[] pos = GameObject.FindGameObjectsWithTag("Position");

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
            if (pos[i].transform.childCount >0)
            {
                pos[i].tag="DPosition";
            }
        }
    }

    void Update()
    {
        if (GameObject.Find("时间条").GetComponent<TimeAdd>().isUpload)
        {
            emptyPos.Clear();
            emptyDPos.Clear();
            FindEmptyPos();
            FileGenerate();        
            GameObject.Find("存储条").GetComponent<SpaceCaculate>().CaculateSpace();
            GameObject.Find("时间条").GetComponent<TimeAdd>().isUpload = false;
        }


    }

    void FindEmptyPos()
    {
        //GameObject[] pos = GameObject.FindGameObjectsWithTag("Position");
        List<GameObject> pos = new List<GameObject>();
        List<GameObject> dpos = new List<GameObject>();
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allGameObjects)
        {
            if (obj.CompareTag("Position"))
            {
                pos.Add(obj);

            }
            else if (obj.CompareTag("DPosition"))
            {
                dpos.Add(obj);
            }
        }

        
        
     
        //GameObject[] dpos = GameObject.FindGameObjectsWithTag("DPosition");
        for (int i = 0; i < pos.Count; i++)
        {
            if (pos[i].transform.childCount == 0)
            {
                emptyPos.Add(pos[i]);
            }
        }
        for (int i = 0; i < dpos.Count; i++)
        {
            if (dpos[i].transform.childCount == 0)
            {
                emptyDPos.Add(dpos[i]);
            }
        }

    }

    void FileGenerate()  //按照模板进行随机生成
    {
        if (emptyPos.Count + emptyDPos.Count > 5)
        {
            tempNum = Random.Range(3, 8);

        }
        else
        {
            tempNum = Random.Range(0, 8);
        }

        for (int i = 0; i < template[tempNum].Count; i++)
        {
            if (template[tempNum][i] == "小病毒")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    emptyDPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_small, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                         instance.transform.SetParent(fillpos.transform, false);
                    }
                   
                    Debug.Log(instance.transform.parent.name);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    emptyPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_small, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                }
                

            }
            else if (template[tempNum][i] == "中病毒")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    emptyDPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_mid, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    emptyPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_mid, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                }
            }
            else if (template[tempNum][i] == "大病毒")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    emptyDPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    emptyPos.Remove((object)fillpos);
                    GameObject instance = Instantiate(virus_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                }
            }
            else if (template[tempNum][i] == "小垃圾")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    
                    GameObject instance = Instantiate(junk_small, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyDPos.Remove((object)fillpos);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                   
                    GameObject instance = Instantiate(junk_small, fillpos.transform.position, Quaternion.identity);
                    //Vector3 originalScale = instance.transform.localScale;
                    //instance.transform.SetParent(fillpos.transform, true);
                    //instance.transform.localScale = originalScale;
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyPos.Remove((object)fillpos);
                }
            }
            else if (template[tempNum][i] == "中垃圾")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    
                    GameObject instance = Instantiate(junk_mid, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    emptyDPos.Remove((object)fillpos);

                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    
                    GameObject instance = Instantiate(junk_mid, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyPos.Remove((object)fillpos);
                }
            }
            else if (template[tempNum][i] == "大垃圾")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    
                    GameObject instance = Instantiate(junk_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyDPos.Remove((object)fillpos);

                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    
                    GameObject instance = Instantiate(junk_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyPos.Remove((object)fillpos);
                }
            }
            else if (template[tempNum][i] == "小正常")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                   
                    GameObject instance = Instantiate(normal_small, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyDPos.Remove((object)fillpos);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    
                    GameObject instance = Instantiate(normal_small, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyPos.Remove((object)fillpos);
                }
            }
            else if (template[tempNum][i] == "大正常")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    
                    GameObject instance = Instantiate(normal_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyDPos.Remove((object)fillpos);
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    ;
                    GameObject instance = Instantiate(normal_big, fillpos.transform.position, Quaternion.identity);
                    instance.transform.position = new Vector3(0, 0, 0);
                    if (fillpos != null)
                    {
                        instance.transform.SetParent(fillpos.transform, false);
                    }
                    Debug.Log(instance.transform.parent.name);
                    emptyPos.Remove((object)fillpos);
                }
            }
        }
            

    }

   
}
