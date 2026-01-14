 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingManager : MonoBehaviour
{
    public static HoldingManager Instance {get; private set;}
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float holdPosition = 0.5f;
    [SerializeField] private float speed = 10f;
    private GameObject heldObject;
    void Awake()
    {
      if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void Update()
    {
        if(heldObject != null)
        {
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * holdPosition;
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * speed );
        }
    }

    public void PickUp(GameObject obj)
    {
        if(heldObject == null)
        {
            heldObject = obj;

            obj.transform.SetParent(null);


            var body = heldObject.GetComponent<Rigidbody>();
            
            if(body!= null)
            {
                body.isKinematic = true;
            }
        }
    }

    public void Drop()
    {
        if(heldObject != null)
        {
            if(heldObject.TryGetComponent<CanController>(out CanController cc))
            {
               cc.OnDrop(); 
            }
            var body = heldObject.GetComponent<Rigidbody>();
            if(body != null)
            {
                body.isKinematic = false;
            }
        }
        heldObject = null;

    }

    // public bool CompareGameObject(GameObject obj)
    // {
    //     if(heldObject != null)
    //     {
    //         return heldObject.Equals(obj);
    //     }
    //     return true;
    // }

    public bool TryToPickUp(GameObject obj)
    {
        if(heldObject == null)
        {
            PickUp(obj);
            return true;
        }
        return false;
    }
}
