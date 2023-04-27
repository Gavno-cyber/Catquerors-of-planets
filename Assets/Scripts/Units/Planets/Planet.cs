using UnityEngine;

public abstract class Planet : Unit
{
    [SerializeField] protected int max_count;
    [SerializeField] protected int max_range;

    public int MaxSpawn { get => max_count; }
    public int MaxRange { get => max_range; }
}
