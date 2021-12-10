using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoSingleton<AnimatorControl>
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
