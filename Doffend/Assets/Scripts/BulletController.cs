﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Goblin")
        {
            GameObject goblin = other.gameObject;
            Goblin_Health script = goblin.GetComponent<Goblin_Health>();
            script.hitPoints -= 1;

            Destroy(gameObject);
        }
    }

}
