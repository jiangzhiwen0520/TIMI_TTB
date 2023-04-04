using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    //[Header("速度")]
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
    //todo:1.子弹的生存时间，碰撞到边界销毁；鼠标碰到时触发弹窗。 2.新的3个道具的逻辑
    
    void BulletDstroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("碰撞了");
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
        GameObject item = counter.UseItems(2);//是否有防火墙
                                                //触发弹窗的接口
        if (item != null)
        {
            item.GetComponent<FireWall>().Func();
            Debug.Log("无敌时间");
            //Destroy(item, 0.1f);
            //g.GetComponent<ItemController>().ShowItems();
        }
        else
        {
            //Debug.Log("触发弹窗");
            Instantiate(dialog);
            //dialog.GetComponent<UiTimeBar>().SetStart();
            //触发弹窗的接口;
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
