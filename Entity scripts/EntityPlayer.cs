using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : Entity
{
    private List<float> stats;
    public override List<float> Stats { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    protected override void Awake()
    {
        StateUpdateAction = CheckPlayerKeyEvents;
        StateFixedUpdateAction = () => { print("Fixed Update Action"); };

    }

    private void CheckPlayerKeyEvents()
    {

    }

    protected virtual void Update()
    {
        StateUpdateAction();
    }




    protected virtual void FixedUpdate()
    {
        StateFixedUpdateAction();
    }
}
