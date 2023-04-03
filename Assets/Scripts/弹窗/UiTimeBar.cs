using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTimeBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image mask;
    public float stopTime;
    private float m_time=0;
    private bool m_start=false;
    private float originLen;
    void Start()
    {
        originLen = mask.rectTransform.rect.width;
        SetStart();
        /*GameObject[] objects = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject i in objects)
        {
            i.GetComponent<BulletController>().SetInvincible();
        }
        SetAllInv();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (m_start)
        {
            m_time += Time.deltaTime;
            mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originLen*m_time / stopTime);
            if(m_time>= stopTime)
            {
                m_start = false;
            }
        }

    }
    
    public void SetStart()
    {
        m_time = 0;
        m_start = true;
        //gameObject.SetActive(true);
    }
    public bool GetStart()
    {
        return m_start;
    }
}
