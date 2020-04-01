using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenGoalAnimation : MonoBehaviour
{
    // Animation for the goal cube 
    void Start()
    {
        LeanTween.moveY(this.gameObject, 2, 0.5f).setEaseLinear().setLoopPingPong();
        LeanTween.rotateY(this.gameObject, 180, 2).setEaseInOutBack().setLoopPingPong();
    }

}
