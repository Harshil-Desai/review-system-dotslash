using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Person : IComparable<Person>, ICloneable, INotifyPropertyChanged
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value != firstName)
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value != lastName)
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value != age)
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int CompareTo(Person other)
    {
        return Age.CompareTo(other.Age);
    }

    public object Clone()
    {
        return new Person { FirstName = FirstName, LastName = LastName, Age = Age };
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Age: {Age}";
    }
}

class PeopleCollection : IEnumerable<Person>, IDisposable, ICloneable, IComparable<PeopleCollection>, IComparer<PeopleCollection>, IList<Person>
{
    private List<Person> people = new List<Person>();

    public Person this[int index]
    {
        get => people[index];
        set => people[index] = value;
    }

    public int Count => people.Count;
    public bool IsReadOnly => false;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public IEnumerator<Person> GetEnumerator()
    {
        return people.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public object Clone()
    {
        PeopleCollection clone = new PeopleCollection();
        clone.people.AddRange(people.Select(p => (Person)p.Clone()));
        return clone;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Dispose managed resources
            people.Clear();
        }
        // Dispose unmanaged resources
    }

    public int CompareTo(PeopleCollection other)
    {
        return Count.CompareTo(other.Count);
    }

    public int Compare(PeopleCollection x, PeopleCollection y)
    {
        return x.Count.CompareTo(y.Count);
    }

    public int IndexOf(Person item)
    {
        return people.IndexOf(item);
    }

    public void Insert(int index, Person item)
    {
        people.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        people.RemoveAt(index);
    }

    public void Add(Person item)
    {
        people.Add(item);
    }

    public void Clear()
    {
        people.Clear();
    }

    public bool Contains(Person item)
    {
        return people.Contains(item);
    }

    public void CopyTo(Person[] array, int arrayIndex)
    {
        people.CopyTo(array, arrayIndex);
    }

    public bool Remove(Person item)
    {
        return people.Remove(item);
    }
}

interface ISerializer
{
    void Serialize(Stream serializationStream, object graph);
    object Deserialize(Stream serializationStream);
}

class BinaryFormatterSerializer : ISerializer
{
    private readonly IFormatter formatter;

    public BinaryFormatterSerializer()
    {
        formatter = new BinaryFormatter();
    }

    public void Serialize(Stream serializationStream, object graph)
    {
        formatter.Serialize(serializationStream, graph);
    }

    public object Deserialize(Stream serializationStream)
    {
        return formatter.Deserialize(serializationStream);
    }
}

class Program
{
    static void Main()
    {
        PeopleCollection peopleCollection = new PeopleCollection();

        // Event handler for property changes in Person objects
        peopleCollection.PropertyChanged += PeopleCollection_PropertyChanged;

        // Add people to PeopleCollection
        Person john = new Person { FirstName = "John", LastName = "Doe", Age = 30 };
        peopleCollection.Add(john);

        // Change a property to trigger the PropertyChanged event
        john.Age = 31;

        // Display people in PeopleCollection
        Console.WriteLine("People in PeopleCollection:");
        foreach (Person person in peopleCollection)
        {
            Console.WriteLine(person);
        }

        // Cloning
        PeopleCollection clonedCollection = (PeopleCollection)peopleCollection.Clone();
        Console.WriteLine("\nCloned PeopleCollection:");
        foreach (Person person in clonedCollection)
        {
            Console.WriteLine(person);
        }

        // Disposing
        peopleCollection.Dispose();

        // Serialization example
        ISerializer serializer = new BinaryFormatterSerializer();
        using (FileStream fileStream = new FileStream("data.dat", FileMode.Create))
        {
            serializer.Serialize(fileStream, peopleCollection);
        }

        // Deserialization example
        using (FileStream fileStream = new FileStream("data.dat", FileMode.Open))
        {
            PeopleCollection deserializedCollection = (PeopleCollection)serializer.Deserialize(fileStream);

            Console.WriteLine("\nDeserialized PeopleCollection:");
            foreach (Person person in deserializedCollection)
            {
                Console.WriteLine(person);
            }
        }
    }

    private static void PeopleCollection_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Console.WriteLine($"Property changed: {e.PropertyName}");
    }
}
