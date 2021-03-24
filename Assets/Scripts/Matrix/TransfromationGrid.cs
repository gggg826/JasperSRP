using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromationGrid : MonoBehaviour
{
    private const int GRID_COUNT = 10;

    [SerializeField]
    private GameObject m_VertexTemplate;

    private Transform[] m_VertexGrid;

    void Awake()
    {
        m_VertexGrid = new Transform[GRID_COUNT * GRID_COUNT * GRID_COUNT];
        for (int i = 0, x = 0; x < GRID_COUNT; x++)
        {
            for (int y = 0; y < GRID_COUNT; y++)
            {
                for (int z = 0; z < GRID_COUNT; z++, i++)
                {
                    m_VertexGrid[i] = GenerateVertex(x, y, z);
                }

            }
        }
    }

    private Transform GenerateVertex(int x, int y, int z)
    {
        Transform trans = Instantiate(m_VertexTemplate).transform;
        trans.localPosition = GetCoordinates(x, y, z);
        trans.GetComponent<MeshRenderer>().material.color = new Color((float)x / GRID_COUNT, (float)y / GRID_COUNT, (float)z / GRID_COUNT);
        return trans;
    }

    private Vector3 GetCoordinates(int x, int y, int z)
    {
        //整个VertexGrid以中心点为锚点
        return new Vector3(x - (GRID_COUNT - 1) * 0.5f
                         , y - (GRID_COUNT - 1) * 0.5f
                         , z - (GRID_COUNT - 1) * 0.5f);
    }

    void Update()
    {
        
    }
}
