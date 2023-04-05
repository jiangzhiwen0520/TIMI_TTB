using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fileMove : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector2> points;
    public float speed;
    public float slowDown;
    [Space(20)]
    [SerializeField] private AnimationCurve[] m_Curves;
    [Tooltip("�����б�Ĭ������")]
    [SerializeField] int AnimationCurveIndex = 0;
    [Space(20)]
    //private Vector2 m_curPos;
    private int m_currentPathIndex = 0;
    private bool m_slow = false;
    private bool m_fast = false;
    private float value=1;
    private float m_speed;
    private bool m_isStop = false;
    private float m_time = 5;
    private Vector3 moveVector;
    private bool m_destory;
    private float distanceToTarget;
    private Vector2 moveDirection;
    //private GameObject[] objects;
    private AnimationCurve Curve
    {
        get
        {
            if (AnimationCurveIndex > -1 && AnimationCurveIndex < m_Curves.Length)
            {
                return m_Curves[AnimationCurveIndex];
            }

            return null;
        }
    }
    void Start()
    {
        if (points.Count > 0)
        {

            //transform.position = points[0];

        }
        
        m_currentPathIndex++;
        m_speed = speed;
        m_isStop = false;
        //objects = GameObject.FindGameObjectsWithTag("VirusFiles");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isStop)
        {
            m_time -= Time.deltaTime;
            if (m_time <= 0)
            {
                m_isStop = false;
                m_time = 5;
            }
        }
        else {
            LoopMove();
        }
    }
    public void LoopMove()
    {
        if (m_destory)
        {
            return;
        }
        if (m_fast)
        {
            if (Curve == null)
            {
                return;
            }
            value += Time.deltaTime * slowDown;
            if (value > 1)
            {
                value = 1;
                m_fast = false;
            }
            float v = Curve.Evaluate(value);
            m_speed = v*speed;
            //Debug.Log("m_speed:" + m_speed);
        }
        if(m_slow)
        {
            if (Curve == null)
            {
                return;
            }
            value -= Time.deltaTime * slowDown;
            //Debug.Log("value :" + value);
            if (value <=0 )
            {
                value = 0;
                m_slow = false;
            }
            float v = Curve.Evaluate(value);
            //Debug.Log("v :" + v);
            m_speed = v*speed;
            //Debug.Log("m_speed:"+m_speed);
        }

        if ( points.Count>0)
        {
            Vector2 currentTarget = points[m_currentPathIndex];

            // �����ƶ�����;���
            moveDirection = currentTarget - (Vector2)transform.localPosition;
            distanceToTarget = moveDirection.magnitude;
        }
        

        

        // �������С�ڿ��Խ��ܵ������ƶ�����һ��·����
        if (distanceToTarget < 0.1f)
        {
            m_currentPathIndex++;
            if (m_currentPathIndex >= points.Count)
            {
                m_currentPathIndex = 0;
            }
        }
        else
        {
            // ����һ��·�����ƶ�
            Vector3 moveVector = moveDirection.normalized * m_speed * Time.deltaTime;
            transform.localPosition += moveVector;
        }
    }
    private void OnMouseEnter()
    {
        m_slow = true;
        m_fast = false;
        if (GetComponent<VirusProduction>() != null) GetComponent<VirusProduction>().SetCanShoot2(false);
    }
    private void OnMouseExit()
    {
        m_fast = true;
        m_slow = false;
        if(GetComponent<VirusProduction>()!=null) GetComponent<VirusProduction>().SetCanShoot2(true);
    }
    public void SetStop()
    {
        m_isStop = true;
    }
    public Vector3 GetMoveVecor()
    {
        return moveVector;
    }
    public bool GetStop()
    {
        return m_isStop;
    }
    public void SetD()
    {
        m_destory = true;
    }
    public bool GetD()
    {
        return m_destory;
    }
    }
