using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";

    [SerializeField] private string interacrtionParameterName = "@Interaction";
    [SerializeField] private string buildingParameterName = "Building";

    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int InteracrtionParameterHash { get; private set; }
    public int BuildingParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);

        InteracrtionParameterHash = Animator.StringToHash(interacrtionParameterName);
        BuildingParameterHash = Animator.StringToHash(buildingParameterName);
    }
}
