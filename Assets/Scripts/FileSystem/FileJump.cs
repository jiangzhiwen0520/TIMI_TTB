using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileJump : MonoBehaviour
{
    private void Start()
    {
        List<GameObject> siblingsWithSameTag = GetSiblingsWithSameTag(transform);

        // 打印找到的兄弟物体
        foreach (GameObject sibling in siblingsWithSameTag)
        {
            Debug.Log("Sibling with same tag: " + sibling.name);
        }
    }

    private void Update()
    {
        // 检查鼠标左键是否被按下
        if (Input.GetMouseButtonDown(0))
        {
            // 创建一个从摄像机发射的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 检测射线是否与物体相交
            if (Physics.Raycast(ray, out hit))
            {
                // 检查是否命中当前对象
                if (hit.transform == transform)
                {
                    OnObjectClicked();
                }
            }
        }
    }

    private void OnObjectClicked()
    {
        // 在这里处理点击事件，例如更改物体颜色、播放动画等
        Debug.Log("Object clicked: " + gameObject.name);
        
    }

    private List<GameObject> GetSiblingsWithSameTag(Transform targetTransform)
    {
        List<GameObject> result = new List<GameObject>();

        // 如果没有父物体，返回空列表
        if (targetTransform.parent == null)
        {
            return result;
        }

        // 获取父物体下的所有子物体
        foreach (Transform siblingTransform in targetTransform.parent)
        {
            // 检查兄弟物体是否与目标物体具有相同的标签（tag）
            if (siblingTransform != targetTransform && siblingTransform.tag == targetTransform.tag)
            {
                result.Add(siblingTransform.gameObject);
            }
        }

        return result;
    }
}
