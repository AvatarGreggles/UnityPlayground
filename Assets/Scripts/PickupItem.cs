using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item { Coin }

public class PickupItem : MonoBehaviour, Collectible
{
    [SerializeField] Item item;
    [SerializeField] int value;
    Rigidbody2D rbody;

    public float movementSpeed = 8f; //for instance

    public Item Item
    {
        get => item;
    }

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //    Vector3 direction = (player.transform.position - transform.position).normalized;
        //    rigidbody.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }

    public void Pickup(Player player, GameObject pickedUpItem)
    {
        if (item == Item.Coin)
        {
            CollectCoin(player);
        }

        Destroy(pickedUpItem);
    }

    private void CollectCoin(Player player)
    {
        player.AddCurrency(value);
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.tag == "Player"){
    //         Pickup(other.gameObject.GetComponent<PlayerController>(), gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pickup(other.gameObject.GetComponent<Player>(), gameObject);
        }
    }
}
