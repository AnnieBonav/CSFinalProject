
class Graph{
    private string[] _letters = {"A", "B", "C", "D", "E"};
    private int _nodesNumber;
    private string _fileName = "TestMatrix.txt";
    private int _sourceNode = -1;
    private int[,] _information;
    private int[,] _adjacencyMatrix;
    public string FileName{
        get{ return _fileName; }
        set{ _fileName = value; }
    }

    public Graph(string fileName, int nodesNumber, int sourceNode){
        _nodesNumber = nodesNumber;
        _fileName = fileName;
        _sourceNode = sourceNode;

        _adjacencyMatrix = new int[_nodesNumber, _nodesNumber]; // Need to initialize it
        _information = new int[3, _nodesNumber];

        FillMatrix();
    }


    private void FillMatrix(){
        StreamReader stream = new StreamReader(_fileName);

        string? rowString;
        string[] characters;
        int[] row = new int[_nodesNumber];
        int nodeNumber = 0;
        while( (rowString = stream.ReadLine()) is not null){
            characters = rowString.Split(" ");
            for(int character = 0; character < characters.Length; character ++){
                _adjacencyMatrix[nodeNumber, character] = int.Parse(characters[character]);
            }
            nodeNumber ++;
        }
    }

    public override string ToString()
    {
        string rowString = "";
        string completeMatrix = "";
        for(int column = 0; column < _nodesNumber; column ++){
            for(int row = 0; row < _nodesNumber; row ++){
                rowString = rowString + " " + _adjacencyMatrix[column, row].ToString();
            }
            completeMatrix = completeMatrix + "\n" + rowString;
            rowString = "";
        }
        return completeMatrix;
    }
    public int[,] AdjacencyMatrix{
        get{ return _adjacencyMatrix; }
        set{ _adjacencyMatrix = value; }
    }
    
    public int NodesNumber{
        get{ return _nodesNumber; }
    }

    public void Algorithm(){
        // Initialize values
        Console.WriteLine(this.ToString());
        for(int i = 0; i < _nodesNumber; i ++){
            _information[0, i] = i;
            _information[1, i] = -1; // -1 will be my infinity

        }

        _information[1, _sourceNode] = 0; //Distance from source node to source node is 0

        for(int row = 0; row < _nodesNumber; row ++){ /// Go through all of the nodes
            int selectedNumber = _adjacencyMatrix[row,0];
            Console.WriteLine($"Column: {0} RowNumber: {row} Value: {selectedNumber}");

            if(_adjacencyMatrix[0,row] != 0){
                Console.WriteLine($"Column: {0} RowNumber: {row} Value: {selectedNumber}");
            }
            if(row == _sourceNode) continue; // The distance between source node and the soucr node is 0
        }
    }

    private void PrintInformation(){
        string row = "";
        Console.WriteLine("Source Node: " + _sourceNode);
        for(int i = 0; i < _nodesNumber; i ++){ // 3 is the length of the amount of info stored // _information.Length is 3 * amount of nodes
            for(int j = 0; j < 3 ; j ++){
                row = row + _information[j, i].ToString() + " ";
            }
            Console.WriteLine(_letters[i] + " | " + row + "| ");
            row = "";
        }
    }
}


class Program{
    static private int _sourceNode = -1;
    // A-0, B-1, C-2, D-3, E-4
    // Node Identifier, Shortest distance value, Last Node
    // A |0 0 0| A
    // B |1 3 2| C
    // C |2 2 0| A
    // D |3 5 1| B
    // E |4 6 1| B
    static private List<int> _shortestDistances = new List<int>(); // This is the one that gets updated with the shortest Distances

    static void Main(string[] args){
        // FileName, nodesAmount, SourceNode
        // dotnet run TestMatrix.txt 5 0
        _sourceNode = int.Parse(args[2]);
        Graph testGraph = new Graph(args[0], int.Parse(args[1]), _sourceNode);
        testGraph.Algorithm();
    }

    
}