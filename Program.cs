class Program{
    static private DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm();
    static void Main(string[] args){
        algorithm = new DijkstrasAlgorithm();
        int[,] generatedMatrix = ReadMatrixInput(args[0], int.Parse(args[1]), int.Parse(args[2]));

        algorithm.CreateGraph(generatedMatrix, int.Parse(args[1]), int.Parse(args[2]));
    }

    static private int[,] ReadMatrixInput(string fileName, int nodesNumber, int sourceNode){
        StreamReader stream = new StreamReader(fileName);

        string? rowString;
        string[] characters;
        int[] row = new int[nodesNumber];
        int[,] generatedMatrix = new int[nodesNumber, nodesNumber];
        int nodeNumber = 0;
        while( (rowString = stream.ReadLine()) is not null){
            characters = rowString.Split(" ");
            for(int character = 0; character < characters.Length; character ++){
                // generatedMatrix[nodeNumber, character] = int.Parse(characters[character]);
                generatedMatrix[character, nodeNumber] = int.Parse(characters[character]);
            }
            nodeNumber ++;
        }
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