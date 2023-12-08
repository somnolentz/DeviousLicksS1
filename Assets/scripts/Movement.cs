using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public Canvas canvas; // Reference to the Canvas
    public Image touchImage; // Reference to the Image element you want to enable/disable

    private RaycastHit hit;
    private Ray ray;

    public float dash;
    private Rigidbody rb;
    public float velocity = 5f;

    private bool isMovingPassively = false;
    private Vector3 passiveMovePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (touchImage == null )
        {
            return;
        }
        else
        {
            touchImage.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            HandleMobileInput();
        }
        else
        {
            HandleDesktopInput();
        }
    }

    private void HandleMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (isMovingPassively)
                {
                    isMovingPassively = false;
                }
                else
                {
                    isMovingPassively = true;
                    passiveMovePosition = touch.position;
                    SetImagePosition(passiveMovePosition);
                    touchImage.gameObject.SetActive(true); 
                }
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                passiveMovePosition = touch.position;
                SetImagePosition(passiveMovePosition);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isMovingPassively = false;
                touchImage.gameObject.SetActive(false);
            }
        }

        if (isMovingPassively)
        {
            MovePassively();
        }
        else
        {
            Dash();
        }
    }

    private void HandleDesktopInput()
    {
        Vector3 inputPosition = Input.mousePosition;

        ray = cam.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * dash);
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Dash();
        }
    }

    private void MovePassively()
    {
        ray = cam.ScreenPointToRay(passiveMovePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * velocity);
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void Dash()
    {
        float dashSpeed = dash * Time.deltaTime;
        rb.AddForce((transform.forward * 5) * dashSpeed, ForceMode.VelocityChange);
    }


    private void SetImagePosition(Vector3 position)
    {
        ray = cam.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hit))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                position,
                canvas.worldCamera,
                out Vector2 localPoint);

            touchImage.rectTransform.localPosition = localPoint;
        }
    }
}
