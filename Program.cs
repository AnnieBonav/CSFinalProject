class Program{
    static private DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm();
    static void Main(string[] args){
        
        if(args.Length >= 3){
            algorithm = new DijkstrasAlgorithm(args[0], int.Parse(args[1]), int.Parse(args[2]));
        }else{
            algorithm = new DijkstrasAlgorithm();
        }

        ReadMatrixInput();        
        algorithm.CreateGraph();
    }

    static private void ReadMatrixInput(){
        StreamReader stream = new StreamReader(algorithm.FileName);

        string? rowString;
        string[] characters;
        int[] row = new int[algorithm.NodesNumber];
        int[,] generatedMatrix = new int[algorithm.NodesNumber, algorithm.NodesNumber];
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

        algorithm.UnvisitedNodes = unvisitedNodes;
        algorithm.GeneratedMatrix = generatedMatrix;
    }

    // static private void TransposeMatrix(){
    //     for(int row = 0; row < _nodesNumber; row ++){
    //         for(int column = 0; column < _nodesNumber; column ++){
    //             _transposedMatrix[column, row] = _generatedMatrix[row, column];
    //         }
    //     }
    // }
}