using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // ��������ʱ�䣬��λΪ��
    public float shakeIntensity = 0.1f; // ����ǿ��

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
            // �ڶ�����Χ�����ѡ��һ��λ��
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;
            float z = Random.Range(-1f, 1f) * shakeIntensity;
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z + z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // ���������󣬽����λ������Ϊԭʼλ��
        transform.localPosition = originalPosition;
    }
}
