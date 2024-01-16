using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public List<GameObject> objectsToMove;
    public GameObject targetObject;
    public float moveSpeed = 5f;
    public float cooldownTime = 3f;

    public Sprite inactiveSprite;
    public Sprite activeSprite;
    public Image cooldownImage;

    private Image[] objectImages;
    private bool isCooldown = false;

    private void Start()
    {
        objectImages = new Image[objectsToMove.Count];
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            Image image = objectsToMove[i].GetComponent<Image>();
            if (image == null)
                image = objectsToMove[i].AddComponent<Image>();
            objectImages[i] = image;
        }

        cooldownImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isCooldown)
            return;

        /*if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartCooldown());
        }*/
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
        GetComponent<Image>().sprite = inactiveSprite;

        isCooldown = true;
        cooldownImage.gameObject.SetActive(true);

        foreach (Image image in objectImages)
        {
            image.sprite = inactiveSprite;
        }

        float timer = 0f;
        while (timer < cooldownTime)
        {
            cooldownImage.fillAmount = timer / cooldownTime;
            timer += Time.deltaTime;
            yield return null;
        }

        isCooldown = false;
        cooldownImage.gameObject.SetActive(false);

        foreach (Image image in objectImages)
        {
            if (image.sprite != inactiveSprite)
            {
                image.sprite = activeSprite;
            }
        }

        GetComponent<Image>().sprite = activeSprite;


    }
}