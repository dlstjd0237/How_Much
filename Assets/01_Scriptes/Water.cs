using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Water : MonoBehaviour
{
    private MeshFilter _meshFilter;
    [Header("ScrollInfo")]
    [Range(0f, 10f)]
    [SerializeField] private float _scrollSpeed = 5.0f;
    private Material _mat;
    private float _scrollOffset;
    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        Vector3[] vertices = _meshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i].y = WaveManager.Instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        _meshFilter.mesh.vertices = vertices;
        _meshFilter.mesh.RecalculateNormals();

        _scrollOffset += (Time.deltaTime * _scrollSpeed * 1) * 0.1f;
        float scrollOffsetValue = _scrollOffset * 0.5f;
        _mat.mainTextureOffset = new Vector2(scrollOffsetValue, scrollOffsetValue);
    }
}
