using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfItems<T> : ScriptableObject
{
    public List<T> Items;
}