﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject {
    public GameItem[] inventory = new GameItem[30];
    public int maxSize = 30;
}
