namespace DsHash.Models;

public class HashList
{
    private static int _initialArraySize = 8;
    private static int _resizeFactor = 2;
    private static double _maxLoadFactor = 0.75;
    private int _itemCount = 0;

    private List<(string, string)>[] _innerArray = new List<(string, string)>[_initialArraySize];

    public void Add(string key, string value)
    {
        // Add item
        var index = calcIndex(key, _innerArray.Length);

        if (_innerArray[index] == null)
        {
            _innerArray[index] = new List<(string, string)>();
        }

        _innerArray[index].Add((key, value));
        _itemCount++;

        Console.WriteLine($"Added key {key} at index {index}. Item count: {_itemCount}. Array size: {_innerArray.Length}");

        // Resize if load factor is too high
        var loadFactor = calcLoadFactor(_itemCount, _innerArray.Length);
        if (loadFactor > _maxLoadFactor)
            ResizeArray();
    }

    public string? GetValue(string key)
    {
        var index = calcIndex(key, _innerArray.Length);
        var lst = _innerArray[index];

        if (lst == null)
        {
            throw new Exception($"Key {key} not found");
        }

        foreach (var (k, v) in lst)
        {
            if (k == key) return v;
        }

        throw new Exception($"Key {key} not found");
    }

    public void Remove(string key)
    {
        var index = calcIndex(key, _innerArray.Length);
        var lst = _innerArray[index];

        if (lst == null)
        {
            throw new Exception($"Key {key} not found");
        }

        foreach (var (k, v) in lst)
        {
            if (k == key)
            {
                lst.Remove((k, v));
                _itemCount--;
                Console.WriteLine($"Removed key {key} at index {index}. Item count: {_itemCount}. Array size: {_innerArray.Length}");
                return;
            }
        }

        throw new Exception($"Key {key} not found");
    }

    public bool Contains(string key)
    {
        var index = calcIndex(key, _innerArray.Length);
        var lst = _innerArray[index];
        if (lst == null)
        {
            Console.WriteLine($"Key {key} not found");
            return false;
        }

        foreach (var (k, v) in lst)
        {
            if (k == key)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Converts a key to an index
    /// </summary>
    private static int calcIndex(string key, int arrayLength)
    {
        var hash = Hash(key);
        return (int)(hash % arrayLength);
    }

    /// <summary>
    /// Converts a string to a numeric hash
    /// </summary>
    static uint Hash(string text)
    {
        uint hash = 2166136261;

        foreach (char c in text)
        {
            hash ^= c;
            hash *= 16777619;
        }

        return hash;
    }

    private static double calcLoadFactor(int itemCount, int arraySize)
    {
        return (double)itemCount / arraySize;
    }

    private void ResizeArray()
    {
        var targetSize = _innerArray.Length * _resizeFactor;
        var targetArray = new List<(string, string)>[targetSize];
        foreach (var lst in _innerArray)
        {
            if (lst == null) continue;
            foreach (var (key, value) in lst)
            {
                var index = calcIndex(key, targetSize);
                var targetList = targetArray[index];
                if (targetList == null)
                {
                    targetList = new List<(string, string)>();
                    targetArray[index] = targetList;
                }

                targetList.Add((key, value));
            }
        }
        Console.WriteLine($"Resized array {_innerArray.Length} --> {targetSize}");
        _innerArray = targetArray;
    }
}