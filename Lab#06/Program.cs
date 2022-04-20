string[] arr = { "dd", "aa","ss","aa", "dd","r","aa" };
Dictionary<string, int> dict = new Dictionary<string, int>();
foreach (string s in arr)
{
    if (dict.ContainsKey(s))
    {
        dict[s]++;
    }
    else
    {
        dict.Add(s, 1);
    }
}
foreach (var item in dict){
    Console.WriteLine(item.Key + " " + item.Value);
}

int[] set1 = { 2, 33, 6, 6, 1, 7, 8, 9, 10};
int[] set2 = {3, 6, 8, 9, 11, 2, 1, 78 };

HashSet<int> set3 = new HashSet<int>(set1);
HashSet<int> set4 = new HashSet<int>(set2);
set3.IntersectWith(set4);

foreach (int i in set3)
{
    Console.Write(i + " ");
}
