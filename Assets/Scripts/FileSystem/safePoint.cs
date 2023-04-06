using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class safePoint : MonoBehaviour
{
    [Header("结算界面")]
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        //Debug.Log(GameObject.FindGameObjectWithTag("KeyFolder").name);
        if (GameObject.Find("重要文件") == null) return;
        //Debug.Log(GameObject.Find("重要文件").GetComponent<KeyFileMove>()!=null);
        if (GameObject.Find("重要文件").GetComponent<KeyFileMove>().isMoving)
        {
            string filePath = Application.dataPath + "/task.csv";
            WriteCsv(filePath);//写入本地
            //Debug.Log("11");
            next.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void WriteCsv( string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write);
        Scene scene = SceneManager.GetActiveScene();
        string str= scene.name;
        //Debug.Log(scene.name);
        byte[] info = new UTF8Encoding(true).GetBytes(str);
        //添加数据到文件中
        fs.Flush();
        fs.Write(info, 0, info.Length);
        fs.Close();
    }

}
