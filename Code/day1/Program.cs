// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day1.txt");
int elfNum = 0;
List<List<int>> elfInventory = new();
elfInventory.Add( new List<int>());
Console.WriteLine("hello");
foreach(string line in lines){
    if(line == ""){
        elfNum++;
        elfInventory.Add(new List<int>());
    }
    else{
        elfInventory[elfNum].Add(Int32.Parse(line));
    }
}
List<int> summedList = elfInventory.Select(x => x.Sum()).ToList();
Console.WriteLine(summedList.Max());

summedList = summedList.OrderByDescending(x => x).ToList();
Console.WriteLine(summedList[0]);
int sum = summedList[0] + summedList[1] + summedList[2];
Console.WriteLine(sum);
