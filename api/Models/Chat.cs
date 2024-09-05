namespace api.Models;

public class Chat
{
    private string ID { get; set; }
    private string Name { get; set; }
    private string[] UserList { get; set; }
    private string[] AdminList { get; set; }
}