using UnityEngine;

public class WaveManager : MonoSingleton<WaveManager>
{
    [Header("WaveInfo")]
    [SerializeField] private float _amplitude = 1.0f;
    [SerializeField] private float _length = 2.0f;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _offset = 0f;

    private void Update()
    {
        _offset += Time.deltaTime * _speed;

       
    }

    public float GetWaveHeight(float x)
    {
        return _amplitude * Mathf.Sin(x / _length + _offset);
    }
}
