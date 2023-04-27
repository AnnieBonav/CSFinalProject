
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