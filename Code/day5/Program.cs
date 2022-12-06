// dear god what have i done
using System.Text.RegularExpressions;

string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day5.txt");

List<List<string>> moves = new();
for(int i =0; i < lines.Length; i++){
    List<string> line = new();
    foreach(var match in Regex.Matches(lines[i],@"\d+")){
        line.Add(match.ToString());
    };
    moves.Add(line);
}

//populate boxes sample
List<List<char>> boxes = new();
boxes.Add(new List<char>{'S','L','W'});
boxes.Add(new List<char>{'J','T','N','Q'});
boxes.Add(new List<char>{'S','C','H','F','J'});
boxes.Add(new List<char>{'T','R','M','W','N','G','B'});
boxes.Add(new List<char>{'T','R','L','S','D','H','Q','B'});
boxes.Add(new List<char>{'M','J','B','V','F','H','R','L'});
boxes.Add(new List<char>{'D','W','R','N','J','M'});
boxes.Add(new List<char>{'B','Z','T','F','H','N','D','J'});
boxes.Add(new List<char>{'H','L','Q','N','B','F','T'});

//part 1
// foreach(List<string> move in moves){
//     for(int i =0; i < int.Parse(move[0]); i++) {
//         boxes[int.Parse(move[2]) - 1].Add(boxes[int.Parse(move[1])- 1][boxes[int.Parse(move[1])- 1].Count - 1]);
//         boxes[int.Parse(move[1]) - 1 ].RemoveAt(boxes[int.Parse(move[1]) - 1].Count -1);
//     }
// }

foreach(List<string> move in moves){
    boxes[int.Parse(move[2]) - 1].AddRange(boxes[int.Parse(move[1]) - 1].GetRange(boxes[int.Parse(move[1]) - 1].Count -int.Parse(move[0]),int.Parse(move[0])));
    boxes[int.Parse(move[1]) - 1].RemoveRange(boxes[int.Parse(move[1]) - 1].Count -int.Parse(move[0]),int.Parse(move[0]));
}
string answer = "";
foreach(List<char> box in boxes){
    answer += box[box.Count -1];
}
Console.WriteLine(answer);