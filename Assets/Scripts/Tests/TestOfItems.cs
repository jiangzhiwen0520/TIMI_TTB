using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOfItems : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject container;
    public GameObject keyPrefrb;
    public GameObject particle;
    private ItemController m_itemController;
    private ParticleSystem m_ps;
    //private bool sig=true;
    void Start()
    {
        m_itemController = container.GetComponent<ItemController>();
        m_ps = particle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject k = GameObject.Instantiate(keyPrefrb);
            k.SetActive(false);
            if (!m_itemController.GetContainCounter().SetItems(k))
            {

                Destroy(k);
            }
            else
            {
                m_itemController.ShowItems();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject k = m_itemController.GetContainCounter().UseItems(keyPrefrb.GetComponent<Item>().GetID());
            if (k != null)
            {
                //Debug.Log("É¾³ý");
                particle.transform.position = k.transform.position;
                m_ps.Play();
                Destroy(k,0.1f);
                m_itemController.ShowItems();
            }
        }
    }
}
