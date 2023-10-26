using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSAnimationData
{
    public class Params
    {
        public static int IsWalk = Animator.StringToHash(nameof(IsWalk));
        public static int PickUp = Animator.StringToHash(nameof(PickUp));
        public static int IsCarry = Animator.StringToHash(nameof(IsCarry));
    }
}
