using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderClip : MonoBehaviour
{
    private SpriteRenderer m_sr;
    private PolygonCollider2D m_pc;
    private List<Vector2> m_points = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        m_pc= GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_sr = GetComponent<SpriteRenderer>();
        m_sr.sprite.GetPhysicsShape(0, m_points);
        m_pc.SetPath(0, m_points);
    }
}
