using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject explosion;
    private float speed;
    private float health;
    private float maxHealth;
    private Text healthText;
    private Image healthBar;

    public NotificationsManager manager = null;

    void Start()
    {
        speed = 0f;
        health = 100.0f;
        maxHealth = 100.0f;
        healthText = transform.Find("Canvas").Find("Text").GetComponent<Text>();
        healthBar = transform.Find("Canvas").Find("Image2").GetComponent<Image>();
        if(manager != null)
        {
            manager.AddListener(this, "Touch");
            manager.AddListener(this, "Fire");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
        healthText.text = health.ToString();
        healthBar.fillAmount = health / maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ammo")
        {
            Destroy(col.gameObject);
            health -= 10.0f;
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
        }
    }
    public void Touch()
    {
        speed = 1f;
    }
    public void Fire()
    {
        speed = 2f;
    }
}
