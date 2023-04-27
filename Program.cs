class Program{
    static private DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm();
    static private List<int> _unvisitedNodes = new List<int>();
    static void Main(string[] args){
        algorithm = new DijkstrasAlgorithm();
        int[,] generatedMatrix = ReadMatrixInput(args[0], int.Parse(args[1]), int.Parse(args[2]));

        algorithm.CreateGraph(generatedMatrix, int.Parse(args[1]), int.Parse(args[2]), _unvisitedNodes);
    }

    static private int[,] ReadMatrixInput(string fileName, int nodesNumber, int sourceNode){
        StreamReader stream = new StreamReader(fileName);

        string? rowString;
        string[] characters;
        int[] row = new int[nodesNumber];
        int[,] generatedMatrix = new int[nodesNumber, nodesNumber];
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

        _unvisitedNodes = unvisitedNodes;
        return generatedMatrix;
    }

    // static private void TransposeMatrix(){
    //     for(int row = 0; row < _nodesNumber; row ++){
    //         for(int column = 0; column < _nodesNumber; column ++){
    //             _transposedMatrix[column, row] = _generatedMatrix[row, column];
    //         }
    //     }
    // }
}