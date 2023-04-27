class Graph{
    private string _name = "";
    public string Name{
        get { return _name; }
        set { _name = value; }
    }
    private int _nodesNumber = -1;
    private int _sourceNode = -1;

    public int NodesNumber{
        get{ return _nodesNumber; }
    }
    public int SourceNode{
        get{ return _sourceNode; }
        set{ _sourceNode = value; }
    }
    private Information[] _information;

    public Information[] Information{
        get{ return _information; }
    }
    private int[,] _matrix;

    public int[,] Matrix{
        get{ return _matrix; }
    }

    public List<int> UnvisitedNodes{
        get {return _unvisitedNodes; }
    }

    public List<int> VisitedNodes{
        get {return _visitedNodes; }
    }

    public void VisitNode(int node){ // Used to remove an unvisited node and add it
        _unvisitedNodes.Remove(node);
        _visitedNodes.Add(node);
    }

    public Graph(int[,] generatedMatrix, int nodesNumber, int sourceNode, string name){ // TODO: Generated unvisited nodes 
        _matrix = generatedMatrix;
        _nodesNumber = nodesNumber;
        _sourceNode = sourceNode;
        _name = name;

        _information = new Information[_nodesNumber];
        for(int i = 0; i < _nodesNumber; i ++){
            _information[i] = new Information();
        }
        InitializeUnvisitedNodes();
    }

    private List<int> _visitedNodes = new List<int>();
    private List<int> _unvisitedNodes = new List<int>();

    private void InitializeUnvisitedNodes(){
        for(int i = 0; i < _nodesNumber; i ++){
            _unvisitedNodes.Add(i);
        }
    }
    public override string ToString()
    {
        string rowString = "";
        string completeMatrix = "";
        for(int column = 0; column < _nodesNumber; column ++){
            for(int row = 0; row < _nodesNumber; row ++){
                rowString = rowString + " " + _matrix[column, row].ToString();
            }
            completeMatrix = completeMatrix + "\n" + rowString;
            rowString = "";
        }
        return completeMatrix;
    }
}