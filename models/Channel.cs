﻿namespace BackendChatRoom.models;

public class Channel{
    
    
    public int channelId{ get; set; }
    public string Name{ get; set; }
    public string? Description{ get; set; }
    
    public List<Message> Messages{ get; set; }
}