using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // 抖动持续时间，单位为秒
    public float shakeIntensity = 0.1f; // 抖动强度

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // 在抖动范围内随机选择一个位置
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;
            float z = Random.Range(-1f, 1f) * shakeIntensity;
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z + z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 抖动结束后，将相机位置重置为原始位置
        transform.localPosition = originalPosition;
    }
}
