using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_test : Enemy
{
    public float speed;
    public float StartWaitTime;
    private float WaitTime;

    public Transform movePos;
    public Transform rightupPos;
    public Transform leftdownPos;
    void Start()
    {
        base.Start();
        WaitTime = StartWaitTime;
        movePos.position = GetMovePos();
    }
    void Update()
    {
        base.Update();
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (WaitTime <= 0)
            {
                movePos.position = GetMovePos();
                WaitTime = StartWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetMovePos()
    {
        Vector2 nextPos = new Vector2(Random.Range(rightupPos.position.x,leftdownPos.position.x), rightupPos.position.y);
        return nextPos;
    }
   
}
