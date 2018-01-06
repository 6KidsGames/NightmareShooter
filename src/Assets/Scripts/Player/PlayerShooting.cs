using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public int minDamagePerShot = 10;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public float maxWidth = 0.5f;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    public float chargesec;
    public float maxChargeSec = 10.0f;
    Color originalGunLineColor;
    
    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        originalGunLineColor = gunLine.material.color;
    }


    void Update ()
    {
        chargesec += Time.deltaTime;
        chargesec = Mathf.Min(chargesec, maxChargeSec);
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;
        gunLight.intensity = 100 * chargesec / maxChargeSec;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);
        gunLine.startWidth = maxWidth * chargesec / maxChargeSec;
        gunLine.endWidth = gunLine.startWidth;
        float redScale = 0.2f + 0.8f * chargesec / maxChargeSec;
        gunLine.material.color = new Color(originalGunLineColor.r * redScale, gunLine.material.color.g, gunLine.material.color.b, originalGunLineColor.a * chargesec / maxChargeSec);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (minDamagePerShot + (int)((float)damagePerShot * chargesec/maxChargeSec), shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }

        chargesec = 0;
    }
}
