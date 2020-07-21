using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float m_speed = 1f;

    public float m_Destroy = 4f;

    void Update()
    {
       transform.Translate(Vector2.up * m_speed * Time.deltaTime);

        m_Destroy -= Time.deltaTime;
        if (m_Destroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
