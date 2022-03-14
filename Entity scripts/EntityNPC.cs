using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityNPC : Entity
{
    public bool isFriendly;
    public Entity target;

    private List<float> stats;
    public override List<float> Stats { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    protected virtual void Update()
    {
        StateUpdateAction();
    }

    protected virtual void FixedUpdate()
    {
        StateFixedUpdateAction();
    }
}
