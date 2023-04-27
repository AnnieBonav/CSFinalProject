class Graph{
    private string[] _letters = {"A", "B", "C", "D", "E"};
    private int _nodesNumber;
    private string _fileName = "TestMatrix.txt";
    private int _sourceNode = -1;
    private double[,] _information;
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
        _information = new double[2, _nodesNumber];
        // _information[0] = Node number
        // _information[1] = Current known shortest distance
        // -information[2] = Last Node visited for this node

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

    private int MinNodeDist(int selectedNode){ // slectedNode is the node from
        int minDistNode = -1;
        double minimumDistance = -1; // Unchecked
        for(int node = 0; node < _nodesNumber; node ++){ // Go through all of the nodes, to find which ones has the minimum accumulated distance
            double dist = _information[0, node];
            
            // If the minimu distance is unchecked and there is a connectiion between our selected node and the checked node (which means the distance is not 0)
            // then I want to turn the minimumDistance into the distance between the selected node and the checked node (dist) is NOT 
            // and the minDistNode iwll be the currently checked node.
            // If this is false, I want to discard the checked node
            // EXCEPT (or) the minimu distance is not -1, and the currently checked distance (dist) is NOT 0 (so there is a connection) AND the dist is
            // Smaller than the current minimum distance. THEN I also want to make the minimu distance the current dist and the minNode the
            // Currently checked node.
            if( (minimumDistance == -1 && dist != 0) || (minimumDistance != -1 && dist !=0 && dist < minimumDistance)){
                //Console.WriteLine($"Minimum Distance: {minimumDistance}, Dist: {dist}, Node: {node}");
                minimumDistance = dist;
                minDistNode = node;
            }
        }


        return minDistNode;
    } 

    /*
    private int MoreAlgorithm(int selectedNode){ // slectedNode is the node from
        int minDistNode = 0;
        for(int node = 0; node < _nodesNumber; node ++){ /// Go through all of the nodes, to find which ones the selectedNode is connected to
            int dist = _transposedMatrix[selectedNode,node]; // The distance is the current info from the selectedNode to the checked Node. If they are connected, the distance will not be 0
            
            if(_transposedMatrix[0,node] != 0){ // If the selected node connects to another one, we check them
                int newDistance = _information[1, selectedNode] + dist; // The new distance will be the information on the current node's accumulated distance (which is the current information on the distance column of the information, and the selected node) plus the distance between the selected node and the checked node
                int currentDistance = _information[1, node]; // the Current accumulated distance to the TO node. Will be -1 when we start, and can change of a shorter path is ofund

                if( currentDistance == -1 || newDistance < currentDistance){ // We change the information of the current Distance of getting to the node to the accumulated Distance plus the current edge's Distance ONLY if this would be smaller than the current saved distance and the currently saved distance is not -1 (which would make it infinity)
                    _information[1, node] = newDistance;
                    _information[2,node] = selectedNode; // Change the last node before this node to the current node we are going from // TODO: Change so that it does not only use the source node
                    
                    // Find new node
                    if(newDistance < leastDistance){
                        leastDistance = newDistance;
                        nextNode = node;
                    }
                } 
                
                Console.WriteLine($"Column: {0} NodeNumber: {node} Value: {edgeDistance}");
            }
            // if(node == _sourceNode) continue; // The distance between source node and the soucr node is 0
        }


        return minDistNode;
    }*/

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

        while(_unvisitedNodes.Count >= 0){ // While there are nodes to visit
            Console.WriteLine(_unvisitedNodes.Count);
            int minDistNode = MinNodeDist(_sourceNode);
            //Console.WriteLine($"MIN DIST NODE: {minDistNode}");
            
            for(int node = 0; node < _nodesNumber; node ++){ /// Go through all of the nodes, to find which ones the selected node (which is the min node) is connected to
                int dist = _transposedMatrix[minDistNode,node]; // The distance is the current info from the minNode to the checked Node. If they are connected, the distance will not be 0
                
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
        }

        /*

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

        */ 
        // CHECK WHICH NODE TO GO


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