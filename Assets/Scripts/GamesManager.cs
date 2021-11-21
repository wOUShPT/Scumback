using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class GamesManager : MonoBehaviour
{
    public List<string> levels;
    public List<FMOD.Studio.EventInstance> snapshots;
    public int currentLevel;
    void Awake()
    {
        currentLevel = 0;
        levels = new List<string>();
         levels.Add("Boat");
         levels.Add("Boomerang");
         levels.Add("KinecticRage");
         snapshots = new List<EventInstance>(levels.Count);
         snapshots.Add(FMODUnity.RuntimeManager.CreateInstance("snapshot:/Jogo do barco"));
         snapshots.Add(FMODUnity.RuntimeManager.CreateInstance("snapshot:/Jogo do bumerangue"));
         snapshots.Add(FMODUnity.RuntimeManager.CreateInstance("snapshot:/Jogo da porrada"));
    }
}
