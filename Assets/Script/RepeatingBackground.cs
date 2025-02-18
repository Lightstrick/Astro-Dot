﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D m_backgroundCollider;
    private float m_BackgroundSize;
    
    // Start is called before the first frame update
    void Start()
    {
        m_backgroundCollider = GetComponent<BoxCollider2D>();
        m_BackgroundSize = m_backgroundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -m_BackgroundSize)
            RepeateBackground();
    }

    void RepeateBackground()
    {
        Vector2 BGoffset = new Vector2(0, m_BackgroundSize * 2f);
        transform.position = (Vector2)transform.position + BGoffset;
    }
}
