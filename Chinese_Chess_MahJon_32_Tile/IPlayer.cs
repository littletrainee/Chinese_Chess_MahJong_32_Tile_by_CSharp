namespace Chinese_Chess_MahJon_32_Tile {
  internal interface IPlayer {
    public string Name { get; set; }
    public List<string> Hand { get; set; }
    public List<List<string>> Meld { get; set; }
    public List<string> River { get; set; }
  }
}
