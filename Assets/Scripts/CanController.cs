using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float animationDuration = 2.1f;
   public void OnDrop()
    {
        Debug.Log("Start Pouring");
        StartCoroutine(StartPouring());
        Debug.Log("Finish Pouring");
    }

    private IEnumerator StartPouring()
    {
        animator.SetBool("isPouring", true);
        yield return new WaitForSeconds(animationDuration);
        animator.SetBool("isPouring",false);
    }
}
