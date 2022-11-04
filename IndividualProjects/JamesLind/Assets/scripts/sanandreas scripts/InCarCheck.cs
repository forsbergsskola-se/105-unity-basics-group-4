using UnityEngine;

public class InCarCheck : MonoBehaviour
{
    public static bool closeenough(GameObject player, CarMovement carMovement)
    { 
        float dist = Vector3.Distance(player.transform.position, carMovement.transform.position);
        return dist < 5f;
    }
    public static bool NotInCar(GameObject player)
    {
        return player.activeInHierarchy;
    }
    public static void GetInLoser(GameObject player, CarMovement carMovement)
    {
        player.SetActive(false);
        carMovement.enabled = true;
    }

    public static void GetOutLoser(GameObject player, CarMovement carMovement)
    {
        player.SetActive(true);
        carMovement.enabled = false;
        player.transform.position = carMovement.transform.position;
        player.transform.Translate(0f, 0.8f, 0f);
    }
}