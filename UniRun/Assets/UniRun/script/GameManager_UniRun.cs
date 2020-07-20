using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_UniRun : MonoBehaviour
{
    public static GameManager_UniRun Instance;

    public void Awake()
    {
        if (GameManager_UniRun.Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void Start()
    {
        m_ScoreUI.text = string.Format("Score ; {0}", m_Score);
    }
    public bool m_isGameOver = false;
    public GameObject m_GameOverUI;
    public UnityEngine.UI.Text m_ScoreUI;
    public int m_Score = 0;

    public void OnPlayerDead()
    {
        m_isGameOver = true;
        m_GameOverUI.SetActive(true);

        ScrollingObject[] scrollingObjects = FindObjectsOfType<ScrollingObject>();
        foreach (var scrollingObject in scrollingObjects)
                scrollingObject.enabled = false;

        FindObjectOfType<PlatformSpawner>().enabled = false;
    }
    public void OnAddScore()
    {
        m_Score++;
        m_ScoreUI.text = string.Format("SCORE :{0}", m_Score);
    }

    private void Update()
    {
       if(m_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level_UniRun");
        }
    }
    public void Die()
    {
        if (m_isGameOver)
        {
            SceneManager.LoadScene("Level_UniRun");
        }
    }

}
