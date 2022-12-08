internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("E:\\Stuff\\CSprojects\\Advent\\Advent2022\\Data\\day7.txt");

        Node head = new();
        Node cur = head;
        foreach (string line in lines)
        {
            string[] command = line.Split(' ');
            switch(command[1]){
                case "cd":
                    if(command [2] =="/"){
                        cur.name = "root";
                        cur.size = 0;
                        cur.contents = new();
                    }
                    else if(command[2] == ".."){
                        cur = cur.prev;
                    }
                    else{
                        cur = cur.contents.Where(x => x.name == command[2]).First();
                    }
                    break;
                case "ls":
                    break;
                default:
                    if(command[0] == "dir"){
                        Node dir = new();
                        dir.prev = cur;
                        dir.contents = new();
                        dir.size = 0;
                        dir.name = command[1];
                        cur.contents.Add(dir);
                    }
                    else{
                        Node item = new();
                        item.prev = cur;
                        item.contents = null;
                        item.size = int.Parse(command[0]);
                        item.name = command[1];
                        cur.contents.Add(item);
                    }
                    break;
            }
    
        }
        head.size = CalaculateDirSize(head);
        Console.WriteLine(partOneSize(head));

        List<Node> nodeList = partTwoList(head,30000000 -(70000000 - head.size));
        Console.WriteLine(nodeList.Select(x => x.size).ToArray().Min());


        int CalaculateDirSize(Node node){
            int size = 0;
            foreach(Node child in node.contents){
                if(child.size == 0){
                    child.size =CalaculateDirSize(child);
                    size += child.size;
                }
                else{
                    size += child.size;
                }
            }
            return size;
        }

        int partOneSize(Node node){
            int total = 0;
            foreach(Node child in node.contents){
                if(child.contents != null){
                    if(child.size <= 100000)
                    {
                        total += child.size;
                    }
                    total += partOneSize(child);
                }
            }
            return total;
        }
        List<Node> partTwoList(Node node,int spaceNeeded){
            List<Node> canDelete = new();
              foreach(Node child in node.contents){
                if(child.contents != null){
                    if(child.size >= spaceNeeded)
                    {
                        canDelete.Add(child);
                    }
                    List<Node> childList = partTwoList(child,spaceNeeded);
                    if(childList.Count != 0){
                        canDelete.AddRange(childList);
                    }
                }
            }
            return canDelete;
        }
        
    }
}

class Node {
    public Node? prev {get;set;}
    public int size {get;set;}
    public string? name {get;set;}
    public List<Node>? contents {get;set;}
};