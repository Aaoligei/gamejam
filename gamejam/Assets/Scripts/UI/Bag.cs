using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public List<Slot> slots;
    public Unit belongTo;

    private void Start()
    {
        foreach (Slot slot in slots)
        {
            slot.belongTo = belongTo;
        }
    }
}
