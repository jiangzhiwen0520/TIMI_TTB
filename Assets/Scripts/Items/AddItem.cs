using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    //public GameObject container;
    public GameObject itemPrefrb;
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
        GameObject k = GameObject.Instantiate(itemPrefrb);
        k.SetActive(false);
        if (!m_ic.GetContainCounter().SetItems(k))
        {

            Destroy(k);
        }
        else
        {
            m_ic.ShowItems();
            Destroy(gameObject);
        }
    }
}
