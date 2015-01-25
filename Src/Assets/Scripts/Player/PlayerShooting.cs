using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 100;                  // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.15f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.
	public Transform gunman;

	float timer;                                    // A timer to determine when to fire.
	Ray shootRay;                                   // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
	ParticleSystem gunParticles;                    // Reference to the particle system.
	LineRenderer gunLine;                           // Reference to the line renderer.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	
	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask ("Shootable");
		
		// Set up the references.
//		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		//gunAudio = GetComponent<AudioSource> ();
		//gunLight = GetComponent<Light> ();
	}
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		
		// If the Fire1 button is being press and it's time to fire...
		if(timer >= timeBetweenBullets)
		{
			// ... shoot the gun.
			Shoot ();
		}
		
		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects ();
		}
	}
	
	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		//gunLight.enabled = false;
	}
	
	void Shoot ()
	{
		float h = Input.GetAxisRaw ("Horizontal_02");
		float v = Input.GetAxisRaw ("Vertical_02");

		if (h == 0 && v == 0) return;

		// Reset the timer.
		timer = 0f;
		
		// Play the gun shot audioclip.
		//gunAudio.Play ();
		
		// Enable the light.
		//gunLight.enabled = true;
		
		// Stop the particles from playing if they were, then start the particles.
//		gunParticles.Stop ();
//		gunParticles.Play ();
		
		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);
		
		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		shootRay.origin = transform.position;

		if( h >0)
		{
			shootRay.direction = transform.right; goRight();
		} else if ( h < 0 ){
			shootRay.direction = -transform.right; goLeft();
		} else if ( v > 0 ){
			shootRay.direction = transform.forward; goUp();
		} else if ( v < 0 ){
			shootRay.direction = -transform.forward; goDown();
		}

//		if( h == 0 && v == 0) shootRay.direction = transform.forward;
//		shootRay.direction = transform.forward;
		
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			// Try and find an EnemyHealth script on the gameobject hit.
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			
			// If the EnemyHealth component exist...
			if(enemyHealth != null)
			{
				// ... the enemy should take damage.
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			
			// Set the second position of the line renderer to the point the raycast hit.
			gunLine.SetPosition (1, shootHit.point);
		}
		// If the raycast didn't hit anything on the shootable layer...
		else
		{
			// ... set the second position of the line renderer to the fullest extent of the gun's range.
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}

	public void goRight() {
		if (gunman) gunman.forward=  Vector3.right;
	}
	
	public void goLeft() {
		if (gunman) gunman.forward= -Vector3.right;
	}
	
	public void goUp() {
		if (gunman) gunman.forward= -Vector3.back;
	}
	
	public void goDown() {
		if (gunman) gunman.forward= Vector3.back;
	}
}
