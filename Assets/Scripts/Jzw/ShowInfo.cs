using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMeshPro;
    [SerializeField] private float delayBetweenChars = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "";
        //Debug.Log(GameObject.Find("ÎÄ¼þ¼Ð´°¿Ú").GetComponent<Renderer>().bounds);
        
    }

    public void ShowObjectInfo(string objectInfo)
    {
        StartCoroutine(ShowText(objectInfo));
    }
    private IEnumerator ShowText(string fillText)
    {
        textMeshPro.text = "";
        int visibleChars = 0;

        while (visibleChars < fillText.Length)
        {
            visibleChars++;
            textMeshPro.text = fillText.Substring(0, visibleChars);
            yield return new WaitForSeconds(delayBetweenChars);
        }
        
    }


    public void ClearText()
    {
        textMeshPro.text = "";
        StopAllCoroutines();
    }
}
