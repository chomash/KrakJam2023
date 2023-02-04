using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Avatars")]
public class AvatarList : ScriptableObject
{
    public AvatarEntry[] avatarList;
}

[System.Serializable]
public class AvatarEntry
{
    public string avatarName;
    public Sprite avatarImage;
}
