using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    private bool isMoving;
    private GameObject hero;
    private PhotonView view;
    private float timeToMove = 2f;

    void Start()
    {
        hero = GameObject.Find($"/{StateNameController.characterName}");
        view = hero.GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine && Input.GetMouseButtonDown(0) && !isMoving) {
            StartCoroutine(MovePlayer());
        }
    }

    private IEnumerator MovePlayer()
    {
        isMoving = true;

        float elapsedTime = 0;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            while(elapsedTime < timeToMove)
            {
                Transform destination = hit.transform;
                hero.transform.position = Vector3.Lerp(hero.transform.position, new Vector3(destination.position.x, 0.5f, destination.position.z), (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        isMoving = false;
    }
}
