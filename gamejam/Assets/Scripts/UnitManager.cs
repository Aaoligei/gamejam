using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Vector3 generatePoint;
    public void GenerateUnit(GameObject go)
    {
        Instantiate(go);
    }
}
