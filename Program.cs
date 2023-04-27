
class Program{
    static private int _sourceNode = -1;
    static private string _fileName = "TestMatrix.txt";
    static private int _nodesNumber;
    static private int[,] _generatedMatrix;
    static private int[,] _transposedMatrix;
    static private List<int> unvisitedNodes = new List<int>();
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
        if(args.Length >= 3){
            _fileName = args[0];
            _nodesNumber = int.Parse(args[1]);
            _sourceNode = int.Parse(args[2]);
        }
        _generatedMatrix = new int[_nodesNumber, _nodesNumber];
        _transposedMatrix = new int[_nodesNumber, _nodesNumber];
        ReadMatrixInput();
        TransposeMatrix();
        Graph graph = new Graph(_transposedMatrix, unvisitedNodes, _nodesNumber, _sourceNode);
        graph.Algorithm();
    }

    static private void ReadMatrixInput(){
        StreamReader stream = new StreamReader(_fileName);

        string? rowString;
        string[] characters;
        int[] row = new int[_nodesNumber];
        int nodeNumber = 0;
        while( (rowString = stream.ReadLine()) is not null){
            characters = rowString.Split(" ");
            for(int character = 0; character < characters.Length; character ++){
                _generatedMatrix[nodeNumber, character] = int.Parse(characters[character]);
            }
            unvisitedNodes.Add(nodeNumber);
            nodeNumber ++;
        }
    }

    static private void TransposeMatrix(){
        for(int row = 0; row < _nodesNumber; row ++){
            for(int column = 0; column < _nodesNumber; column ++){
                _transposedMatrix[column, row] = _generatedMatrix[row, column];
            }
        }
    }
}