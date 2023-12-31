﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollower : MonoSingleton<CameraFollower>
{
    [SerializeField] private GameObject player;
    public Vector3 offset;

    [SerializeField] private float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPos;
    }
    public void MoveUp(float addYvalue)
    {
        offset += new Vector3(0, addYvalue, -(addYvalue / 2f));
    }
    public void MoveDown(float removeYvalue)
    {
        offset -= new Vector3(0, removeYvalue, -(removeYvalue / 2f));
    }
}