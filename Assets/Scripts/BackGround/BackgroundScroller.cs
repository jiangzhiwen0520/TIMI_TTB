using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSize;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // ˮƽ����
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.left * newPosition;

        // ��ֱ������ȡ��ע�������ã�
        // float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        // transform.position = startPosition + Vector3.down * newPosition;
    }
}
