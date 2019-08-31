using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivateCountDown : MonoBehaviour
{
    HealthController health;
    [SerializeField]
    CountDownObject timer;
    TerminalMinigame game;
    IEnumerator count;

    public event Action OnFailure = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
        game = GetComponent<TerminalMinigame>();
        game.OnComplete += HandleCompletion;
        count = CountDown();
        timer.isFailure = false;

    }

    void HandleDie()
    {
        StartCoroutine(count);
    }

    IEnumerator CountDown()
    {
        timer.isCountDown = true;
        timer.countDownTime = 10;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 9;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 8;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 7;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 6;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 5;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 4;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 3;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 2;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 1;
        yield return new WaitForSeconds(1.3f);
        timer.countDownTime = 0;
        yield return new WaitForSeconds(1.3f);
        timer.isFailure = true;
        OnFailure();

    }
    void HandleCompletion()
    {
        timer.isCountDown = false;
        timer.isFailure = false;
        StopCoroutine(count);
        count = CountDown();
    }
}
