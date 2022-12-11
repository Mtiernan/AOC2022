// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day9.txt");

int[] head = {0,0};
int[] tail = {0,0};

List<int[]> path = new();
path.Add(tail);
//part one
foreach(string line in lines){
    switch(line.Split(' ')[0]){
        case "U":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                head[1]--;
                tail = followHead(head,tail);
                if(!path.Exists(x => (x[0] == tail[0]  && x[1] == tail[1])))
                    path.Add(tail);
            }
            break;
        case "D":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                head[1]++;
                tail = followHead(head,tail);
                if(!path.Exists(x => (x[0] == tail[0]  && x[1] == tail[1])))
                    path.Add(tail);
            }
            break;
        case "R":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                head[0]++;
                tail = followHead(head,tail);
                if(!path.Exists(x => (x[0] == tail[0]  && x[1] == tail[1])))
                    path.Add(tail);
            }
            break;
        case "L":
         for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
            head[0]--;
            tail = followHead(head,tail);
            if(!path.Exists(x => (x[0] == tail[0]  && x[1] == tail[1])))
                  path.Add(tail);
        }
        break;
    }
}
//part 2
List<int[]> knots = new List<int[]>();
for(int i =0; i < 10; i++){
    knots.Add(new int[] {0,0});
}

List<int[]> path2 = new();
foreach(string line in lines){
    switch(line.Split(' ')[0]){
        case "U":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                knots[0][1]--;
                for(int k=1; k< knots.Count; k++){
                    knots[k] = followHead(knots[k-1],knots[k]);
                }
                if(!path2.Exists(x => (x[0] == knots[9][0]  && x[1] == knots[9][1])))
                    path2.Add(knots[9]);
            }
            break;
        case "D":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                knots[0][1]++;
                 for(int k=1; k < knots.Count; k++){
                    knots[k] = followHead(knots[k-1],knots[k]);
                }
                if(!path2.Exists(x => (x[0] == knots[9][0]  && x[1] == knots[9][1])))
                    path2.Add(knots[9]);
            }
            break;
        case "R":
            for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
                knots[0][0]++;
                for(int k=1; k < knots.Count; k++){
                knots[k] = followHead(knots[k-1],knots[k]);
            }
                if(!path2.Exists(x => (x[0] == knots[9][0]  && x[1] == knots[9][1])))
                    path2.Add(knots[9]);
            }
            break;
        case "L":
         for(int i = 0; i < int.Parse(line.Split(' ')[1]); i++){
            knots[0][0]--;
            for(int k=1; k < knots.Count; k++){
                knots[k] = followHead(knots[k-1],knots[k]);
            }
            if(!path2.Exists(x => (x[0] == knots[9][0]  && x[1] == knots[9][1])))
                  path2.Add(knots[9]);
        }
        break;
    }
}

int[] followHead(int[]h,int[]t){
    int[] newTail = {t[0],t[1]};
    if(Math.Abs(h[0] - t[0]) > 1 || Math.Abs((h[1] - t[1])) > 1){
        //if x position is the same then we know we need to move up or down
        if(h[0] == t[0]){
            //up
            if(t[1] > h[1]){
                newTail[1]--;
            }
            //down
            else{
                newTail[1]++;
            }
        }
        else if(h[1] == t[1]){
            //left
            if(t[0] > h[0]){
                newTail[0]--;
            }
            //right
            else{
                newTail[0]++;
            }
        }
        else{
            //up-left
            if(t[0] > h[0] && t[1] > h[1]){
                newTail[0]--;
                newTail[1]--;
            }
            //up-right
            if(t[0] < h[0] && t[1] > h[1]){
                newTail[0]++;
                newTail[1]--;
            }
            //down-left
            if(t[0] > h[0] && t[1] < h[1]){
                newTail[0]--;
                newTail[1]++;
            }
              //down-right
            if(t[0] < h[0] && t[1] < h[1]){
                newTail[0]++;
                newTail[1]++;
            }
        }
    }
    return newTail;
}

Console.WriteLine(path.Count);
Console.WriteLine(path2.Count);
// foreach(int[] point in path){
//     Console.WriteLine($"x: {point[0]} y: {point[1]}");
// }

