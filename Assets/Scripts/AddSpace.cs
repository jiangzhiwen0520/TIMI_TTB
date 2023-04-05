using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AddSpace : MonoBehaviour
{
    [SerializeField] private GameObject AllPoints;
    [SerializeField] private GameObject Space;
    private int taggedCount;

    private void Update()
    {
        FindCount();
        print(taggedCount);
    }

    private void FindCount()
    {
        Component[] childObjects = AllPoints.GetComponentsInChildren<Component>(true);
        List<GameObject> taggedObjects = new List<GameObject>();

        foreach (Transform child in AllPoints.transform)
        {
            if (child.CompareTag("Space"))
            {
                taggedObjects.Add(child.gameObject);
            }
        }

        taggedCount = taggedObjects.Count;
        Space.GetComponent<Image>().fillAmount = (float)taggedCount / 48 ;//转换
    }

    private void Start()
    {
        FindCount();
    }
}
