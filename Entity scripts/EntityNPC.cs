using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityNPC : Entity
{
    public bool isFriendly;
    public Entity target;
    protected virtual void Update()
    {
        StateUpdateAction();
    }

    protected virtual void FixedUpdate()
    {
        StateFixedUpdateAction();
    }

    protected override void EntityFixedUpdate()
    {
        print("Default Fixed Update Action");
    }
    protected override void EntityUpdate()
    {
        print("Default Update Action");
    }
}
