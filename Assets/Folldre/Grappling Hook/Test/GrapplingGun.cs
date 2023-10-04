using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("Scripts:")]
    public GrappleRope grappleRope;

    public GameObject point;   //
    private GameObject hitObj;   //

    [Header("Layer Settings:")]
    [SerializeField] private bool grappleToAll = false;
    [SerializeField] private int grappableLayerNumber = 9;
    [SerializeField] private int arrastableLayerNumber = 10; //

    //ATRACCION VAR
    [SerializeField] private float attractionForce;
    [SerializeField] private float attractionRadius = 3f;

    [Header("Transform Refrences:")]
    public Transform gunHolder;
    public Transform gunPivot;
    public Transform firePoint;

    //[Header("Rotation:")]
    //[SerializeField] private bool rotateOverTime = true;
    //[Range(0, 80)] [SerializeField] private float rotationSpeed = 4;

    [Header("Distance:")]
    [SerializeField] private bool hasMaxDistance = true;
    [SerializeField] private float maxDistance = 4;

    [Header("Launching")]
    [SerializeField] private bool launchToPoint = true;
    [SerializeField] private LaunchType Launch_Type = LaunchType.Transform_Launch;
    [Range(0, 5)] [SerializeField] private float launchSpeed = 5;

    [Header("No Launch To Point")]
    [SerializeField] private bool autoCongifureDistance = false;
    [SerializeField] private float targetDistance = 3;
    [SerializeField] private float targetFrequency = 3;

    private enum LaunchType
    {
        Transform_Launch,
        Physics_Launch,
    }

    [Header("Component Refrences:")]
    public SpringJoint2D m_springJoint2D;

    [HideInInspector] public Vector2 grapplePoint;
    [HideInInspector] public Vector2 DistanceVector;

    public Rigidbody2D ballRigidbody;

    [SerializeField] 
    private bool atraer = false; //

    private void Start()
    {
        grappleRope.enabled = false;
        m_springJoint2D.enabled = false;
        ballRigidbody.gravityScale = 1;
    }

    private void Update()
    {
        if (atraer)
        {

            //Vector3 direccion = (point.transform.position).normalized;
            //float distancia = Vector3.Distance(transform.position, point.transform.position);
            //if (distancia > 0.1f)
            //{
            //    ballRigidbody.isKinematic = true;
            //    point.transform.Translate(direccion * 5f * Time.deltaTime);
            //}
            //else if(distancia < 0.1)
            //{

            //    atraer = false;
            //}

            //grappleRope.transform.parent = point.transform;
            grapplePoint = new Vector2(point.transform.position.x, point.transform.position.y);
            point.transform.position = Vector2.MoveTowards(point.transform.position, this.transform.position, 0.05f);
            DistanceVector = (Vector2)point.transform.position - (Vector2)gunPivot.position;    //CALCULA EL VECTOR DE DISTANCIA
                                                                                                //grappleRope.enabled = true;
                                                                                                //m_springJoint2D.enabled = true;
            print("ccc");
            if (Input.GetKeyDown(KeyCode.E)) //Aqui detecto si el objeto esta apegado a mi, de momento al estar cerca mio lo suelto pero si quiero lanzarlo aqui la logica
            {
                //logica de enganche
                hitObj.transform.parent = null;
                
                point.transform.position = new Vector3(100, 100, 0);
                print("Solte");
                atraer = false; 
                //grappleRope.transform.parent = null;
                //grappleRope.enabled = false;
                //m_springJoint2D.enabled = false;
                //ballRigidbody.gravityScale = 1;
                //hitObj.transform.parent = null;
            }
        }
        //else
        //{
        //    ballRigidbody.isKinematic = false;
        //}

      


        else if (Input.GetKeyDown(KeyCode.E) && !atraer)
        {
            SetGrapplePoint();              //Establece el punto de agarre
            print("Dispare");
        }
        else if (Input.GetKey(KeyCode.R))   //Manejo de rotacion y lanzamiento
        {
            if (grappleRope.enabled)
            {
                //RotateGun(grapplePoint, false);
            }
            else
            {
                //RotateGun(m_camera.ScreenToWorldPoint(Input.mousePosition), false);
            }

            if (launchToPoint && grappleRope.isGrappling)
            {
                // Usa Vector3.Lerp para mover suavemente gunHolder hacia grapplePoint
                // con una velocidad controlada por launchSpeed
                if (Launch_Type == LaunchType.Transform_Launch)
                {
                    gunHolder.position = Vector3.Lerp(gunHolder.position, grapplePoint, Time.deltaTime * launchSpeed);
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            //DEHABILITA EL GANCHO
            grappleRope.enabled = false;
            m_springJoint2D.enabled = false;
            ballRigidbody.gravityScale = 1;
        }
        else
        {
            //RotateGun(m_camera.ScreenToWorldPoint(Input.mousePosition), true);
        }
    }

    void SetGrapplePoint() //ESTABLECE EL PUNTO DE AGARRE
    {
        //LANZAR UN RAYO DESDE EL PUNTO DE LANZAMIENTO
        if (Physics2D.Raycast(firePoint.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, transform.right);
            if ((_hit.transform.gameObject.layer == arrastableLayerNumber || grappleToAll) && ((Vector2.Distance(_hit.point, firePoint.position) <= maxDistance) || !hasMaxDistance))
            {
                print("bbbb");
                atraer = true;
                
                DistanceVector = (Vector2)point.transform.position - (Vector2)gunPivot.position;
                //grappleRope.enabled = true;
                //Instantiate(point,grapplePoint,Quaternion.identity);
                hitObj = _hit.transform.gameObject;
                //point.transform.position = grapplePoint;
                hitObj.transform.parent = point.transform;
                grapplePoint = _hit.point;

            }
            else if ((_hit.transform.gameObject.layer == grappableLayerNumber || grappleToAll) && ((Vector2.Distance(_hit.point, firePoint.position) <= maxDistance) || !hasMaxDistance))
            {
                print("aaa");
                //COMPROBAR SI EL OBJETO ES ENGANCHABLE Y SI ESTA DENTRO DE LA DISTANCIA MAXIMA
                grapplePoint = _hit.point;                                  //ESTABLECE EL PUNTO DE AGARRE
                DistanceVector = grapplePoint - (Vector2)gunPivot.position;    //CALCULA EL VECTOR DE DISTANCIA
                grappleRope.enabled = true;
            }

           
        }
    }

    //FUNCION QUE MANEJA LA LOGICA DE LANZAMIENTO Y ATRACCION
    public void Grapple()
    {
        //LOGICA DE LANZAMIENTO Y ATRACCION


        if (!launchToPoint && !autoCongifureDistance)
        {
            // Establece la distancia del resorte y la frecuencia según los valores de targetDistance y targetFrequency
            m_springJoint2D.distance = targetDistance;
            m_springJoint2D.frequency = targetFrequency;
        }

        if (!launchToPoint && !atraer)
        {
            
            if (autoCongifureDistance)
            {
                m_springJoint2D.autoConfigureDistance = true;  // Habilita la configuración automática de la distancia del resorte
                m_springJoint2D.frequency = 0;                 // Establece la frecuencia del resorte en 0 para evitar que oscile
            }
            m_springJoint2D.connectedAnchor = grapplePoint;    // Establecer el punto de anclaje conectado del resorte en el punto de agarre
            m_springJoint2D.enabled = true;                   // Habilitar el resorte para que se active y funcione

            //ATRACCION DE OBJETOS CERCANOS

            Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(grapplePoint, attractionRadius); // Detectar todos los colliders cercanos dentro del radio de atracción desde el punto de agarre
            foreach (Collider2D collider in nearbyColliders)  // Iterar a través de cada collider en la lista de colliders cercanos
            {
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 attracDirection = ((Vector2)gunPivot.position - rb.position).normalized;  // Calcular la dirección de atracción desde el pivote de la pistola hacia el objeto
                    rb.AddForce(attracDirection * attractionForce, ForceMode2D.Force);  // Aplicar una fuerza de atracción al objeto utilizando la dirección calculada y la fuerza de atracción configurada
                }
            }

            //AQUI DEBERIA DE SER LA ATRACCION HACIA EL JUGADOR
            Vector2 attractionDirection = ((Vector2)gunPivot.position - grapplePoint).normalized;
            ballRigidbody.AddForce(attractionDirection * attractionForce, ForceMode2D.Force);
        }

        else
        {
            if (Launch_Type == LaunchType.Transform_Launch && !atraer)
            {
                ballRigidbody.gravityScale = 0;
                ballRigidbody.velocity = Vector2.zero;
                print("Grapple");
            }
            if (Launch_Type == LaunchType.Physics_Launch && !atraer)
            {
                m_springJoint2D.connectedAnchor = grapplePoint;
                m_springJoint2D.distance = 0;
                m_springJoint2D.frequency = launchSpeed;
                m_springJoint2D.enabled = true;
                print("Grapple");
            }
           
        }
    }

    private void OnDrawGizmos()
    {
        if (hasMaxDistance)
        {
            //DIBUJA UNA ESFERA SI TIENE DISTANCIA MAX CONFIGURADA
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(firePoint.position, maxDistance);
        }
    }

}
