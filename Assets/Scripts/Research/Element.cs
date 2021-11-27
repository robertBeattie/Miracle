using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Element", menuName = "Element")]
public class Element : ScriptableObject {
    public Sprite icon;
    public int amount;
    public string name;

    [Header("Element Combination")]
    public Element element1;
    public Element element2;
}
