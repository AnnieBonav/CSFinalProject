class DijkstrasAlgorithm{
    private int _sourceNode = -1;
    private string _fileName = "";
    private int _nodesNumber = -1;
    private int[,] generatedMatrix;
    public int[,] GeneratedMatrix{
        get{ return generatedMatrix; }
        set{ generatedMatrix = value; }
    }
    private List<int> unvisitedNodes = new List<int>();
    public string FileName{
        get{ return _fileName; }
    }
    public int NodesNumber{
        get{ return _nodesNumber; }
    }
    public List<int> UnvisitedNodes{
        set{ unvisitedNodes = value; }
    }

    private Graph? graph;
    //private int[,]? _generatedMatrix; // Will be assigned
    //private int[,]? _transposedMatrix; // Will be assigned

    public DijkstrasAlgorithm(){
        _fileName = "TestMatrix.txt";
        _nodesNumber = 5; // Number of nodes in TestMatrix.txt
        _sourceNode = 0;
    }

    public DijkstrasAlgorithm(string fileName, int nodesNumber, int sourceNode){
        _fileName = fileName;
        _nodesNumber = nodesNumber; // Number of nodes in TestMatrix.txt
        _sourceNode = sourceNode;
    }

    public void Initialize(){
        // _generatedMatrix = new int[_nodesNumber, _nodesNumber];
        // _transposedMatrix = new int[_nodesNumber, _nodesNumber];
    }

    public void CreateGraph(){
        graph = new Graph(generatedMatrix, unvisitedNodes, _nodesNumber, _sourceNode);
        graph.Algorithm();
    }

    // A-0, B-1, C-2, D-3, E-4
    // Node Identifier, Shortest distance value, Last Node
    // A |0 0 0| A
    // B |1 3 2| C
    // C |2 2 0| A
    // E |4 6 1| B
}
class Program{
    static private DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm();
    static void Main(string[] args){
        // FileName, nodesAmount, SourceNode
        // dotnet run TestMatrix.txt 5 0
        if(args.Length >= 3){
            algorithm = new DijkstrasAlgorithm(args[0], int.Parse(args[1]), int.Parse(args[2]));
        }else{
            algorithm = new DijkstrasAlgorithm();
        }

        ReadMatrixInput();        
        algorithm.CreateGraph();
    }

    static private void ReadMatrixInput(){
        StreamReader stream = new StreamReader(algorithm.FileName);

        string? rowString;
        string[] characters;
        int[] row = new int[algorithm.NodesNumber];
        int[,] generatedMatrix = new int[algorithm.NodesNumber, algorithm.NodesNumber];
        List<int> unvisitedNodes = new List<int>();
        int nodeNumber = 0;
        while( (rowString = stream.ReadLine()) is not null){
            characters = rowString.Split(" ");
            for(int character = 0; character < characters.Length; character ++){
                // generatedMatrix[nodeNumber, character] = int.Parse(characters[character]);
                generatedMatrix[character, nodeNumber] = int.Parse(characters[character]);
            }
            unvisitedNodes.Add(nodeNumber);
            nodeNumber ++;
        }

        algorithm.UnvisitedNodes = unvisitedNodes;
        algorithm.GeneratedMatrix = generatedMatrix;
    }

    // static private void TransposeMatrix(){
    //     for(int row = 0; row < _nodesNumber; row ++){
    //         for(int column = 0; column < _nodesNumber; column ++){
    //             _transposedMatrix[column, row] = _generatedMatrix[row, column];
    //         }
    //     }
    // }
}