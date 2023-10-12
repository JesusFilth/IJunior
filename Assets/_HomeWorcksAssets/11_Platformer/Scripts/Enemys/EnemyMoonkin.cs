using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoonkin : EnemyPlatformer
{
    
    private class AnimationData
    {
        public class Params
        {
            public static int Attack = Animator.StringToHash(nameof(Attack));
            public static int Damage = Animator.StringToHash(nameof(Damage));
            public static int Walk = Animator.StringToHash(nameof(Walk));
        }
    }
}
