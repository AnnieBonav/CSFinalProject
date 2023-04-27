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