namespace Chinese_Chess_MahJon_32_Tile {
  class Player : IPlayer {
    public string Name { get; set; } = "";
    public List<string> Hand { get; set; } = new List<string>();
    public List<List<string>> Meld { get; set; } = new List<List<string>>();
    public List<string> River { get; set; } = new List<string>();
  }

  class Wall : IWall {
    public string Name { get; set; } = "wall";
    public List<string> Hand { get; set; } = new List<string>();
  }

  class Program {
    static void Main() {
      // declare class
      Player player1 = new();
      Player player2 = new();
      Wall wall = new();
      Function func = new();
      // set player name
      player1.Name = "player1";
      player2.Name = "player2";
      // append tile to wall
      wall.Hand = func.AppendTileToWall();

    }
  }
}