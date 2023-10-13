using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionPlayerDie : Transition
{
    private void Update()
    {
        if (PlayerTarget.IsDead())
            NeedTransit = true;
    }
}
