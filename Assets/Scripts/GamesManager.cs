using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class GamesManager : MonoBehaviour
{
    public List<string> levels;
    private FMOD.Studio.EventInstance _menuSnapshot;
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
         _menuSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Menu");
    }

    public void StartSnapShot()
    {
        _menuSnapshot.stop(STOP_MODE.IMMEDIATE);
        foreach (var snapshot in snapshots)
        {
            snapshot.stop(STOP_MODE.IMMEDIATE);
        }
        snapshots[currentLevel].start();
    }

    public void StopAllSnapShots()
    {
        foreach (var snapshot in snapshots)
        {
            snapshot.stop(STOP_MODE.IMMEDIATE);
        }
    }

    public void StopMenuSnapshot()
    {
        _menuSnapshot.stop(STOP_MODE.IMMEDIATE);
    }

    public void StartMenuSnapshot()
    {
        _menuSnapshot.start();
    }
}
