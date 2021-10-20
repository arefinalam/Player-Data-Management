using System;
using System.Collections.Generic;

[Serializable]
public class Players
{
    public List<Player> players { get; set; }
}
[Serializable]
public class Player
{
    public string name { get; set; }
    public int age { get; set; }
    public string type { get; set; }
}
