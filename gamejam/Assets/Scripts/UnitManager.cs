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
    public FireBall fireBall;
    public GroupTherapy groupTherapy;
    public Rage rage;
    public HeavyStrike heavyStrike_rider;
    public HeavyStrike heavyStrike_infantry;

    private float rand;
    public void Start()
    {
        fireBall=new FireBall();
        groupTherapy =new GroupTherapy();
        rage =new Rage();
        heavyStrike_rider =new HeavyStrike();
        heavyStrike_infantry =new HeavyStrike();

        saintess.GetComponent<Unit>().skill = groupTherapy;
        rider.GetComponent<Unit>().skill = heavyStrike_rider;
        archer.GetComponent<Unit>().skill= rage;
        infantry.GetComponent<Unit>().skill= heavyStrike_infantry;
        magician.GetComponent<Unit>().skill= fireBall;

        saintess.GetComponent<Unit>().InitSelfSkill();
        rider.GetComponent<Unit>().InitSelfSkill();
        archer.GetComponent<Unit>().InitSelfSkill();
        infantry.GetComponent<Unit>().InitSelfSkill();
        magician.GetComponent<Unit>().InitSelfSkill();

    }

    public void GenerateUnit(GameObject go)
    {
        Unit unit = go.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj=Instantiate(go,generatePoint + new Vector3(0f,rand,0f),Quaternion.identity,null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }

    public void GenerateUnitSaintess()
    {
        Unit unit = saintess.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj = Instantiate(saintess, generatePoint + new Vector3(0f, rand, 0f), Quaternion.identity, null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }

    public void GenerateUnitRider()
    {
        Unit unit = rider.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj = Instantiate(rider, generatePoint + new Vector3(0f, rand, 0f), Quaternion.identity, null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }

    public void GenerateUnitMagician()
    {
        Unit unit = magician.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj = Instantiate(magician, generatePoint + new Vector3(0f, rand, 0f), Quaternion.identity, null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }

    public void GenerateUnitInfantry()
    {
        Unit unit = infantry.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj = Instantiate(infantry, generatePoint + new Vector3(0f, rand, 0f), Quaternion.identity, null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }

    public void GenerateUnitArcher()
    {
        Unit unit = archer.GetComponent<Unit>();
        if (unit.cost <= LuneManager.luneNums)
        {
            rand = Random.Range(-1f, 1f);
            GameObject gameobj = Instantiate(archer, generatePoint + new Vector3(0f, rand, 0f), Quaternion.identity, null);
            gameobj.SetActive(true);
            LuneManager.LuneDecrease(unit.cost);
        }
    }
}
