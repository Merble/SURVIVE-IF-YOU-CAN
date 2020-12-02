using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] private GameObject[] _missileObjects;
    [SerializeField] private Transform[] _spawnPoints;
    private float _spawnPeriod = 1f;
    private int _chance;

    private Coroutine _missileCoroutine;
    private void OnEnable()
    {
        _missileCoroutine = StartCoroutine(SpawnMissile(_spawnPeriod));
    }
    private void OnDisable()
    {
        StopCoroutine(_missileCoroutine);
    }
    private IEnumerator SpawnMissile(float spawnPeriod)
    {
        if (spawnPeriod - (Time.realtimeSinceStartup / 10) <= 0.1f)
            spawnPeriod = 0.1f;
        else
            spawnPeriod = spawnPeriod - (Time.realtimeSinceStartup / 10);
        WaitForSeconds wait = new WaitForSeconds(spawnPeriod);
        while(true)
        {
            if(Random.Range(0, 10) <= 2)
            {
                _chance = 0;
            }else
            {
                _chance = 1;
            }
            var gmo = Instantiate(_missileObjects[_chance], _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
            yield return wait;
        }
    }

    /*public void SetSpawnPeriod(float time)
    {
        _spawnPeriod -= _spawnPeriod / time*10;
    }*/
}
