﻿class Program{
    static private DijkstrasAlgorithm algorithm = new DijkstrasAlgorithm();
    static void Main(string[] args){
        algorithm = new DijkstrasAlgorithm();
        // int[,] generatedMatrixInput = ReadMatrixInput("input.txt", 5, 0); // Uncomment for debug
        if(args.Length >= 3){
            int[,] generatedMatrixInput = ReadMatrixInput(args[0], int.Parse(args[1]), int.Parse(args[2]));
            algorithm.CreateGraph(generatedMatrixInput, int.Parse(args[1]), int.Parse(args[2]), "");
        }else{
            int[,] generatedMatrixInput = ReadMatrixInput("input.txt", 5, 0);
            algorithm.CreateGraph(generatedMatrixInput, 5, 0, "");
        }
        int[,] generatedMatrix = ReadMatrixInput("OtherExample.txt", 9, 0); // TODO: Get node numbers automatically
        algorithm.CreateGraph(generatedMatrix, 9, 0, "SuperCoolGraph");

        WriteOutputFile(algorithm.GetGraph(0));
        WriteOutputFile(algorithm.GetGraph(1));
        
    }

    static private void WriteOutputFile(Graph graph){
        string currentDir = System.IO.Directory.GetCurrentDirectory();
        string dir = currentDir + "\\Output\\";
        if(!Directory.Exists(dir)){ // If the directory does not exist, it creates it
            Directory.CreateDirectory(dir);
        }

        StreamWriter stream = new StreamWriter(new String(dir + graph.Name + "_output.txt"));
        string outputString = algorithm.GetInformation(graph.Information, graph.SourceNode, graph.NodesNumber);
        string[] outputArray = outputString.Split(",");
        foreach(string row in outputArray){
            stream.WriteLine(row);
        }
        stream.Close();
    }

    static private int[,] ReadMatrixInput(string fileName, int nodesNumber, int sourceNode){
        StreamReader stream = new StreamReader("./Input/" + fileName);

        string? rowString;
        string[] characters;
        int[] row = new int[nodesNumber];
        int[,] generatedMatrix = new int[nodesNumber, nodesNumber];
        int nodeNumber = 0;
        while( (rowString = stream.ReadLine()) is not null){
            characters = rowString.Split(" ");
            for(int character = 0; character < characters.Length; character ++){
                generatedMatrix[character, nodeNumber] = int.Parse(characters[character]);
            }
            nodeNumber ++;
        }
        return generatedMatrix;
    }
}