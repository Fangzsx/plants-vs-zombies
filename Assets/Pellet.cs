﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }
}
