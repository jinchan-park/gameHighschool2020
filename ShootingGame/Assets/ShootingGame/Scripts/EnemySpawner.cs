using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    public GameObject m_EnemyPrefabs;
    public Transform[] m_Spawnpoint;

    public float m_SpawnMin = 2f;
    public float m_SpawnMax = 6f;

    public int m_MinSpawnCount = 1;
    public int m_MaxSpawnCount = 4;

    public float m_SpawnCoolDown = 0f;

    void Start()
    {
        m_SpawnCoolDown = Random.Range(m_SpawnMin, m_SpawnMax);
    }

    void Update()
    {
        if (m_SpawnCoolDown <= 0)

        {
            int spawncount = Random.Range(m_MinSpawnCount, m_MaxSpawnCount);



            List<int> spawnNums = new List<int>();
            for (int i = 0; i <= spawncount; i++)
            {
                int spawnNum;
                do
                {
                    spawnNum = Random.Range(0, m_Spawnpoint.Length);
                }
                while (spawnNums.Contains(spawnNum));

                spawnNums.Add(spawnNum);
            }


            foreach (var spawnNum in spawnNums)
            {
                var eulerAngle = m_Spawnpoint[spawnNum].eulerAngles += Vector3.forward * Random.Range(-30f, 30f);
                GameObject FireBall = GameObject.Instantiate(m_EnemyPrefabs,
                        m_Spawnpoint[spawnNum].position, Quaternion.Euler(eulerAngle));
            }
            m_SpawnCoolDown = Random.Range(m_SpawnMin, m_SpawnMax);
        }
        
        m_SpawnCoolDown -= Time.deltaTime;

    }
}
