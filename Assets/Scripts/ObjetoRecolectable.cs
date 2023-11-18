using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoRecolectable : MonoBehaviour
{
    [SerializeField] Sprite SpriteObject;
    SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void Spawn(Transform SpawnTransform)
    {
        SR.sprite = SpriteObject;
        transform.position = SpawnTransform.position;
        transform.rotation = SpawnTransform.rotation;
    }

    void Delete()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
