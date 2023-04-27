class Information{
    private double _distance = -1;
    private string _nodesPath = "";

    public double Distance{
        get { return _distance; }
        set{ _distance = value; }
    }
    
    public string NodesPath{
        get { return _nodesPath; }
        set { _nodesPath = value; }
    }
}