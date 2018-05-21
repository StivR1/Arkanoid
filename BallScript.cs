using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private new Rigidbody rigidbody2D;
    private bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;

    // GameObject
    public GameObject playerObject;

    // используйте этот метод для инициализации
    void Start()
    {
        // создаем силу
        ballInitialForce = new Vector2(100.0f, 300.0f);

        // переводим в неактивное состояние
        ballIsActive = false;

        // запоминаем положение
        ballPosition = transform.position;
    }

    void Update()
    {
        // проверка нажатия на пробел
        if (Input.GetButtonDown("Jump") == true)
        {
            // проверка состояния
            if (!ballIsActive)
            {
                // сброс всех сил
                rigidbody2D.isKinematic = false;
                // применим силу
                rigidbody2D.AddForce(ballInitialForce);
                // зададим активное состояние
                ballIsActive = !ballIsActive;
            }

            if (!ballIsActive && playerObject != null)
            {
                // задаем новую позицию шарика
                ballPosition.x = playerObject.transform.position.x;

                // устанавливаем позицию шара
                transform.position = ballPosition;
            }

            // проверка падения шара
            if (ballIsActive && transform.position.y < -6)
            {
                ballIsActive = !ballIsActive;
                ballPosition.x = playerObject.transform.position.x;
                ballPosition.y = -4.2f;
                transform.position = ballPosition;

                rigidbody2D.isKinematic = true;
            }
        }
    }
}