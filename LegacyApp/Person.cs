namespace LegacyApp;

public abstract class Person
{
    public string Name { get; internal set; }
    public string Email { get; internal set; }
    
    public Person(string name, string email)
    {
        Name = name;
        Email = email;
    }
}