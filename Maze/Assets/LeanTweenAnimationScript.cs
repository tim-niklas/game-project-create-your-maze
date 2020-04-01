using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenAnimationScript : MonoBehaviour
{
    // Animation for the cube goal
    void Start()
    {
        LeanTween.moveY(this.gameObject, 2, 0.5f).setEaseLinear().setLoopPingPong();
        LeanTween.rotateY(this.gameObject, 180, 2).setEaseInOutBack().setLoopPingPong();
    }

}
