// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day4.txt");

List<string[]> pairs = new();

foreach(string line in lines){
    string[] delimiters = {",","-"};
    string[] split = line.Split(delimiters,StringSplitOptions.None);
    pairs.Add(split);
}
//part 1
int sum = 0;
foreach(string[] pair in pairs){
    if(int.Parse(pair[0]) <= int.Parse(pair[2]) && int.Parse(pair[1]) >= int.Parse(pair[3])){
        sum++;
    }
    else if(int.Parse(pair[2]) <= int.Parse(pair[0]) && int.Parse(pair[3]) >= int.Parse(pair[1])){
        sum++;
    }
}
Console.WriteLine(sum);
//part 2
int sum2 = 0;
foreach(string[] pair in pairs){
    if((int.Parse(pair[2]) <= int.Parse(pair[0]) && int.Parse(pair[0]) <= int.Parse(pair[3])) || (int.Parse(pair[2]) <= int.Parse(pair[1]) && int.Parse(pair[1]) <= int.Parse(pair[3])))
    {
        sum2++;
    }
    else if((int.Parse(pair[0]) <= int.Parse(pair[2]) && int.Parse(pair[2]) <= int.Parse(pair[1])) || (int.Parse(pair[0]) <= int.Parse(pair[3]) && int.Parse(pair[3]) <= int.Parse(pair[1])))
    {
        sum2++;
    }
}
Console.WriteLine(sum2);
