using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.IO;

public class StartPanel : MonoBehaviour
{
    [Header("新游戏按钮对应的场景")]
    public string newGameScene;
    [Header("继续游戏对应的场景")]
    public string continueGameScene;
    public Animator point;
    public GameObject gamePanel, loadPanel;
    public Button startGame;
    public Button btn_Close;
    public Button btn_ContinueGame;
    public Button btn_NewGame;


    private void Awake()
    {
        loadPanel.SetActive(false);
        gamePanel.transform.localScale = Vector3.zero;

        startGame.onClick.AddListener(() =>
        {
            gamePanel.transform.DOScale(Vector3.one * 100, 0.3f);
        });

        btn_Close.onClick.AddListener(() =>
        {
            gamePanel.transform.DOScale(Vector3.zero, 0.3f);
        });

        btn_ContinueGame.onClick.AddListener(() =>
        {
            loadPanel.SetActive(true);
            AnimatorStateInfo stateInfo = point.GetCurrentAnimatorStateInfo(0);
            float flipLength = stateInfo.length;
            StartCoroutine(ContinueGameScene(flipLength));
        });

        btn_NewGame.onClick.AddListener(() =>
        {
            loadPanel.SetActive(true);
            AnimatorStateInfo stateInfo = point.GetCurrentAnimatorStateInfo(0);
            float flipLength = stateInfo.length;
            StartCoroutine(NewGameScene(flipLength));
        });

    }

    IEnumerator NewGameScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(newGameScene);
    }
    IEnumerator ContinueGameScene(float time)
    {
        continueGameScene = ReadCsv(Application.dataPath + "/task.csv");
        if (continueGameScene == null) continueGameScene = newGameScene;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(continueGameScene);
    }
    string ReadCsv(string path)
    {
        string ans;
        path = path.Replace("/", "\\");
        if (!File.Exists(path))
        {
            File.CreateText(path);
            //Debug.Log(path);
        }
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

        //使用文件流相应的字符编码格式来读取文件流
        StreamReader streamReader = new StreamReader(fileStream);
        if ((ans = streamReader.ReadLine()) != null)
        {
            return ans;
        }
        else
        {
            return null;
        }
    }
}
