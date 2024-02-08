using OPS.Obfuscator.Attribute;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(GameplaySettings))]
[DoNotObfuscateClass]
public class GameplaySettings : SerializedScriptableObject
{
    public List<Sprite> skins;

    public float speed;

    [Header("General")]
    public int numberOfLevels;
    public ScreenOrientation screenOrientation = ScreenOrientation.Portrait;
    public float winScreenDelay;
    public bool stopTimeOnWinScreen;

    [HideInInspector]
    public string privacyPolicyLink;
}