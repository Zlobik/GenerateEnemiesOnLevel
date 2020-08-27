using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private GameObject _zombie;
    [SerializeField] private Transform _spawn;

    private Transform[] _spawns;
    private int _count = 0;
    private float _time;

    private void Start()
    {
        Transform[] spawns = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            spawns[i] = _spawn.GetChild(i);
        }
        _spawns = spawns;
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= 2)
        {
            GameObject gameObject = Instantiate(_zombie, _spawns[_count].position, Quaternion.identity);
            gameObject.SetActive(true);

            Debug.Log(_time);
            _time = 0;

            _count++;

            if (_count == _spawns.Length)
                _count = 0;
        }
    }
}
