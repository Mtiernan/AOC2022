// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day3.txt");
Dictionary<char,int> values =  new Dictionary<char, int>(){{'A',1},{'B',2}};
List<string[]> sacks = new();
foreach(string line in lines){
    string compartOne = line.Substring(0,(line.Length/2));
    string compartTwo = line.Substring(line.Length/2, line.Length/2);
    string[] sack = {compartOne,compartTwo};
    sacks.Add(sack);
}
int sum = 0; 

//part 1
foreach(string[]sack in sacks){
    char shared = FindMatching(sack[0],sack[1]);
    if(char.IsUpper(shared)){
        sum += shared - 38;
    }
    else{
        sum += shared -96;
    }
}
Console.WriteLine(sum);
//part 2
int sum2 =0;
for(int i = 0; i < lines.Count() -1; i+=3){
    string one = lines[i];
    string two = lines[i+1];
    string three = lines[i+2];

    char shared = FindMatchingThree(one,two,three);
    if(char.IsUpper(shared)){
        sum2 += shared - 38;
    }
    else{
        sum2 += shared -96;
    }

}
Console.WriteLine(sum2);

char FindMatching(string itemOne,string itemTwo){
    foreach(char item in itemOne){
       if(itemTwo.Contains(item)){
        return item;
       }
    }
    return '0';
}
char FindMatchingThree(string one, string two, string three){
    List<char> matches = new();
    foreach(char item in one){
        if(two.Contains(item)){
            matches.Add(item);
       }
    }
    foreach(char match in matches){
        if(three.Contains(match)){
            return match;
        }
    }
    return '0';
}