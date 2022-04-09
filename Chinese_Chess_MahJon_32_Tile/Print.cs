namespace Chinese_Chess_MahJon_32_Tile {
  internal class Print {
    public static void PrintHand(Player player) {
      Console.Write(player.Name + ":");
      foreach (string i in player.Hand)
        Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      Console.WriteLine();
    }
    public static void PrintWall(Wall wall) {
      Console.Write(wall.Name + ":");
      foreach (string i in wall.Hand)
        Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      Console.WriteLine();
    }
  }
}
