
class Graph{
    private string[] _letters = {"A", "B", "C", "D", "E"};
    private int _nodesNumber;
    private string _fileName = "TestMatrix.txt";
    private int _sourceNode = -1;
    private int[,] _information;
    private int[,] _adjacencyMatrix;
    private int[,] _transposedMatrix;

    private List<int> _visitedNodes = new List<int>();
    private List<int> _unvisitedNodes = new List<int>();
    public string FileName{
        get{ return _fileName; }
        set{ _fileName = value; }
    }

    public Graph(string fileName, int nodesNumber, int sourceNode){
        _nodesNumber = nodesNumber;
        _fileName = fileName;
        _sourceNode = sourceNode;

        _adjacencyMatrix = new int[_nodesNumber, _nodesNumber]; // Need to initialize it
        _transposedMatrix = new int[_nodesNumber, _nodesNumber]; // Need to initialize it
        _information = new int[3, _nodesNumber];

        FillMatrix();
        TransposeMatrix();
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
            _unvisitedNodes.Add(nodeNumber);
            nodeNumber ++;
        }
    }

    private void TransposeMatrix(){
        for(int row = 0; row < _nodesNumber; row ++){
            for(int column = 0; column < _nodesNumber; column ++){
                _transposedMatrix[column, row] = _adjacencyMatrix[row, column];
            }
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
        int accumulatedDistance = _information[0, _sourceNode]; // Current accumulated distance
        Console.WriteLine($"Source: {_sourceNode} Current distance:  {accumulatedDistance}");
        PrintNodeStatus();

        int selectedNode = _sourceNode;
        int nextNode; // Determined by which one has the smaller weight after checking all of the current nodes possibilities
        int leastDistance; // The currently checked node with the least distance. I save it so I know which will be the next node
        for(int node = 0; node < _nodesNumber; node ++){ /// Go through all of the nodes
            int edgeDistance = _transposedMatrix[0,node]; // TODO: Change 0 so it is the currently looked at node
            
            if(_transposedMatrix[0,node] != 0){ // If the selected node connects to another one, we check them
                int newDistance = accumulatedDistance + edgeDistance;
                int currentDistance = _information[1, node];

                if( currentDistance == -1 || newDistance < currentDistance){ // We change the information of the current Distance of getting to the node to the accumulated Distance plus the current edge's Distance ONLY if this would be smaller than the current saved distance and the currently saved distance is not -1 (which would make it infinity)
                    _information[1, node] = newDistance;
                    _information[2,node] = selectedNode; // Change the last node before this node to the current node we are going from // TODO: Change so that it does not only use the source node
                    if(newDistance < leastDistance){
                        leastDistance = newDistance;
                        nextNode = node;
                    }
                } 
                
                Console.WriteLine($"Column: {0} NodeNumber: {node} Value: {edgeDistance}");
            }
            // if(node == _sourceNode) continue; // The distance between source node and the soucr node is 0
        }

        _unvisitedNodes.Remove(selectedNode); // TOOD: Change to currently looked at node
        _visitedNodes.Add(selectedNode); // TODO: Same

        // CHECK WHICH NODE TO GO


        PrintInformation();
        PrintNodeStatus();
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

    private void PrintNodeStatus(){
        string visitedNodes = "";
        string unvisitedNodes = "";
        for(int i = 0; i < _visitedNodes.Count; i ++){
            visitedNodes = visitedNodes + _visitedNodes[i];
        }

        for(int i = 0; i < _unvisitedNodes.Count; i ++){
            unvisitedNodes = unvisitedNodes + _unvisitedNodes[i] + " ";
        }
        Console.WriteLine($"Visited Nodes: {visitedNodes} Unvisited Nodes: {unvisitedNodes}");
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