// See https://aka.ms/new-console-template for more information
string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day2.txt");

List<char[]> guide = new();
foreach(string line in lines){
    char[] outcome = new char[2];
    char opponent = line.Split(' ')[0][0];
    char me = line.Split(' ')[1][0];
    guide.Add(new char[]{opponent,me});
}

//part 1
int sum = 0;
foreach(char[] moves in guide){
    switch(moves[1]){
        case 'X':
            sum +=1;
            if(moves[0] == 'A'){
                sum +=3;
            }
            else if(moves[0] == 'C'){
                sum +=6;
            }
            break;
        case 'Y':            
            sum +=2;
            if(moves[0] =='B')
            {
                sum +=3;
            }
            else if(moves[0] == 'A')
            {
                sum +=6;
            }
            break;
        case 'Z':             
            sum +=3;
            if(moves[0] == 'C')
            {
                sum +=3;
            }
            else if(moves[0] =='B'){
                sum +=6;
            }
            break;
    }
}
Console.WriteLine(sum);

//part 2

int sum2 = 0; 
foreach(char[] moves in guide){
    switch(moves[1]){
        case 'X':
            sum2 +=0;
            switch(moves[0]){
                case 'A': sum2+=3; break;
                case 'B': sum2+=1; break;
                case 'C': sum2+=2; break;
            }
            break;
        case 'Y':            
            sum2 +=3;
             switch(moves[0]){
                case 'A': sum2+=1; break;
                case 'B': sum2+=2; break;
                case 'C': sum2+=3; break;
            }
            break;
        case 'Z':             
            sum2 +=6;
             switch(moves[0]){
                case 'A': sum2+=2; break;
                case 'B': sum2+=3; break;
                case 'C': sum2+=1; break;
            }
            break;
    }

}
Console.WriteLine(sum2);
