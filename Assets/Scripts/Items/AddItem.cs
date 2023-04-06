using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddItem : MonoBehaviour
{
    //public GameObject container;
    public GameObject itemPrefrb;
    public GameObject dialog;
    private ItemController m_ic;
    // Start is called before the first frame update
    void Start()
    {
        m_ic = GameObject.Find("Container").GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null) return;
        if (GameObject.FindWithTag("ShockDialog")==null)
        {
            GameObject k = GameObject.Instantiate(itemPrefrb);
            k.SetActive(false);
            if (!m_ic.GetContainCounter().SetItems(k))
            {
                GameObject i = Instantiate(dialog);
                string[] s = new string[1] { "道具满了，别当仓鼠了，先用再说！" };
                i.transform.GetChild(0).GetComponent<DialogController>().SetMs(s, null, null);

                Destroy(k);
            }
            else
            {
                GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(7);
                m_ic.ShowItems();
                Destroy(gameObject);
            }
        }
    }
}
