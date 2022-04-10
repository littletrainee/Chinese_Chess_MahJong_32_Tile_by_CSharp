namespace Chinese_Chess_MahJon_32_Tile {
  /// <summary>
  /// Any need used to function class
  /// </summary>
  internal class Function {
    /// Append Tile from tile dictionary to wall 
    public static void AppendTileToWall(List<string> wall) {
      foreach (KeyValuePair<string, string> key in Chinese_Chess_MahJong_Tile.Tile) {
        // conver char to int (ASCII) with switch expression and
        // assign to reapeat_time
        int repeat_time = ((int)key.Key[0] - 48) switch {
          1 => 1,
          7 => 5,
          _ => 2
        };
        for (int i = 0; i < repeat_time; i++)
          wall.Add(key.Key);
      }
    }

    /// shuffle
    public static void Shuffle<T>(IList<T> list) {
      Random rnd = new ();
      int n = list.Count;
      while (n > 1) {
        n--;
        int k = rnd.Next(n + 1);
        (list[n], list[k]) = (list[k], list[n]);
      }
    }

    /// Draw 
    public static void DrawFromTheFronta(List<string> player, List<string> wall) {
      player.Add(wall.First());
      wall.RemoveAt(0);
    }

    /// Discard
    public static void DiscardFromHandToRiver(Player player) {
      Console.Write("Select whitch one you want to discard:");
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      char c = Console.ReadLine()[0];
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
      Console.WriteLine(c);

    }
  }
}
