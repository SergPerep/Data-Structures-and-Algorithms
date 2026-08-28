using DsHash.Models;

(string, string)[] input = {
    ("Apple", "180 grams"),
    ("Banana", "120 grams"),
    ("Orange", "160 grams"),
    ("Mango", "200 grams"),
    ("Pear", "170 grams"),
    ("Peach", "150 grams"),
    ("Plum", "70 grams"),
    ("Grape", "5 grams"),
    ("Strawberry", "18 grams"),
    ("Blueberry", "2 grams"),
    ("Raspberry", "4 grams"),
    ("Cherry", "8 grams"),
    ("Watermelon", "3000 grams"),
    ("Pineapple", "900 grams"),
    ("Kiwi", "75 grams"),
    ("Papaya", "500 grams"),
    ("Guava", "100 grams"),
    ("Pomegranate", "280 grams"),
    ("Apricot", "45 grams"),
    ("Lemon", "80 grams"),
    ("Lime", "70 grams"),
    ("Coconut", "1400 grams"),
    ("Fig", "50 grams"),
    ("Grapefruit", "230 grams"),
    ("Tangerine", "90 grams"),
    ("Nectarine", "140 grams"),
    ("Cantaloupe", "1000 grams"),
    ("Blackberry", "5 grams"),
    ("Passion Fruit", "18 grams"),
    ("Dragon Fruit", "600 grams")
};

var hashList = new HashList();

// Add values
foreach(var (key, value) in input)
{
    hashList.Add(key, value);
}

// Get values
foreach(var (key, _) in input.Take(10))
{
    var retrievedValue = hashList.GetValue(key);
    Console.WriteLine($"Key: {key}, Value: {retrievedValue}");
}