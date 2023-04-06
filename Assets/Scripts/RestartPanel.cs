using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RestartPanel : MonoBehaviour
{
    public Button btn_Restart, btn_quit, btn_Back;
    [Header("重新游戏按钮跳转的场景")]
    public string restartScene;
    private void Awake()
    {
        btn_Restart.onClick.AddListener(() =>
        {
            restartScene= SceneManager.GetActiveScene().name;
            Time.timeScale = 1;
            SceneManager.LoadScene(restartScene);
        });
        btn_quit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UI");
            Time.timeScale = 1;
        });
        btn_Back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UI");
            Time.timeScale = 1;
            gameObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() =>
            {
                gameObject.SetActive(false);
                gameObject.transform.DOScale(Vector3.one, 0.1f);
            });
        });

    }
}
