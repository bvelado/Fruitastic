using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIText))]
public class PlayerMoneyView : MonoBehaviour, IPlayerMoneyChangedListener {

    private UIText text;

    private void Awake()
    {
        text = GetComponent<UIText>();
    }

    public void PlayerMoneyChanged(long value)
    {
        text.content = string.Format("{0}", value);
        text.Apply();
    }

    private void Start()
    {
        Contexts.sharedInstance.uI.CreateEntity().AddPlayerMoneyChanged(this);
    }



}
