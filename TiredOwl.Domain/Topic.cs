namespace TiredOwl.Domain;

public class Topic : EnumerableValueObject
{
    public Topic(int value, string name) : base(value, name) { }
    public static Topic Shopping = new Topic(1, "Shopping");
    public static Topic Cloths = new Topic(2, "Cloths");
}