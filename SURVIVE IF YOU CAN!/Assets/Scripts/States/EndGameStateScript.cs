using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGameStateScript : MonoBehaviour, IState
{
    [SerializeField] private GameObject _endScreen;
    //[SerializeField] private TextMeshProUGUI _quitText;

    private bool _isWaitingToQuit;
    private Coroutine _coroutine;
    public void Enter()
    {
        _isWaitingToQuit = true;
        _coroutine = StartCoroutine(WaitForQuit());
        _endScreen.SetActive(true);
    }

    public void Exit()
    {
        _isWaitingToQuit = false;
        StopCoroutine(_coroutine);
        _endScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            //FindObjectOfType<GameManager>().SetState(StateType.PreGameState);
            Application.Quit();
        }
    }
    private IEnumerator WaitForQuit()
    {
        float t = 0;
        while (_isWaitingToQuit)
        {
            /*var val = Mathf.PingPong(t, 1f) + 0.5f;
            _quitText.color = new Color(1, 1, 1, val);*/
            yield return null;
            t += Time.deltaTime;
        }
    }
}
