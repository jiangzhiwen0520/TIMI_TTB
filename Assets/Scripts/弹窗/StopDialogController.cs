using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StopDialogController : MonoBehaviour
{
    //public Image image;

    public void MouseEnter()
    {
        Vector3 a = new Vector3(0, 10, 0);
        transform.position += a;

        //Debug.Log("MouseEnter");

    }

    public void MouseExit()
    {
        Vector3 a = new Vector3(0, 10, 0);
        transform.position -= a;
        //Debug.Log("MouseExit");

    }

    public void MouseDown()
    {

        transform.localScale = 0.8f * Vector3.one;

        //Debug.Log("MouseDown");

    }

    public void MouseUp()
    {

        transform.localScale = Vector3.one;

        //Debug.Log("MouseUp");

    }

    public void MouseClick()
    {
        GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(0);
        GameObject g = GameObject.FindWithTag("PauseDialog");
        //Debug.Log("MouseClick");
        Time.timeScale = 1;
        Destroy(g);

    }
    public void MouseClickQ()
    {

        //GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(0);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�������unity��������
    #else
            Application.Quit();//�����ڴ���ļ���
    #endif

    }
}
