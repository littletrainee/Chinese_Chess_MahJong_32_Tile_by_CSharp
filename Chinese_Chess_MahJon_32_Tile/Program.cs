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
    public static void SetUp(Player player1, Player player2, Wall wall) {
      // append tile to wall
      Function.AppendTileToWall(wall.Hand);
      // shuffle wall
      Function.Shuffle(wall.Hand);
      // draw 2 time
      for (int i = 0; i < 2; i++) {
        // each tiem 2 tile
        for (int j = 0; j < 2; j++)
          Function.DrawFromTheWallFront(player1.Hand, wall.Hand);
        // each tiem 2 tile
        for (int j = 0; j < 2; j++)
          Function.DrawFromTheWallFront(player2.Hand, wall.Hand);
      }
      // draw the 5th tile
      Function.DrawFromTheWallFront(player1.Hand, wall.Hand);
    }

    public static void Testdata(Player player1, Player player2) {
      player1.Hand.Add("1b");
      player1.Hand.Add("2b");
      player1.Hand.Add("4b");
      player1.Hand.Add("5b");
      player2.River.Add("3b");
    }

    public static bool Loop(DeclareVariable dv, CheckWin cw, Player player1,
                         Player player2, Wall wall) {
      // isn't winnig
      if (!dv.Iswinning) {
        // player1 discard from self hand to self river
        Function.DiscardFromHandToRiver(player1);
        // player2 check is winning(ron)
        dv.Iswinning = cw.CheckIsWinning(player2, player1);
        // if player2 isn't winning 
        if (!dv.Iswinning) {
          // check can make meld
          Meld.Presence(player1, player2);
          if (dv.Ismeld = Meld.MakeOrNot()) {
            // make meld
            Meld.Make(player2, player1);
            // game continue
            return true;
          } else {
            Function.DrawFromTheWallFront(player2.Hand, wall.Hand);
            // check is winning(tsumo)
            dv.Iswinning = cw.CheckIsWinning(player2, player1);
            // if winning return false(gameover), otherwise true(game continue)
            return !dv.Iswinning ? false : true;
          }
          // player2 is winning
        } else {
          // return false(gameover)
          return false;
        }
      }
      // return false(gameover)
      return false;
    }

    public struct DeclareVariable {
      public bool Iswinning { get; set; }
      public bool Gameloop { get; set; }
      public bool Ismeld { get; set; }
    }

    private static void Main() {
      DeclareVariable dv = new();
      // declare class
      Player player1 = new();
      Player player2 = new();
      Wall wall = new();
      CheckWin cw = new();
      // set player name
      player1.Name = "player1";
      player2.Name = "player2";
      Program.Testdata(player1, player2);
      // append tile to wall, shuffle it and each player draw tile from wall
      //SetUp(player1, player2, wall);
      // print hand, river and wall
      //Print.All(player1, player2, wall);
      // check player1 is winning
      //dv.Iswinning = cw.CheckIsWinning(player1, player2);
      // Print player1 is win or not
      //Console.WriteLine(dv.Iswinning);
      dv.Gameloop = Program.Loop(dv, cw, player1, player2, wall);


    }
  }
}