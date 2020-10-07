using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header(header: "Enemy")]
    [SerializeField] float enemyHealth = 100;
    
    [Header(header: "Projectile")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserSfx;
    [SerializeField] [Range(0, 1)]  float laserVolume = 0.5f;

    [Header(header: "Explosion")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] AudioClip explosionSfx;
    [SerializeField] [Range(0, 1)]  float explosionVolume = 0.5f;


    private void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(laserSfx, Camera.main.transform.position, laserVolume);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        enemyHealth -= damageDealer.GetDamageAmount();
        damageDealer.Hit();

        if (enemyHealth <= 0)
        {
            GameObject explosion = Instantiate(explosionPrefab, Camera.main.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSfx, transform.position, explosionVolume);
        }
    }
}
