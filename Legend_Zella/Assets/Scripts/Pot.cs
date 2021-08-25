using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void SmashStart(){
        StartCoroutine(BreakStart());
    }
    IEnumerator BreakStart(){
        animator.SetBool("isSmashed", true);
        yield return new WaitForSeconds(.4f);
        animator.SetBool("isSmashed", false);
    }
}