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
}
