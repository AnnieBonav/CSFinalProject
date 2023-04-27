class DijkstrasAlgorithm{
    private Graph? graph;

    public void CreateGraph(int[,] generatedMatrix, int nodesNumber, int sourceNode, List<int> unvisitedNodes){
        graph = new Graph(generatedMatrix, nodesNumber, sourceNode, unvisitedNodes);
        graph.Algorithm();
    }

    // A-0, B-1, C-2, D-3, E-4
    // Node Identifier, Shortest distance value, Last Node
    // A |0 0 0| A
    // B |1 3 2| C
    // C |2 2 0| A
    // E |4 6 1| B
}