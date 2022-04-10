namespace Chinese_Chess_MahJon_32_Tile {
  internal class Print {

    public static void Hand(Player player, bool numberindex) {
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

    private static void River(Player player) {
      Console.Write(player.Name + "'s river:");
      foreach (string i in player.River)
        Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      Console.WriteLine();
    }

    private static void Wall(Wall wall) {
      Console.Write(wall.Name + ":");
      foreach (string i in wall.Hand)
        Console.Write(Chinese_Chess_MahJong_Tile.Tile[i] + " ");
      Console.WriteLine();
    }

    public static void All(Player player1, Player player2, Wall wall) {
      Hand(player2, false);
      River(player2);
      Wall(wall);
      River(player1);
      Hand(player1, false);
    }

    // print meld choice
    protected static void MeldChoice(Program.DeclareVariable dv) {
      for (int i = 0; i < dv.templl.Count; i++) {
        Console.Write(i + 1 + ". ");
        for (int j = 0; j < dv.templl[i].Count; j++) {
          Console.Write(Chinese_Chess_MahJong_Tile.Tile[dv.templl[i][j]] + " ");
        }
        Console.Write("  ");
      }
    }
  }
}
