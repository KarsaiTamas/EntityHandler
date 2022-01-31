using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInteractable : Entity
{
    public delegate void InTeractionScript();
    public List<InTeractionScript> DoInteraction=new List<InTeractionScript>();

    protected virtual void Start()
    { 
        DoInteraction.Add(DefaultInteraction);
    }
    protected virtual void DefaultInteraction()
    {
        print("Did a default interaction");
    }

}
