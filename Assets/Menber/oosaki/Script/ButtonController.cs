using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public List<GameObject> objectsToMove;
    public GameObject targetObject;
    public float moveSpeed = 5f;
    public float cooldownTime = 2f;

    public Image buttonImage;
    public Sprite inactiveSprite;
    public Sprite activeSprite;

    private bool isCooldown = false;

    private void Start()
    {
        if (buttonImage == null)
            buttonImage = GetComponent<Image>();
        buttonImage.sprite = activeSprite;
    }

    private void Update()
    {
        if (isCooldown)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject obj in objectsToMove)
            {
                StartCoroutine(MoveObject(obj));
            }
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator MoveObject(GameObject obj)
    {
        while (Vector3.Distance(obj.transform.position, targetObject.transform.position) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetObject.transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        buttonImage.sprite = inactiveSprite;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
        buttonImage.sprite = activeSprite;
    }
}
