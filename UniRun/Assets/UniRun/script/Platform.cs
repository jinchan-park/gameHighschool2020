using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] m_Obstacles;
    public bool m_isTouch = false;

    private void OnEnable()
    {
        foreach(var obstacle in m_Obstacles)
        {
            if (Random.Range(0, 3) == 0)
                obstacle.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_isTouch == false)
        {
            GameManager_UniRun .Instance.OnAddScore();
            m_isTouch = true;
        }

    }
}
