using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInfoController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject panel;

    public void SetVisible(bool isVisible = true)
    {
        panel.SetActive(isVisible); 
    }
    public void SetObjectInfo(SOObjectInfo objectInfo)
    {
        this.titleText.text = objectInfo.objectName;
        this.descriptionText.text = objectInfo.description;
    }

     
}
