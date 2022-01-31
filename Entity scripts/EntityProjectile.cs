using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityProjectile : Entity
{

    protected virtual void Update()
    {
        StateUpdateAction();
    }

    protected virtual void FixedUpdate()
    {
        StateFixedUpdateAction();
    }
}
