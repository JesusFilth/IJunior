using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationData
{
    public class Params
    {
        public static int IsRun = Animator.StringToHash(nameof(IsRun));
        public static int IsWalk = Animator.StringToHash(nameof(IsWalk));
        public static int Idel = Animator.StringToHash(nameof(Idel));
        public static int Attack = Animator.StringToHash(nameof(Attack));
        public static int Jump = Animator.StringToHash(nameof(Jump));
        public static int IsVictory = Animator.StringToHash(nameof(IsVictory));
        public static int Dead = Animator.StringToHash(nameof(Dead));
    }
}
