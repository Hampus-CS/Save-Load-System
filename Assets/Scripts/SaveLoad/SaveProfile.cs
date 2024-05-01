using UnityEngine;

[System.Serializable]
public sealed class SaveProfile<T> where T : SaveProfileData
{
    public string profileName;
    public T saveData;

    private SaveProfile() { }

    public SaveProfile(string profileName, T saveData)
    {
        this.profileName = profileName;
        this.saveData = saveData;
    }


}

public abstract record SaveProfileData { }

public record PlayerSaveData : SaveProfileData
{

    public Vector3 position;
    
}

public record WorldSaveData : SaveProfileData
{
    
}