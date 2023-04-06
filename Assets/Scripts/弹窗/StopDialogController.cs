using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (GameObject.FindGameObjectWithTag("ShockDialog") == null) { 
            Time.timeScale = 1;
        }
        Destroy(g);

    }
    public void MouseClickQ()
    {
        string filePath = Application.dataPath + "/task.csv";
        WriteCsv(filePath);//д�뱾��
        SceneManager.LoadScene("UI");
        Time.timeScale = 1;
        //GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(0);
/*#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�������unity��������
    #else
            Application.Quit();//�����ڴ���ļ���
    #endif
        */
    }
    public void WriteCsv(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write);
        Scene scene = SceneManager.GetActiveScene();
        string str = scene.name;
        Debug.Log(scene.name);
        byte[] info = new UTF8Encoding(true).GetBytes(str);
        //������ݵ��ļ���
        fs.Flush();
        fs.Write(info, 0, info.Length);
        fs.Close();
    }
}
