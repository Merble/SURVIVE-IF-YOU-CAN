using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    const float _playerSpeed = 10f;
    private Vector3 _initialPosition;

    [SerializeField] private PlayerModel _playerModel;

    [SerializeField] private GameObject _healthBar;
    private HealthBarController _healthBarController;

    private Rigidbody _rb;


    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _initialPosition = _rb.position;
        _playerModel = new PlayerModel();
        _healthBar.SetActive(true);
        _healthBarController = _healthBar.GetComponent<HealthBarController>();
    }

    private void FixedUpdate()
     {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        _rb.velocity = movement * _playerSpeed;
    }

    public void ChangeHP(int value)
    {
        _playerModel.ChangeHP(value);
        if(_playerModel.GetHealthPoint() == 0)
        {
            Die();
        }
        DamageImplementer();
    }

    private void Die()
    {
        //_healthBarController.ResetHpBar();
        FindObjectOfType<GameManager>().SetState(StateType.EndGameState);
    }

    private void DamageImplementer()
    {
        _healthBarController.UpdateSliderValue((_playerModel.GetHealthPoint()));
    }

    public void Reset()
    {
        _rb.position = _initialPosition;
        //_healthBarController.UpdateSliderValue(100);
        _healthBar.SetActive(false);
        
    }
}
