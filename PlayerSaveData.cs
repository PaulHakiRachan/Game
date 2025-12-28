using UnityEngine;


[System.Serializable] //แปลง Class นี้ให้เป็นข้อมูลที่บันทึกได้ (Serialize) และช่วยโชว์ในหน้า Inspector

public class PlayerSaveData
{
    [Header("Player Name")]
    public string playerName ;

    [Header("Time Played")]
    public float secondsPlayed;

    [Header("World Coordinates")]
    public float xPosition;
    public float yPosition;
    public float zPosition;

    [Header("Resorces")]
    public float currentHealth;
    public float currentStamina;
    
    [Header("Stats")]
    public float vitality;
    public float endurance;

    [Header("Bosses")]
    public SerializableDictionnary<int, bool> bossesAwake;
    public SerializableDictionnary<int, bool> bossesDefeat;

    public PlayerSaveData()
    {
        bossesAwake = new SerializableDictionnary<int, bool>();
        bossesDefeat = new SerializableDictionnary<int, bool>();
    }
}
