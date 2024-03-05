using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UAPT.Utile;
using UnityEngine.Events;
using System;
using Cursor = UnityEngine.Cursor;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    private VisualElement _root;
    private VisualElement _tabBarWindowContain;
    private UIDocument _doc;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;

    }

    private void OnEnable()
    {
        TabBarInit();
        _inputReader.OpenMapEvent += HandleOpenMap;
        _inputReader.ClosedMapEvent += HandleClosedMap;
    }
    private void OnDestroy()
    {
        _inputReader.OpenMapEvent -= HandleOpenMap;
        _inputReader.ClosedMapEvent -= HandleClosedMap;
    }

    private void HandleClosedMap()
    {
        _tabBarWindowContain.style.opacity = 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void HandleOpenMap()
    {
        _tabBarWindowContain.style.opacity = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void TabBarInit()
    {
        _tabBarWindowContain = _root.Q<VisualElement>("tab_bar_box-contain");

        VisualElement mapContain = _root.Q<VisualElement>("tab_bar_map_button-contain");
        VisualElement inventoryContain = _root.Q<VisualElement>("tab_bar_intventory_button-contain");
        VisualElement questCOntain = _root.Q<VisualElement>("tab_bar_quest_button-contain");

        Button mapButton = _root.Q<Button>("map_icon-button");
        Button inventoryButton = _root.Q<Button>("inventory_icon-button");
        Button questButton = _root.Q<Button>("quest_icon-button");

        ToolKitUtile.SetHoverEvent(mapButton, () => mapContain.AddToClassList("on"));
        ToolKitUtile.SetHoverEvent(inventoryButton, () => inventoryContain.AddToClassList("on"));
        ToolKitUtile.SetHoverEvent(questButton, () => questCOntain.AddToClassList("on"));

        UnHoverEvent(mapButton, () => mapContain.RemoveFromClassList("on"));
        UnHoverEvent(inventoryButton, () => inventoryContain.RemoveFromClassList("on"));
        UnHoverEvent(questButton, () => questCOntain.RemoveFromClassList("on"));
    }

    private void UnHoverEvent(Button btn, UnityAction action)
    {
        btn.RegisterCallback<MouseOutEvent>((evt) => { action?.Invoke();});
    }

}
