using UnityEngine;
using UnityEngine.UI;

public class MouseLoadingCircle : MonoBehaviour
{
    public Image loadingCircle;
    public float loadingTime = 2.0f;

    private bool isMouseDown = false;
    private float elapsedTime = 0.0f;

    //private string targetTag = "NormalFile";

    private void Start()
    {
        loadingCircle.fillAmount = 0.0f;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        // �������λ��
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //loadingCircle.transform.position = mousePosition;
        loadingCircle.transform.position = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����������Ƿ���
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // �����е���Ϸ����ı�ǩ�Ƿ���Ԥ���ֵ��ƥ��
                if (hit.collider.gameObject.CompareTag("JunkFile")|| hit.collider.gameObject.CompareTag("RVFiles"))
                {
                    //Debug.Log("Clicked object with matching tag: " + hit.collider.gameObject.name);
                    isMouseDown = true;
                }
                //else
                //{
                //    Debug.Log("Clicked object with different tag: " + hit.collider.gameObject.name);
                //}
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            elapsedTime = 0.0f;
            loadingCircle.fillAmount = 0.0f;
        }

        // ���¼���Ȧ
        if (isMouseDown)
        {
            elapsedTime += Time.deltaTime;
            loadingCircle.fillAmount = elapsedTime / loadingTime;

            if (elapsedTime >= loadingTime)
            {
                isMouseDown = false;
                elapsedTime = 0.0f;
                loadingCircle.fillAmount = 0.0f;
            }
        }
    }
    public void SetLoadTime(float t)
    {
        loadingTime = t;
    }
}
