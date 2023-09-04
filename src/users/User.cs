public class User
{
    public long id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }

    public override string ToString()
    {
        return $"id: {id} | name: {Name} | surname: {Surname} | username: {UserName}";
    }
}