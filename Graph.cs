class Graph{
    private string[] _letters = {"A", "B", "C", "D", "E"}; // JUst dont save here
    private int _nodesNumber = -1;
    private int _sourceNode = -1;
    private double[,] _information;
    private int[,] _matrix;

    public Graph(int[,] generatedMatrix, int nodesNumber, int sourceNode){ // TODO: Generated unvisited nodes 
        _matrix = generatedMatrix;
        _nodesNumber = nodesNumber;
        _sourceNode = sourceNode;

        _information = new double[2, _nodesNumber];
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

    public int NodesNumber{
        get{ return _nodesNumber; }
    }

    private int MinNodeDist(){ // slectedNode is the node from
        Console.WriteLine("Minimum");
        int minDistNode = -1;
        double minimumDistance = double.PositiveInfinity;
        for(int node = 0; node < _nodesNumber; node ++){ // Go through all of the nodes, to find which ones has the minimum accumulated distance
            if(_visitedNodes.Contains(node)){
                Console.WriteLine("Contains");
                continue;

            }
            double dist = _information[0, node];
            if(dist < minimumDistance){
                Console.WriteLine("Is lower");
                minimumDistance = dist;
                minDistNode = node;
            }
        }
        Console.WriteLine($"MIN DIST NODE: {minDistNode}");
        return minDistNode;
    }

    public void Algorithm(){
        // Initialize values
        _information[0, _sourceNode] = 0;
        _information[1, _sourceNode] = _sourceNode;

        Console.WriteLine(this.ToString());
        for(int i = 0; i < _nodesNumber; i ++){
            if(i != _sourceNode){
                _information[0, i] = double.PositiveInfinity;
                _information[1, i] = -1; // -1 is undefined
            }
        }

        PrintNodeStatus();

        while(_unvisitedNodes.Count > 0){ // While there are nodes to visit
            Console.WriteLine(_unvisitedNodes.Count);
            int minDistNode = MinNodeDist();
            if(minDistNode == -1){ // This means all of the remaining nodes cannot be reached, so the weights stay the same and I just ened my program
                break;
            }
            Console.WriteLine($"MIN DIST NODE: {minDistNode}");
            
            for(int node = 0; node < _nodesNumber; node ++){ /// Go through all of the nodes, to find which ones the selected node (which is the min node) is connected to
                int dist = _matrix[minDistNode,node]; // The distance is the current info from the minNode to the checked Node. If they are connected, the distance will not be 0
                
                if(dist != 0){ // If the selected node connects to another one, we check them
                    double newDistance = _information[0, minDistNode] + dist; // The new distance will be the information on the current node's accumulated distance (which is the current information on the distance column of the information, and the selected node) plus the distance between the minimum node and the checked node
                    double currentDistance = _information[0, node]; // the Current accumulated distance to the TO node. Will be -1 when we start, and can change of a shorter path is ofund

                    if(newDistance < currentDistance){ // We change the information of the current Distance of getting to the node to the accumulated Distance plus the current edge's Distance ONLY if this would be smaller than the current saved distance and the currently saved distance
                        _information[0, node] = newDistance;
                        _information[1,node] = minDistNode; // Change the last node before this node to the current node we are going from
                    }
                }
            }
            _unvisitedNodes.Remove(minDistNode);
            _visitedNodes.Add(minDistNode);
            PrintNodeStatus();
            PrintInformation();
        }

        Console.WriteLine("FINAL SHIT");
        PrintInformation();
        PrintNodeStatus();
    }

    private void PrintInformation(){
        string row = "";
        Console.WriteLine("Source Node: " + _sourceNode);
        for(int i = 0; i < _nodesNumber; i ++){ // 3 is the length of the amount of info stored // _information.Length is 3 * amount of nodes
            for(int j = 0; j < 2 ; j ++){
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