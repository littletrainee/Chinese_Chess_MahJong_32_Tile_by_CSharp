namespace Chinese_Chess_MahJon_32_Tile {
  class Player : APlayer {
    public override string Name { get; set; } = "";
    public override List<string> Hand { get; set; } = new();
    public override List<List<string>> Meld { get; set; } = new();
    public override List<string> River { get; set; } = new();
  }

  class Wall : AWall {
    public override string Name { get; set; } = "牌山";
    public override List<string> Hand { get; set; } = new();
  }

  class Program {
    public static void SetUp(Player player1, Player player2,Wall wall) {
      for (int i = 0; i < 2; i++) {
        for (int j = 0; j < 2; j++)
          Function.DrawFromTheFronta(player1.Hand, wall.Hand);
        for (int j = 0; j < 2; j++)
          Function.DrawFromTheFronta(player2.Hand, wall.Hand);
      }
      Function.DrawFromTheFronta(player1.Hand, wall.Hand);
      Function.DrawFromTheFronta(player2.Hand, wall.Hand);
    }

    private static void Main() {
      // declare bool
      bool iswinning = false;
      // declare class
      Player player1 = new();
      Player player2 = new();
      Wall wall = new();
      CheckWin cw = new();
      // set player name
      player1.Name = "player1";
      player2.Name = "player2";
      // append tile to wall
      Function.AppendTileToWall(wall.Hand);
      Function.Shuffle(wall.Hand);
      SetUp(player1, player2, wall);
      //player1.Hand.Add("1b");
      //player1.Hand.Add("2b");
      //player1.Hand.Add("3b");
      //player1.Hand.Add("4r");
      //player2.River.Add("4r");
      //Console.WriteLine(cw.CheckIsWinning(player1,player2));
      //foreach (string s in cw.Pair())
      //  Console.WriteLine(s);
      // print hand and wall
      Print.PrintAll(player1, player2, wall);
      iswinning = cw.CheckIsWinning(player1, player2);
      Console.WriteLine(iswinning);
      Function.DiscardFromHandToRiver(player1);
    }
  }
}