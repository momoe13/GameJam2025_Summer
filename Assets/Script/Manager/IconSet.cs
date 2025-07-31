using System;
using Unity.VisualScripting;
using UnityEngine;

public class IconSet : MonoBehaviour
{
    private StageSelect _stageSelect;

    [SerializeField]
    private int stageNum;
    private void Start()
    {
        _stageSelect = GetComponentInParent<StageSelect>();
    }

    private void OnMouseDown()
    {
        _stageSelect.OnStageButtonSelected.Invoke(stageNum);  
    }
}
