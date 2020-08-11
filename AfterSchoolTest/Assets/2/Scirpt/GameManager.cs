using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Life = 3;
    public int m_Score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        m_Score++;
    }
    public void DamageLife()
    {
        Life--;
        if(Life <= 0)
        {
            //GameOver;
        }
    }
    public bool m_IsGameOver;
    public void Update()
    {
        
    }
}
