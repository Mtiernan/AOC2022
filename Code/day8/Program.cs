// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day8.txt");

int sum = 0;
for(int y =0; y < lines.Length; y++){
    for(int x = 0; x < lines[y].Length; x++){
        //down
        if(checkForEdge(x,y,lines,false,false)){
            sum++;
            continue;
        }
        //up
        else if(checkForEdge(x,y,lines,false,true)){
            sum++;
            continue;
        }
        //left
        else if(checkForEdge(x,y,lines,true,true)){
            sum++;
            continue;
        }
        //right
        else if(checkForEdge(x,y,lines,true,false)){
            sum++;
            continue;
        }
        
    }
}
int highest = 0;
for(int y =0; y < lines.Length; y++){
    for(int x = 0; x < lines[y].Length; x++){
        if(x == 0 || y == 0 || x == lines[0].Length-1 || y == lines.Length -1){
            continue;
        }
        int nextValue = sceneValue(x,y,lines);
        if(nextValue > highest)
            highest = nextValue;
    }
}
int sceneValue(int x, int y, string[] grid){
    int up = 0,down =0, left =0 ,right =0;
    //up
    for(int i = y -1; i >=0; i--){
        up++;
        if(char.GetNumericValue(grid[x][i]) >= char.GetNumericValue(grid[x][y])){
            break;
        }
        else 
            continue;
   }
   //down
    for(int i = y + 1; i < grid.Length; i++){
        down++; 
        if(char.GetNumericValue(grid[x][i]) >= char.GetNumericValue(grid[x][y])){
            break;
        }
        else 
            continue;
   }
   //left
    for(int i = x - 1; i >=0; i--){
        left++; 
        if(char.GetNumericValue(grid[i][y]) >= char.GetNumericValue(grid[x][y])){
            break;
        }
        else 
            continue;
   }

   //right
    for(int i = x + 1; i < grid[y].Length; i++){
        right++; 
        if(char.GetNumericValue(grid[i][y]) >= char.GetNumericValue(grid[x][y])){
            break;
        }
        else 
            continue;
   }
    return (up * left * right * down);
}
bool checkForEdge(int x,int y, string[] grid, bool horiz,bool decrease){
    if(x == 0 || y == 0 || y == grid.Length - 1 || x == grid[y].Length -1) 
    {
        return true;
    }
    else{
        if(decrease){
            for(int i = (horiz ? x : y) - 1; i >= 0; i--){
                if(char.GetNumericValue((horiz ? grid[i][y] : grid[x][i])) >= char.GetNumericValue(grid[x][y])){
                    return false;
                }
            }
        
            return true; 
        }
        else{
            for(int i = (horiz ? x : y) + 1; i <= (horiz ? grid[y].Length - 1 : grid.Length -1); i++){
                if(char.GetNumericValue((horiz ? grid[i][y] : grid[x][i])) >= char.GetNumericValue(grid[x][y])){
                    return false;
                }
            }
        
            return true; 
        }
    }
}
Console.WriteLine(sum);
Console.WriteLine(highest);

