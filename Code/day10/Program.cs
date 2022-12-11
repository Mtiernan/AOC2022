// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day10.txt");

int cycle = 0; 
int x = 1;
int pc = 0;
int sum = 0;
int busy =0;
bool work = true;
List<int> pixels = new();
Dictionary<int,int> toAdd = new();

while(work){
    cycle++;
    if(x -1 <= (cycle%40)-1 && x + 1 >= (cycle%40)-1){
        Console.WriteLine($"x:{x} cycle:{cycle%40} {cycle}");
        pixels.Add(1);
    }
    else{
        pixels.Add(0);
    }
    if(busy == 0){
        switch(lines[pc].Split(' ')[0]){
            case "noop":
            break;
            case "addx":
                toAdd.Add(cycle+1,int.Parse(lines[pc].Split(' ')[1]));
                busy = 2;
            break;
        }
         pc++;
    }
    if(busy > 0){
        busy--;
    }

    if(pc >= lines.Count()){
       work = false;
    }

    if(cycle == 20 || cycle == 60 || cycle == 100 || cycle == 140 || cycle == 180 || cycle == 220){
        sum += (cycle * x);
    }
    if(toAdd.ContainsKey(cycle)){
        x += toAdd[cycle];
        toAdd.Remove(cycle);
    }

}
Console.WriteLine(cycle);
Console.WriteLine(sum);

string[] screen ={"","","","","",""}; 
for(int i =0; i < pixels.Count(); i++){
    screen[i/40] += pixels[i] == 1 ? "#" : ".";
}
foreach(string line in screen){
    Console.WriteLine(line);
}