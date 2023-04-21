using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaroqueTower : MonoBehaviour
{
    [SerializeField] BaroqueTowerSegment towerSegmentPrefab;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] int basePointRequirement = 60;

    List<BaroqueTowerSegment> towerSegments;
    BaroqueTowerSegment topSegment;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnPointsUpdate.AddListener(OnPointsUpdate);
        towerSegments = new List<BaroqueTowerSegment>();
        topSegment = Instantiate(towerSegmentPrefab, transform);
        towerSegments.Add(topSegment);
        topSegment.rotationSpeed = GetRotationSpeedForLevel();

        OnPointsUpdate(GameManager.instance.Points);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewSegment();
        }
    }

    void SpawnNewSegment()
    {
        topSegment = Instantiate(towerSegmentPrefab, topSegment.Slot, Quaternion.identity, transform);
        towerSegments.Add(topSegment);
        topSegment.rotationSpeed = GetRotationSpeedForLevel();
    }
    void OnPointsUpdate(int points)
    {
        if (points >= GetPointsRequiedForNextLevel())
        {
            SpawnNewSegment();
        }

        ScoreText.text = points + "/" + GetPointsRequiedForNextLevel(); ;
    }

    int  GetPointsRequiedForNextLevel()
    {
        return (int)Mathf.Pow(2, towerSegments.Count - 1) * basePointRequirement;
    }

    float GetRotationSpeedForLevel()
    {
        return 10 * Mathf.Sign(Random.Range(-1, 1)) * towerSegments.Count + 1;
    }
}