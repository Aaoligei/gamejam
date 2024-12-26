using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Vector3 generatePoint;
    public GameObject saintess;
    public GameObject rider;
    public GameObject archer;
    public GameObject infantry;
    public GameObject magician;
    public Skill fireBall;
    public Skill groupTherapy;
    public Skill rage;
    public Skill heavyStrike_rider;
    public Skill heavyStrike_infantry;

    public void Start()
    {
        fireBall=new FireBall();
        groupTherapy =new GroupTherapy();
        rage =new Rage();
        heavyStrike_rider =new HeavyStrike();
        heavyStrike_infantry =new HeavyStrike();

        saintess.GetComponent<Unit>().InitSelfSkill(groupTherapy);
        rider.GetComponent<Unit>().InitSelfSkill(heavyStrike_rider);
        archer.GetComponent<Unit>().InitSelfSkill(rage);
        infantry.GetComponent<Unit>().InitSelfSkill(heavyStrike_infantry);
        magician.GetComponent<Unit>().InitSelfSkill(fireBall);

    }

    public void GenerateUnit(GameObject go)
    {
        

        GameObject gameobj=Instantiate(go,generatePoint,Quaternion.identity,null);
        gameobj.SetActive(true);
    }
}
