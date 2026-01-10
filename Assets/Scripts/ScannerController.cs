using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerController : MonoBehaviour
{
    
    [SerializeField] private SpotController spot;
    [SerializeField] private float scanningDuration = 2f;
    [SerializeField] private GameObject scanUI;

    private Animator animator;

    void Start()
    {
      animator = GetComponent<Animator>();  
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnSpot(collision.gameObject);
        }
    }

    void TryToPutOnSpot(GameObject gameObject)
    {
    Debug.Log("Trying to Put on Spot");
        if(!spot.IsOccupied())
        {
            Debug.Log("Spot is not Occupied");
            gameObject.transform.SetParent(spot.transform);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;

            if(gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
            }

            if(gameObject.TryGetComponent<ObjectInteractor>(out ObjectInteractor objectInteractor))
            {
                StartCoroutine(StartScanning(objectInteractor));
            }

        }
    }

    private IEnumerator StartScanning(ObjectInteractor objectInteractor)
    {
        animator.SetBool("isScanning", true);
        scanUI.SetActive(false);
        objectInteractor.SetLocked(true);
        yield return new WaitForSeconds(scanningDuration);
        animator.SetBool("isScanning", false);
        scanUI.SetActive(true);
        objectInteractor.SetLocked(false);
        objectInteractor.SetScanned();
        objectInteractor.ChageColor();
    }
}
