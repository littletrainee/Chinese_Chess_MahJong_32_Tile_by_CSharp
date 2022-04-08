namespace Chinese_Chess_MahJon_32_Tile {
  internal class Function {
    public List<string> AppendTileToWall() {
      List<string> wall = new List<string>();
      foreach (KeyValuePair<string, string> key in Chinese_Chess_MahJong_Tile.Tile) {
        if (key.Key == "1b" || key.Key == "1r") {
          wall.Add(key.Key);
        } else if (key.Key == "7b" || key.Key == "7r") {
          for (int i = 0; i < 5; i++)
            wall.Add(key.Key);
        } else {
          for (int i = 0; i < 2; i++)
            wall.Add(key.Key);
        }
      }
      return wall;
    }
  }
}
