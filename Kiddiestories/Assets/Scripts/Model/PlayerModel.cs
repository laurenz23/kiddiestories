using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerModel
{

    public string uuid;
    public string email;
    public string firstName;
    public string lastName;

    public PlayerModel() { }

    public PlayerModel(string uuid, string email, string firstName, string lastName)
    {
        this.uuid = uuid;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

}
