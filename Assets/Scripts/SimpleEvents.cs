using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEvents : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent enemyKilled;
    public UnityEngine.Events.UnityEvent scoreReached;
    public Transform enemy;
    public Transform goal;
    // Update is called once per frame
    void Update()
    {
        if (!enemy)//enemy is killed
            enemyKilled.Invoke();

        if (!goal)//enemy is killed
            scoreReached.Invoke();
    }
}
