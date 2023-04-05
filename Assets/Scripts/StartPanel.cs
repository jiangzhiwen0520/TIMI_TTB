using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(continueGameScene);
    }
}
