using UnityEngine;
using System.Collections.Generic;
using System;

public class TransfromationGrid : MonoBehaviour
{
    private const int GRID_COUNT = 10;

    [SerializeField]
    private GameObject m_VertexTemplate;

    private Transform[] m_VertexGrid;

    private List<TransformationBase> m_Transformations;

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
        m_Transformations = new List<TransformationBase>();
    }

    void Update()
    {
        //为什么要在Update获取组件？
        //这样就可以在保持播放模式的同时使用Transform组件，并立即看到结果。
        //为什么使用List而不是数组？
        //GetComponents方法的最直接的版本只是返回一个包含请求类型的所有组件的数组。 这意味着每次调用都会创建一个新数组，在本例中是每次Update。 
        //替代版本具有列表参数。 这样做的好处是它将把组件放到列表中，而不是创建一个新的数组。
        //但在我看来，这不是一个关键的优化，但是当你需要经常获取组件时，使用list是个好习惯。
        GetComponents<TransformationBase>(m_Transformations);

        for (int i = 0, x = 0; x < GRID_COUNT; x++)
        {
            for (int y = 0; y < GRID_COUNT; y++)
            {
                for (int z = 0; z < GRID_COUNT; z++, i++)
                {
                    m_VertexGrid[i].localPosition = TransformVertex(x, y, z);
                }
            }
        }
    }

    private Transform GenerateVertex(int x, int y, int z)
    {
        Transform trans = Instantiate(m_VertexTemplate).transform;
        trans.localPosition = GetCoordinate(x, y, z);
        trans.GetComponent<MeshRenderer>().material.color = new Color((float)x / GRID_COUNT, (float)y / GRID_COUNT, (float)z / GRID_COUNT);
        return trans;
    }

    private Vector3 GetCoordinate(int x, int y, int z)
    {
        //整个VertexGrid以中心点为锚点
        return new Vector3(x - (GRID_COUNT - 1) * 0.5f
                         , y - (GRID_COUNT - 1) * 0.5f
                         , z - (GRID_COUNT - 1) * 0.5f);
    }

    private Vector3 TransformVertex(int x, int y, int z)
    {
        Vector3 coordinate = GetCoordinate(x, y, z);
        for (int i = 0; i < m_Transformations.Count; i++)
        {
            coordinate = m_Transformations[i].Apply(coordinate);
        }
        return coordinate;
    }
}
