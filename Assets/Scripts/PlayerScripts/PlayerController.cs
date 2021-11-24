using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private Rigidbody2D myRb2D;
    private UnitCollisionPlayer uctp;
    Coroutine firingCoroutine;

    [Header("Fire Configuration")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject pfBullet;
    [SerializeField] GameObject pfBulletCritic;
    [SerializeField] float firePeriod = 0.2f;
    [SerializeField] float nextFire = 0f;
    [SerializeField] float rateUpTime = 0;
    [SerializeField] TextMeshProUGUI fireRateRank;
    float realFR;
    [Header("Charge Attack Configuration")]
    [SerializeField] float chargeTime = 2;
    [SerializeField] Transform chargePoint;
    [SerializeField] GameObject pfCharge;
    [SerializeField] GameObject pfChargeCritic;
    [SerializeField] ParticleSystem chargeImpact;
    float attackButtonTimer;
    bool timerOn;
    float criticRate;
    [Header("MoveMent Configuration")]
    [SerializeField] float moveSpeed = 80f;
    [SerializeField] float rotatePower = 100f;
    [Header("SFV Configuration")]
    [SerializeField] AudioClip fireSFX;
    [SerializeField] [Range(0, 1)] float fireSFXVolume = 0.7f;





    // Start is called before the first frame update
    void Awake()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        uctp = GameObject.FindGameObjectWithTag("Player").GetComponent<UnitCollisionPlayer>();


        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.ChargeAttack.started += ChargeAttackStart;
        playerInputActions.Player.ChargeAttack.canceled += ChargeAttackCancle;

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("FireRate"))
        {
            rateUpTime = PlayerPrefs.GetFloat("FireRate");
        }        
        fireRateRank.text = "rank" + rateUpTime;
    }
    // Update is called once per frame
    void Update()
    {
        MoveMent();
        Rotation();
        Fire();
        GetFireRate();
        ChargeTimer();
    }
    void Fire()
    {
        if (Time.time > nextFire && playerInputActions.Player.Fire1.ReadValue<float>() > 0)
        {
            CalculateFireRate();
            Shoot();
            ChargeAnimation();
        }
    }

    private void ChargeAnimation()
    {
        var cpMain = chargeImpact.main;
        cpMain.startColor = Color.Lerp(Color.blue, Color.red, attackButtonTimer / chargeTime);
        if (!chargeImpact.isPlaying)
        {
            chargeImpact.Play();

        }
    }

    private void Shoot()
    {
        float fireRandom = Random.Range(0.0f, 1.0f);
        criticRate = uctp.GetCritic();
        if(fireRandom<=criticRate)
        {
            Instantiate(pfBulletCritic, firePoint.position, firePoint.rotation);
            AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);
        }
        else
        {
        Instantiate(pfBullet, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(fireSFX, Camera.main.transform.position, fireSFXVolume);
        }
    }

    private void CalculateFireRate()
    {
        float multiplier = FindObjectOfType<ItemHandler>().GetFireRateMultiplier();
        realFR = firePeriod * Mathf.Pow(multiplier, rateUpTime);            
        nextFire = Time.time + realFR;
    }

    public float GetFireRate()
    {
        return rateUpTime;
    }
    public void ChargeAttackStart(InputAction.CallbackContext context)
    {
        timerOn = true;
    }
    public void ChargeAttackCancle(InputAction.CallbackContext context)
    {
        chargeImpact.Stop();
        if (attackButtonTimer >= chargeTime)
        {
            float fireRandom = Random.Range(0.0f, 1.0f);
            criticRate = uctp.GetCritic();
            if (fireRandom <= criticRate)
            {
                Instantiate(pfChargeCritic, chargePoint.position, chargePoint.rotation);
                timerOn = false;
            }
            else
            {
                Instantiate(pfCharge, chargePoint.position, chargePoint.rotation);
                timerOn = false;
            }
        }
        else
        {
            timerOn = false;
        }

    }
    void ChargeTimer()
    {
        if (timerOn)
        {
            attackButtonTimer += Time.deltaTime;
        }
        if (!timerOn)
        {
            attackButtonTimer = 0;
        }
    }
    private void MoveMent()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        myRb2D.AddForce(new Vector2(inputVector.x, inputVector.y) * moveSpeed * Time.deltaTime);
    }

    void rotateProcess(float rotateThisFrame)
    {
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
    }

    void Rotation()
    {
        transform.Rotate(Vector3.forward * playerInputActions.Player.Rotation.ReadValue<float>() * Time.deltaTime * rotatePower);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireRater")
        {
            rateUpTime += 1;
            fireRateRank.text = "rank" + rateUpTime;
        }
    }

    public float GetRateRank()
    {
        return rateUpTime;
    }
}
