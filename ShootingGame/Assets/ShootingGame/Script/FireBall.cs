using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float m_speed = 1f;

    public float tlqkf = Time.deltaTime; 
    void Update()
    {
       transform.Translate(Vector2.up * m_speed * Time.deltaTime);
    }
}
