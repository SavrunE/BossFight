using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShonShield : Spell
{
    [SerializeField] private Shield shield;
    [SerializeField] private float duration;

  
    private Mover mover;

    private void Start()
    {
        mover = GetComponent<Mover>();
    }

    
}
