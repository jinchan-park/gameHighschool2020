using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float m_Speed = 2f;

    private void Update()
    {
        Vector3 velocity = transform.up * m_Speed;
        Vector3 movement = velocity * Time.deltaTime;
        transform.position += movement;
    }
}
