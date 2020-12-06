﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionOnExit : StateMachineBehaviour {
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {   
        Destroy(animator.transform.parent.gameObject, stateInfo.length);
    }
}
