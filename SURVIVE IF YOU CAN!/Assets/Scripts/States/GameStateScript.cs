using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour, IState
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private MissileController _missileController;
    public void Enter()
    {
        if (!_player)
        {
            Debug.LogError("PlayerController yok");
        }
        if (!_missileController)
        {
            Debug.LogError("MissileController yok");
        }
        _player.enabled = true;
        _missileController.enabled = true;
    }

    public void Exit()
    {
        _player.Reset();
        _player.enabled = false;
        _missileController.enabled = false;
    }
}
