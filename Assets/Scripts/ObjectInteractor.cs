using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private SOObjectInfo objectInfo;
    private bool isHeld = false;
    private bool isLocked = false;
    private bool isScanned = false;
    [SerializeField] private float infoDisplayHeight = 2f;

    public void OnInteract()
    {
        if(isLocked) return;
        Debug.Log("Tocou no Cubo");
        if(HoldingManager.Instance.TryToPickUp(gameObject))
        {
            isHeld = true;
            ShowPanel();
        } else if(isHeld)
        {
            HoldingManager.Instance.Drop();
            isHeld = false;
            HidePanel();
        }
    }

    public void StopInteract()
    {
        Debug.Log("Parei de interagir");
        HoldingManager.Instance.Drop();
    }

    // Update is called once per frame
    void Update()
    {
        if(InputHandler.TryRayCastHit(out RaycastHit raycastHit))
        {
            if(raycastHit.transform == transform)
            {
                OnInteract();
            }
        }
    }

    public void ShowPanel()
    {
        Debug.Log("Entrei no ShowPanel");
        
        if(objectInfo == null || isScanned == false) return;
        Debug.Log(objectInfo);
        var infoController = FindObjectOfType<ObjectInfoController>();
        Debug.Log(infoController);
        if(infoController != null)
        {
            Debug.Log("Achei um Info Controller no Show");
            infoController.SetObjectInfo(objectInfo);
            infoController.SetVisible(true);
             
            infoController.transform.SetParent(transform);
            infoController.transform.localPosition = new Vector3(0, infoDisplayHeight, 0);

        }
    }

    public void HidePanel()
    {
        Debug.Log("Entrei no HidePanel");
        var infoController = FindObjectOfType<ObjectInfoController>();
        if(infoController != null)
        {
            Debug.Log("Achei um Info Controller no Hide");
            infoController.SetVisible(false);
            infoController.transform.SetParent(null);
        }
    }

    public void SetLocked(bool isLocked = true)
    {
        this.isLocked = isLocked;
    }

    public void SetScanned(bool isScanned = true)
    {
        this.isScanned = isScanned;
    }

// Desafio 01
    public void ChageColor()
    {
        var render = GetComponent<Renderer>();
        if (render != null)
        {
            render.material.color = Color.red;
        }
    }

    // public IEnumerator HoldingAnimation()
    // {
        
    // }
}
