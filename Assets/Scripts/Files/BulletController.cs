using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("�ٶ�")]
    //public Vector2 speed;
    //private Vector3 m_dir;
    //private float m_speed;
    public GameObject dialog;
    private bool m_isStop=false;
    private float m_time = 5;
    private bool m_isInvincible = false;
    private bool m_isAllInv = false;
    private float m_invincibleTime = 2;
    private Vector3 m_moveVector;

    void Start()
    {
        //m_dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        //m_speed = Random.Range(speed.x, speed.y);
        //Debug.Log(m_speed);
    }
    private void OnEnable()
    {
        if (m_moveVector!=null)
        {
            GetComponent<Rigidbody2D>().velocity = m_moveVector;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * speed;
        if (m_isStop)
        {
            m_time -= Time.deltaTime;
            if (m_time <= 0)
            {
                m_isStop = false;
                m_time = 5;
                GetComponent<Rigidbody2D>().velocity = m_moveVector;
            }
        }

        if (m_isInvincible)
        {
            m_invincibleTime -= Time.deltaTime;
            if (m_invincibleTime <= 0)
            {
                m_isInvincible = false;
                m_invincibleTime = 2;
            }
        }
    }
    //todo:1.�ӵ�������ʱ�䣬��ײ���߽����٣��������ʱ���������� 2.�µ�3�����ߵ��߼�
    
    void BulletDstroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("��ײ��");
        GameObject g = other.gameObject;
        if (g.tag=="Border")
        {
            BulletDstroy();

        }
    }
    private void OnMouseEnter()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null)
        {
            return;
        }
        if (GameObject.FindGameObjectWithTag("ShockDialog") != null)
        {
            return;
        }
        if (!m_isInvincible) {
        GameObject g = GameObject.Find("Container");
        ContainCounter counter = g.GetComponent<ItemController>().GetContainCounter();
        GameObject item = counter.UseItems(2);//�Ƿ��з���ǽ
                                                //���������Ľӿ�
        if (item != null)
        {
            item.GetComponent<FireWall>().Func();
            Debug.Log("�޵�ʱ��");
            //Destroy(item, 0.1f);
            //g.GetComponent<ItemController>().ShowItems();
        }
        else
        {
            //Debug.Log("��������");
            Instantiate(dialog);
            //dialog.GetComponent<UiTimeBar>().SetStart();
            //���������Ľӿ�;
        }
        }
    }
    public void SetStop()
    {
        m_isStop = true;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
    }
    public void SetInvincible()
    {
        m_isInvincible = true;
    }
    public void SetMoveVector(Vector3 vector)
    {
        m_moveVector = vector;
        GetComponent<Rigidbody2D>().velocity = m_moveVector;
    }
    public void SetAllInv()
    {
        m_isAllInv = !m_isAllInv;
    }
}
