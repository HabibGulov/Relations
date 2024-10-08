using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Passport? Passport{get; set;}
}

public class Passport
{
    public int Id { get; set; }
    public string PassportNumber { get; set; }=null!;

    public int PersonId{get; set;}
    public Person Person{get; set;}=null!;
}