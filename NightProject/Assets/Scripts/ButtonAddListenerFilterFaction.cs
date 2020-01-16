using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAddListenerFilterFaction : MonoBehaviour
{
    public FilterFaction filterFaction;
    public string factionName;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => filterFaction.SpawnFactionCards(factionName));
    }
}