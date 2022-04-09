namespace Chinese_Chess_MahJon_32_Tile {
  internal abstract class APlayer {
    public abstract string Name { get; set; }
    public abstract List<string> Hand { get; set; }
    public abstract List<List<string>> Meld { get; set; }
    public abstract List<string> River { get; set; }
  }
  internal abstract class AWall {
    public abstract string Name { get; set; }
    public abstract List<string> Hand { get; set; }
  }
}
