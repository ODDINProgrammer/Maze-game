using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnActors : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private GameObject _player;

    [SerializeField] private Transform _minotaurSpawnPoint;
    [SerializeField] private GameObject _minotaur;

    private void Start()
    {
        if (_player == null || _playerSpawnPoint == null) return;
        var player = Instantiate(_player);
        player.transform.position = _playerSpawnPoint.position;

        if (_minotaur == null || _minotaurSpawnPoint == null) return;
        var minotaur = Instantiate(_minotaur);
        minotaur.transform.position = _minotaurSpawnPoint.position;
    }
}
