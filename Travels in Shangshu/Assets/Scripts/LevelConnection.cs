using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base code thanks to PitilT

[CreateAssetMenu(menuName = "Levels/Connections")]

public class LevelConnection : ScriptableObject
{
    public static LevelConnection ActiveConnection { get; set; }
}
