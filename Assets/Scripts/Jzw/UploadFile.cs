using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadFile : MonoBehaviour
{
    

    private ArrayList emptyPos=new ArrayList();
    private ArrayList emptyDPos = new ArrayList();

    //����С����
    public GameObject virus_small;
    public GameObject virus_mid;
    public GameObject virus_big;
    //����С����
    public GameObject junk_small;
    public GameObject junk_mid;
    public GameObject junk_big;

    //��С����
    public GameObject normal_small;
    public GameObject normal_big;
    // Update is called once per frame



    private List<List<string>> template = new List<List<string>>
        {
            new List<string> { "�󲡶�", "�в���", "������","С����", "С����" },
            new List<string> { "������","�в���", "�в���", "С����", "С����" },
            new List<string> { "������", "�в���", "С����", "С����", "С����" ,"С����"},
            new List<string> { "������", "������", "С����", "С����", "С����" ,"С����"},
            new List<string> { "�в���", "�в���", "�в���", "������", "С����" ,"С����"},
            new List<string> { "�в���", "�в���", "�в���", "�в���", "С����" ,"С����"},
            new List<string> { "�в���", "�в���", "�в���", "С����", "С����", "С����","С����"},
            new List<string> { "�в���", "�в���", "С����", "С����", "С����", "С����","С����","С����"},
        };


    private int tempNum;


    private void Start()
    {
        GameObject[] pos = GameObject.FindGameObjectsWithTag("Position");
        for (int i = 0; i < pos.Length; i++)
        {
            if (pos[i].transform.childCount == 1)
            {
                pos[i].tag="DPosition";
            }
        }
    }

    void Update()
    {
        if (GameObject.Find("ʱ����").GetComponent<TimeAdd>().isUpload)
        {
            FindEmptyPos();
            FileGenerate();
            FileFill();
            GameObject.Find("�洢��").GetComponent<SpaceCaculate>();
            GameObject.Find("ʱ����").GetComponent<TimeAdd>().isUpload = false;
        }


    }

    void FindEmptyPos()
    {
        GameObject[] pos = GameObject.FindGameObjectsWithTag("Position");
        GameObject[] dpos = GameObject.FindGameObjectsWithTag("DPosition");
        for (int i = 0; i < pos.Length; i++)
        {
            if (pos[i].transform.childCount == 0)
            {
                emptyPos.Add(pos[i]);
            }
        }
        for (int i = 0; i < dpos.Length; i++)
        {
            if (dpos[i].transform.childCount == 0)
            {
                emptyDPos.Add(dpos[i]);
            }
        }

    }

    void FileGenerate()  //����ģ������������
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
            if (template[tempNum][i] == "С����")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(virus_small, fillpos.transform.position, Quaternion.identity);

                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform,true);                  
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(virus_small, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                

            }
            else if (template[tempNum][i] == "�в���")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(virus_mid, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(virus_mid, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "�󲡶�")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(virus_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(virus_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "С����")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(junk_small, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(junk_small, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "������")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(junk_mid, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;

                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(junk_mid, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "������")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(junk_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;

                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(junk_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "С����")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(normal_small, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(normal_small, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
            else if (template[tempNum][i] == "������")
            {
                if (emptyDPos.Count > 0)
                {
                    GameObject fillpos = (GameObject)emptyDPos[Random.Range(0, emptyDPos.Count)];
                    GameObject instance = Instantiate(normal_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
                else
                {
                    GameObject fillpos = (GameObject)emptyPos[Random.Range(0, emptyPos.Count)];
                    GameObject instance = Instantiate(normal_big, fillpos.transform.position, Quaternion.identity);
                    Vector3 originalScale = instance.transform.localScale;
                    instance.transform.SetParent(fillpos.transform, true);
                    instance.transform.localScale = originalScale;
                }
            }
        }
            

    }

    void FileFill()
    {
        
    }
}
