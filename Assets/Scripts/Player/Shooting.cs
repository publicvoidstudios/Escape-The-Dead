using UnityEngine;

public class Shooting : MonoBehaviour
{    
    [SerializeField]
    [Range(0f, 2f)]
    public float fireRate;
    [SerializeField]
    LayerMask layerMask = new LayerMask();
    [SerializeField]
    WeaponSwitcher weaponSwitcher;
    [SerializeField]
    ParticleSystem muzzleFlash;
    [SerializeField]
    GameObject bloodImpact;
    [SerializeField]
    GameObject concreteImpact;
    [SerializeField]
    private float nextFireTime;
    private bool shootButtonPressed;
    PlayerProgress player;
    [SerializeField]
    public float rechargeTime;
    [SerializeField]
    float shootingPullingForce;

    private void Start()
    {
        player = GetComponent<PlayerProgress>();
        muzzleFlash = weaponSwitcher.weapons[player.activeWeapon].GetComponentInChildren<ParticleSystem>();
    }
    void Update()
    {
        rechargeTime += Time.deltaTime;
        if (shootButtonPressed && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;            
            Shoot();
            rechargeTime = 0;
            shootButtonPressed = false;
        }
        else if(shootButtonPressed && Time.time < nextFireTime)
        {
            shootButtonPressed = false;
        }
    }

    public void ButtonShoot()
    {
        shootButtonPressed = true;
    }

    private void Shoot()
    {
        if(muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, layerMask))
        {            
            if(hitInfo.collider.tag == "Enemy")
            {
                Instantiate(bloodImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Enemy enemy = hitInfo.collider.GetComponent<Enemy>();
                Rigidbody rB = hitInfo.collider.GetComponent<Rigidbody>();
                rB.AddForceAtPosition(ray.direction * shootingPullingForce, hitInfo.point);
                if (enemy != null)
                {
                    enemy.Die();
                }
            }
            else if(hitInfo.collider.tag == "RBProps")
            {                
                Instantiate(concreteImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Rigidbody propRB = hitInfo.collider.GetComponent<Rigidbody>();
                propRB.AddForceAtPosition(ray.direction * shootingPullingForce, hitInfo.point);
            }
            else
            {
                Instantiate(concreteImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            }
        }
    }
}
