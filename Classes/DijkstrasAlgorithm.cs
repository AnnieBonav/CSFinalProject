class DijkstrasAlgorithm{
    private string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M"}; // JUst dont save here
    private List<Graph> graphs = new List<Graph>();

    public Graph GetGraph(int index){
        return graphs[index];
    }

    public void CreateGraph(int[,] generatedMatrix, int nodesNumber, int sourceNode, string name){
        graphs.Add(new Graph(generatedMatrix, nodesNumber, sourceNode, name));
        SolveAlgorithm(graphs.Last());
    }

    private int MinNodeDist(Information[] information, int nodesNumber, List<int> visitedNodes){
        int minDistNode = -1; // I make it undefined, so if no nodes are found I return -1 and I can work with that
        double minDistance = double.PositiveInfinity; // This will always be larger than the distance we are checking
        for(int node = 0; node < nodesNumber; node ++){ // Go through all of the nodes, trying to find the one that has not been visited, with the lowest distance
            if(visitedNodes.Contains(node)){ // If the node has been visited, it is discarded
                continue;
            }
            double dist = information[node].Distance; // The distance we care about is the none-checked nodes
            if(dist < minDistance){ // If it is lower than the currently stored minDistance, then it will become the new minDIstance
                minDistance = dist;
                minDistNode = node;
            }
        }
        return minDistNode;
    }

    public void SolveAlgorithm(Graph selectedGraph){
        int nodesNumber = selectedGraph.NodesNumber;
        int sourceNode = selectedGraph.SourceNode;
        int[,] matrix = selectedGraph.Matrix;
        Information[] information = selectedGraph.Information;
        List<int> unvisitedNodes = selectedGraph.UnvisitedNodes;
        List<int> visitedNodes = selectedGraph.VisitedNodes;

        for(int i = 0; i < nodesNumber; i ++){
            if(i != sourceNode){
                information[i].Distance = double.PositiveInfinity;
            }else{
                information[sourceNode].Distance = 0;
                information[sourceNode].NodesPath = sourceNode.ToString();
            }
        }

        while(unvisitedNodes.Count > 0){ // Do while there are nodes to still visit
            int minDistNode = MinNodeDist(information, nodesNumber, visitedNodes);
            if(minDistNode == -1){ // This means all of the remaining nodes cannot be reached, so the weights stay the same and I just ened my program
                break;
            }
            
            for(int node = 0; node < nodesNumber; node ++){ // Go through all of the nodes, to find which ones the selected node (which is the min node) is connected to
                int dist = matrix[minDistNode, node]; // The distance is the current info from the minNode to the checked Node. If they are connected, the distance will not be 0
                
                if(dist != 0){ // If the selected node connects to another one, we check them
                    double newDistance = information[minDistNode].Distance + dist; // The new distance will be the information on the current node's accumulated distance (which is the current information on the distance column of the information, and the selected node) plus the distance between the minimum node and the checked node
                    double currentDistance = information[node].Distance; // the Current accumulated distance to the TO node. Will be -1 when we start, and can change of a shorter path is ofund

                    if(newDistance < currentDistance){ // We change the information of the current Distance of getting to the node to the accumulated Distance plus the current edge's Distance ONLY if this would be smaller than the current saved distance and the currently saved distance
                        information[node].Distance = newDistance;
                        information[node].NodesPath = information[node].NodesPath + minDistNode.ToString() + " -> "; // Change the last node before this node to the current node we are going from
                    }// TODO: Add the last node
                }
            }
            selectedGraph.VisitNode(minDistNode);
        }

        // Console.WriteLine("FINAL RESULTS"); // Uncomment if want to see the information in the console
        // PrintInformation(information, sourceNode, nodesNumber);
        // PrintNodeStatus(visitedNodes, unvisitedNodes);
    }

    public string PrintInformation(Information[] information, int sourceNode, int nodesNumber){
        string outputString = new String("Selected source Node: " + sourceNode + ",");
        for(int i = 0; i < nodesNumber; i ++){
            string path = information[i].NodesPath;
            if(path == ""){
                path = " | No way of getting there";
            }else{
                if(i != sourceNode) path = " | Path: " + path + i;
                else path = " | Path: " + path;
            }
            outputString = outputString + letters[i] + " Distance: " + information[i].Distance.ToString() + path + ",";
        }
        return outputString;
    }

    private void PrintNodeStatus(List<int> visitedNodes, List<int> unvisitedNodes){
        string visitedNodesString = "";
        string unvisitedNodesString = "";
        for(int i = 0; i < visitedNodes.Count; i ++){
            visitedNodesString = visitedNodesString + visitedNodes[i] + " ";
        }

        for(int i = 0; i < unvisitedNodes.Count; i ++){
            unvisitedNodesString = unvisitedNodesString + unvisitedNodes[i] + " ";
        }
        Console.WriteLine($"\nVisited Nodes: {visitedNodesString} Unvisited Nodes: {unvisitedNodesString}");
    }
}