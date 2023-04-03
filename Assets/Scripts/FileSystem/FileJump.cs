using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileJump : MonoBehaviour
{
    private void Start()
    {
        List<GameObject> siblingsWithSameTag = GetSiblingsWithSameTag(transform);

        // ��ӡ�ҵ����ֵ�����
        foreach (GameObject sibling in siblingsWithSameTag)
        {
            Debug.Log("Sibling with same tag: " + sibling.name);
        }
    }

    private void Update()
    {
        // ����������Ƿ񱻰���
        if (Input.GetMouseButtonDown(0))
        {
            // ����һ������������������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ��������Ƿ��������ཻ
            if (Physics.Raycast(ray, out hit))
            {
                // ����Ƿ����е�ǰ����
                if (hit.transform == transform)
                {
                    OnObjectClicked();
                }
            }
        }
    }

    private void OnObjectClicked()
    {
        // �����ﴦ�����¼����������������ɫ�����Ŷ�����
        Debug.Log("Object clicked: " + gameObject.name);
        
    }

    private List<GameObject> GetSiblingsWithSameTag(Transform targetTransform)
    {
        List<GameObject> result = new List<GameObject>();

        // ���û�и����壬���ؿ��б�
        if (targetTransform.parent == null)
        {
            return result;
        }

        // ��ȡ�������µ�����������
        foreach (Transform siblingTransform in targetTransform.parent)
        {
            // ����ֵ������Ƿ���Ŀ�����������ͬ�ı�ǩ��tag��
            if (siblingTransform != targetTransform && siblingTransform.tag == targetTransform.tag)
            {
                result.Add(siblingTransform.gameObject);
            }
        }

        return result;
    }
}
