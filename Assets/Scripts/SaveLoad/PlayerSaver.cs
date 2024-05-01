using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    [SerializeField]
    private bool saveAs2D = false;  // Toggle this in the Inspector to switch between 2D and 3D saving.

    public void SavePlayerPosition(int saveSlot)
    {
        if (saveSlot < 1 || saveSlot > 3)
        {
            Debug.LogError("Invalid save slot selected. Please select a slot.");
            return;
        }

        string profileName = $"PlayerSaveData_Slot{saveSlot}";
        Vector3 position = transform.position;
        Vector3 savePosition = saveAs2D ? new Vector3(position.x, position.y, 0) : position;  // Use only x, y if saving as 2D.

        var playerSave = new PlayerSaveData {position = savePosition};
        var saveProfile = new SaveProfile<PlayerSaveData>(profileName, playerSave);
        SaveManager.Save(saveProfile);
    }

    void Start()
    {
        Debug.Log(Application.persistentDataPath);

        Vector3 startPosition = saveAs2D ? new Vector3(5f, 5f, 0) : Vector3.one * 5f;
        var playerSave = new PlayerSaveData {position = startPosition};
        var saveProfile = new SaveProfile<PlayerSaveData>("PlayerSaveData", playerSave);
        SaveManager.Save(saveProfile);
    }
}