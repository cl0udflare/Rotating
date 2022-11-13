using UnityEngine;

public class PassingGrate : MonoBehaviour
{
    [SerializeField] private GrateLine[] _grateLines;
    [SerializeField] private ScoreManager _scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var grateLine in _grateLines)
            grateLine.PlayParticles();
    }

    private void OnTriggerExit(Collider other)
    {
        if (GrateCubesForce.IsClearPass)
            _scoreManager.Multiplicator += 1;
        
        GrateCubesForce.IsClearPass = true;
    }
}