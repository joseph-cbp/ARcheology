using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiInteractor : MonoBehaviour, IInteractable
{
    private bool isTransformed = false;
    private bool isAnimating = false;
    void Start()
    {
     animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if(InputHandler.TryRayCastHit(out RaycastHit raycast))
        {
            if(raycast.transform == transform)
            {
                OnInteract();
            }
        }
    }
    private Animator animator;
    public void OnInteract()
    {
        if(CanAnimate())
        {
            StartCoroutine(RunAnimation());
        }
    }

    public void StopInteract()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator RunAnimation()
    {
        isAnimating = true;
        animator.SetTrigger("Transformed");
        yield return new WaitForSeconds(2);
        isTransformed = true;
        isAnimating = false;
    }

    private bool CanAnimate()
    {
        return !isTransformed && !isAnimating;
    }
}
