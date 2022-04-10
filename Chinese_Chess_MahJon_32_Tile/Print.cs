namespace Chinese_Chess_MahJon_32_Tile {
  internal class Print {
    public static void PrintHand(Player player, bool numberindex) {
      if (numberindex) {
        for (int i = 0; i < player.Hand.Count; i++) {
          Console.Write(i + 1);
          Console.Write(". " +
            Chinese_Chess_MahJong_Tile.Tile[player.Hand[i]] + " ");
        }
      } else {
        Console.Write(player.Name + "'s hand:");
        foreach (string i in player.Hand)
          Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      }
      Console.WriteLine();
    }
    private static void PrintWall(Wall wall) {
      Console.Write(wall.Name + ":");
      foreach (string i in wall.Hand)
        Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      Console.WriteLine();
    }

    public static void PrintAll(Player player1, Player player2, Wall wall) {
      PrintHand(player1, false);
      PrintWall(wall);
      PrintHand(player2, false);
    }

  }
}
