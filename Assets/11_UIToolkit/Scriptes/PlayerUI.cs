using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UAPT.Utile;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private UIDocument _doc;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        //ToolKitUtile.SetHoverEvent()
    }

}
