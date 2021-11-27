using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="GameItem", menuName = "Items/GameItem")]
public class GameItem : ScriptableObject {
    public Sprite icon;
    public int amount;
    public string displayName, description;
}
