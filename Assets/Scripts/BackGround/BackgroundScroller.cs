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
        // 水平滚动
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.left * newPosition;

        // 垂直滚动（取消注释以启用）
        // float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        // transform.position = startPosition + Vector3.down * newPosition;
    }
}
