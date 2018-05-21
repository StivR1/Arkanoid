using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public int hitsToKill;
    public int points;
    private int numberOfHits;

    // используйте этот метод для инициализации
    void Start()
    {
        numberOfHits = 0;
    }

    // Update вызывается при отрисовке каждого кадра игры
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;

            if (numberOfHits == hitsToKill)
            {
                // уничтожаем объект
                Destroy(this.gameObject);
            }
        }
    }
}
