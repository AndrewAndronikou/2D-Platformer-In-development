using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    [SerializeField] float animationSpeed = 1.0f;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = animationSpeed;
    }
}
