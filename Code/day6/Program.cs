// See https://aka.ms/new-console-template for more information

string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day6.txt");
Queue<char> queue = new();

int pos = 0;
bool found =false;
while(!found){
    queue.Enqueue(lines[0][pos]);
    if(queue.Count >= 14){
        found = queue.Count == String.Join("",queue).Distinct().Count();
        queue.Dequeue();
    }
    pos++;
}
Console.WriteLine(pos);