using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{

    [SerializeField] private List<SpotController> spots; 
    void OnCollisionEnter(Collision collision)
    {
     if(collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            TryToPutOnCabinet(collision.gameObject);
        }    
    }

    void TryToPutOnCabinet(GameObject gameObject)
    {
        if(GetAvaiableSpot() is SpotController avaiableSpot)
        {
            gameObject.transform.SetParent(avaiableSpot.transform);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;

            if(gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true; 
            }
        }
    }

    public SpotController GetAvaiableSpot()
    {
        foreach(SpotController spot in spots)
        {
            if(!spot.IsOccupied())
            {
                return spot;
            }
        }
        return null;
    }
}
