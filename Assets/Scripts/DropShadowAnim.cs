using UnityEngine;
using System.Collections;

public class DropShadowAnim : MonoBehaviour
{
    public float radius = 0.15f;        // 阴影距离parent的半径
    public float maxAngle = 45f;      // 阴影左右摇摆的最大角度
    public float period = 2.0f;         // 一次摇摆需要多少秒

    private Transform trans;

    void Start()
    {
        trans = this.transform;
    }

    void Update()
    {
        float phase = Time.realtimeSinceStartup * (2.0f * Mathf.PI) / period;
        float angle = Mathf.Sin(phase) * (Mathf.Deg2Rad * maxAngle);

        float startX = 0.0f;
        float startY = -radius;
        float sinAngle = Mathf.Sin(angle);
        float cosAngle = Mathf.Cos(angle);
        float x = cosAngle * startX - sinAngle * startY;
        float y = sinAngle * startX + cosAngle * startY;

        trans.localPosition = new Vector3(x, y + 0.7f, 0.5f);
    }
}