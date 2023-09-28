using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    [SerializeField] GameObject fire;

    public void ActivateFlame()
    {
        fire.SetActive(true);
    }
}
