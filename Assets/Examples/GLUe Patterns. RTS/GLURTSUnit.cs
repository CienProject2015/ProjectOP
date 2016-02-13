using UnityEngine;
using System;
using System.Collections;

public enum GLURTSUnitState
{
    reserved = 0,
    standing = 1,
    moving = 2
}

[Serializable]
public class GLURTSUnit : MonoBehaviour, IGLUGameUnit
{
    public static GLURTSUnit instance = null;
    public GameObject rotator;
    public GameObject selector;
    public GameObject leftFlashLight;
    public GameObject rightFlashLight;
    public ParticleSystem deadSmoke;
    public ParticleSystem deadFire;
    public ParticleSystem smoke;
    public ParticleSystem sparcs;

    [SerializeField]
    private float _maxHealth = 100;
    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private float _health = 50;
    public float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }


    public static Material _collisionMaterial = null;
    public static Material collisionMaterial
    {
        get
        {
            if (_collisionMaterial == null)
            {
                _collisionMaterial = new Material(instance.material);
                // _collisionMaterial = new Material(Shader.Find("GLU/GLU Image Shader"));
                _collisionMaterial.color = new Color(1, 0, 0, 1);
            }
            return _collisionMaterial;
        }
    }

    public Material material = null;

    public GLURTSUnitState state = GLURTSUnitState.reserved;
    public GLUMinMaxPair stateChangeInterval = new GLUMinMaxPair(0.33f, 1f);
    public Rect constraints = new Rect(0, 0, 100, 100);
    public float targetEpsilon = 0.1f;
    public float movingSpeed = 0.5f;
    public float collisionRadius = 0.25f;
    public float maxWayChunk = 1;
    public bool targetReached = true;
    [NonSerialized]
    private bool _rallyIsSet = false;
    public bool rallyIsSet
    {
        get
        {
            return _rallyIsSet;
        }

        set
        {
            _rallyIsSet = value;
            if (_rallyIsSet)
            {
                leftFlashLight.SetActiveRecursively(true);
                rightFlashLight.SetActiveRecursively(false);
                flashingCommutationTime = Time.time + flashingInterval;
            }
            else
            {
                leftFlashLight.SetActiveRecursively(false);
                rightFlashLight.SetActiveRecursively(false);
                // flashingCommutationTime = Time.time + flashingInterval;
            }
        }
    }
    /* [NonSerialized]
    public bool inCollision = false; */
    public float rotationSpeed = 360;
    [NonSerialized]
    public float collisionShowInterval = 0.1f;
    public float collisionhideTime = 0;
    [NonSerialized]
    public bool rotating = false;
    public float accelerationWayLength = 0.33f;
    public float targetDistance = 0.33f;
    public float rallyDistance = 0.33f;
    public float flashingInterval = 0.5f;
    public float flashingCommutationTime = 0;
    public bool debug = false;

    private bool _selected = false;
    public bool selected
    {
        get
        {
            return _selected;
        }
        set
        {
            if (_selected != value)
            {
                _selected = value;
                // Debug.Log(this + " selected = " + selected);
                selector.active = _selected;
            }
        }
    }


    public void Awake()
    {
        instance = this;
        material = GetComponent<Renderer>().sharedMaterial;
        rotator = transform.FindChild("rotator").gameObject;
        selector = transform.FindChild("selector").gameObject;
        leftFlashLight = transform.FindChild("leftFlashLightCookie").gameObject;
        rightFlashLight = transform.FindChild("rightFlashLightCookie").gameObject;
        smoke = transform.FindChild("smoke").GetComponent<ParticleSystem>();
        deadSmoke = transform.FindChild("deadSmoke").GetComponent<ParticleSystem>();
        deadFire = transform.FindChild("deadFire").GetComponent<ParticleSystem>();
        sparcs = transform.FindChild("sparcs").GetComponent<ParticleSystem>();
        deadSmoke.gameObject.active = false;
        deadSmoke.Stop();
        deadFire.gameObject.active = false;
        deadFire.Stop();
        smoke.Stop();
        sparcs.gameObject.active = false;
        sparcs.Stop();
        rotator.active = false;
        selector.active = false;
        leftFlashLight.SetActiveRecursively(false);
        rightFlashLight.SetActiveRecursively(false);
    }

    public void SetRallyPoint(Vector3 rally)
    {
        this.rallyIsSet = true;
        this.rally = rally;
    }

    // Use this for initialization
    public void Start()
    {
        // StartCoroutine(StateController());
        targetReached = true;
        state = GLURTSUnitState.reserved;
    }

    public IEnumerator StateController()
    {
        yield return null;
    }

    private float GetNextStateChangeTime()
    {
        return Time.time + UnityEngine.Random.Range(stateChangeInterval.min, stateChangeInterval.max);
    }

    private GLURTSUnitState GetNewState()
    {
        if (rallyIsSet)
            return GLURTSUnitState.moving;
        else
            return (GLURTSUnitState)(UnityEngine.Random.Range(0, 2) + 1);
    }

    public Vector3 GetNewTarget()
    {
        Vector3 v;
        Vector3 dv;
        if (rallyIsSet)
        {
            v = rally;
            dv = v - transform.position;
            if (dv.magnitude > maxWayChunk)
            {
                dv.Normalize();
                v = transform.position + dv * maxWayChunk;
                v.y = 0;
            }
            if (!IsObstacle(v))
                return v;
        }
        v = new Vector3(UnityEngine.Random.Range(constraints.xMin, constraints.xMax), 0, UnityEngine.Random.Range(constraints.yMin, constraints.yMax));
        dv = v - transform.position;
        if (dv.magnitude > maxWayChunk)
        {
            dv.Normalize();
            v = transform.position + dv * maxWayChunk;
            v.y = 0;
        }
        return v;
    }

    public Vector3 GetSpawnPosition()
    {
        Vector3 v;
        v = new Vector3(UnityEngine.Random.Range(constraints.xMin, constraints.xMax), 0, UnityEngine.Random.Range(constraints.yMin, constraints.yMax));
        return v;
    }

    [NonSerialized]
    public Vector3 target = new Vector3(0, 0, 0);
    public Vector3 rally = new Vector3(0, 0, 0);
    public float rotationTarget = 0;
    private float standingTime = 0;
    public Vector3 currentVelocity;
    private Vector3 startPosition;
    [NonSerialized]
    private bool collisionInProgress = false;
    // private int rotationSteps = 0;

    public void FireCollision()
    {
        health = health - 1;
        if (health <= 0)
        {
            deadSmoke.gameObject.active = true;
            deadSmoke.Play();
            deadFire.gameObject.active = true;
            deadFire.Play();
        }
        else
        {
            collisionhideTime = Time.time + collisionShowInterval;
            collisionInProgress = true;
            sparcs.gameObject.active = true;
            sparcs.Play();
        }
        // renderer.sharedMaterial = collisionMaterial;
    }

    private static float ClampAngle(float angle)
    {
        float a = angle % 360;
        /* if (a > 180)
            a = a - 360;
        if (a < -180)
            a += 360; */
        if (a < 0)
            a += 360;
        return a;
    }

    public bool IsObstacle(Vector3 position)
    {
        Vector3 v = transform.position - target;
        Ray r = new Ray(transform.position, v);
        RaycastHit hit;
        GetComponent<Collider>().enabled = false;
        bool res = Physics.SphereCast(r, collisionRadius, out hit, v.magnitude);
        GetComponent<Collider>().enabled = true;
        return res;
    }

    [NonSerialized]
    private bool justStartMoving = true;

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
            return;

        if (targetReached)
        {
            targetReached = false;
            state = GetNewState();
            leftFlashLight.SetActiveRecursively(false);
            rightFlashLight.SetActiveRecursively(false);
            smoke.Stop();
            //stateChangeTime = GetNextStateChangeTime();

            switch (state)
            {
                case GLURTSUnitState.standing:
                    standingTime = GetNextStateChangeTime();
                    break;
                case GLURTSUnitState.moving:
                    target = GetNewTarget();

                    // rotationTarget = Quaternion.FromToRotation(Vector3.right, target).eulerAngles.y;
                    // rotationTarget = ClampAngle(Quaternion.LookRotation(target - transform.position).eulerAngles.y);
                    startPosition = transform.position;
                    rotationTarget = ClampAngle(Quaternion.LookRotation(target - startPosition).eulerAngles.y);
                    targetDistance = (target - startPosition).magnitude;
                    justStartMoving = true;
                    rotating = true;
                    rotator.active = true;
                    smoke.Play();
                    currentVelocity = (target - startPosition).normalized * movingSpeed;

                    break;
                default:
                    break;
            }

        }

        switch (state)
        {
            case GLURTSUnitState.moving:
                if (rotating)
                {
                    float ca = ClampAngle(transform.rotation.eulerAngles.y);
                    float na;
                    float rd = rotationTarget - ca;
                    /* if (Mathf.Abs(rd) > 180)
                        na = ca - Mathf.Sign(rd) * rotationSpeed * Time.deltaTime;
                    else */
                    na = ca + Mathf.Sign(rd) * rotationSpeed * Time.deltaTime;

                    if (Mathf.Abs(rotationTarget - ca) < Mathf.Abs(rotationTarget - na))
                    {
                        rotating = false;
                        rotator.active = false;
                    }
                    else
                    {
                        Vector3 ea = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(ea.x, na, ea.z);
                    }
                }
                else
                {
                    Vector3 v;
                    float w = (transform.position - startPosition).magnitude;
                    if (w + 0.1f < accelerationWayLength)
                        v = currentVelocity * Time.deltaTime * (w + 0.1f) / accelerationWayLength;
                    else
                        v = currentVelocity * Time.deltaTime;

                    if (w > targetDistance - accelerationWayLength)
                        v = currentVelocity * Time.deltaTime * (targetDistance - w + 0.1f) / accelerationWayLength;
                    else
                        v = currentVelocity * Time.deltaTime;

                    Ray r = new Ray(transform.position, v);
                    RaycastHit hit;
                    GetComponent<Collider>().enabled = false;
                    // if (Physics.SphereCast(r, collisionRadius, out hit, v.magnitude))
                    if (Physics.Raycast(r, out hit, collisionRadius + v.magnitude))
                    {
                        if (debug)
                            Debug.Log(this + " collision with " + hit.collider.gameObject.name);
                        targetReached = true;
                        if (!justStartMoving)
                            FireCollision();
                    }
                    else
                        if ((target - transform.position).magnitude < (target - transform.position - v).magnitude)
                        {
                            if (rallyIsSet)
                                if ((rally - transform.position - v).magnitude < 1)
                                    rallyIsSet = false;
                            transform.position = target;
                            targetReached = true;
                        }
                        else
                            transform.position += v;
                    justStartMoving = false;
                    GetComponent<Collider>().enabled = true;
                    if (Time.time > flashingCommutationTime && rallyIsSet)
                    {
                        leftFlashLight.SetActiveRecursively(!leftFlashLight.active);
                        rightFlashLight.SetActiveRecursively(!rightFlashLight.active);
                        flashingCommutationTime = Time.time + flashingInterval;
                    }
                }
                break;
            case GLURTSUnitState.reserved:
                // if (Time.time >= standingTime)
                    targetReached = true;
                break;
            case GLURTSUnitState.standing:
                if (Time.time >= standingTime)
                    targetReached = true;
                break;
        }

        if (collisionInProgress)
            if (Time.time > collisionhideTime)
            {
                collisionInProgress = false;
                sparcs.gameObject.active = false;
                sparcs.Stop();
            }
        // renderer.sharedMaterial = material;
    }
}
