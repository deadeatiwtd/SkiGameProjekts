using UnityEngine;

public class FinishGate : MonoBehaviour
{
    public static event GameManager.TimeEvent FinishRace;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            FinishRace.Invoke();
        }
    }
}
