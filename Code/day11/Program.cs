// See https://aka.ms/new-console-template for more information
using Monk;
string[] data = System.IO.File.ReadAllText("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day11.txt").Split("\n\r");
List<Monkey> Monks = new();
int mod = 1;
foreach(string monkey in data){
    string[] lines = monkey.Split("\r\n");
    Monkey monk = new();
    //starting items
    List<Int128> start = new();
    foreach(string item in lines[1].Split(": ")[1].Split(", ")){
        start.Add(int.Parse(item));
    }
    monk.startingItems = start;
    monk.worryOp =lines[2].Split("= ")[1];
    monk.test = int.Parse(lines[3].Split("by ")[1]);
    monk.trueMonkey = int.Parse(lines[4].Split("monkey ")[1]);
    monk.falseMonkey = int.Parse(lines[5].Split("monkey ")[1].Trim());
    Monks.Add(monk);
    mod *= monk.test;
}   
for(int i =0; i < 10000; i++){
    foreach(Monkey monkey in Monks){    
        for(int k = 0; k < monkey.startingItems.Count(); k++){
            monkey.totalItems++;
            monkey.startingItems[k] = monkey.inspectWorry(monkey.startingItems[k]);
            // monkey.startingItems[k] = monkey.startingItems[k]/3;
            monkey.startingItems[k] = monkey.startingItems[k]%mod;
            bool test = monkey.startingItems[k]%monkey.test == 0;
            if(test){
                Monks[monkey.trueMonkey].startingItems.Add(monkey.startingItems[k]);
            }
            else{
                Monks[monkey.falseMonkey].startingItems.Add(monkey.startingItems[k]);
            }
        }
        monkey.startingItems = new();
    }
}

Monks = Monks.OrderByDescending(x=> x.totalItems).ToList();
Console.WriteLine(Monks[0].totalItems * Monks[1].totalItems);

namespace Monk{
    class Monkey{
        public long totalItems {get;set;} = 0;
        public List<Int128>? startingItems {get;set;}
        public int test {get;set;} 
        public string? worryOp {get;set;}
        public int trueMonkey {get;set;}
        public int falseMonkey {get;set;}
        public Int128 inspectWorry(Int128 item){
            string[] op = worryOp.Split(" ");
            Int128 newWorry = 0;
            switch(op[1]){
                case "+":
                    newWorry = (op[0] == "old" ? item : Int128.Parse(op[0])) + (op[2] == "old" ? item : Int128.Parse(op[2]));
                break;
                case"*":
                    newWorry = (op[0] == "old" ? item : Int128.Parse(op[0])) * (op[2] == "old" ? item : Int128.Parse(op[2]));
                break;
            }
            return newWorry;
        }
    }
}


