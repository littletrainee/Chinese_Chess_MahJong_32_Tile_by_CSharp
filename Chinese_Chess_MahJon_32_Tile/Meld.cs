namespace Chinese_Chess_MahJon_32_Tile {
  internal class Meld : Print {
    static List<List<string>> i { get; set; } = new();
    // minus 2 and minus 1
    private static void M2M1(string target, List<string> hand) {
      string a = (target[0] - 50).ToString() + target[1];
      string b = (target[0] - 49).ToString() + target[1];
      if (hand.Contains(a))
        if (hand.Contains(b))
          i.Add(new List<string>() { a, b });
    }
    // minus 1 and plus 1
    private static void M1P1(string target, List<string> hand) {
      string a = (target[0] - 49).ToString() + target[1];
      string b = (target[0] - 47).ToString() + target[1];
      if (hand.Contains(a))
        if (hand.Contains(b))
          i.Add(new List<string>() { a, b });
    }
    // plus 1 and plus 2
    private static void P1P2(string target, List<string> hand) {
      string a = (target[0] - 47).ToString() + target[1];
      string b = (target[0] - 46).ToString() + target[1];
      if (hand.Contains(a))
        if (hand.Contains(b))
          i.Add(new List<string>() { a, b });
    }
    // use delegate
    private delegate void Check(string target, List<string> hand);
    // only chi 
    public List<List<string>> Presence(Player thisplayer, Player otherplayer) {
      string target = otherplayer.River.Last();
      Check c = new Check(M2M1);
      c += new Check(M1P1);
      c += new Check(P1P2);
      c(target, thisplayer.Hand);
      return i;
    }

    // three choice
    private static List<string> ThreeChoice(Program.DeclareVariable dv) {
      MeldChoice(dv);
      Console.Write("\nWhitch One You Want Make Meld?");
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      int i = Console.ReadLine()[0] - 48;
      while (i < 0 || i > 3) {
        Console.Write("Wrong Enter Please Renter:");
        i = Console.ReadLine()[0] - 48;
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
      } 
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      List<string> temp = (i) switch {
        1 => dv.templl[0],
        2 => dv.templl[1],
        3 => dv.templl[3],
      };
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      return temp;
    }

    // two choice
    private static List<string> TwoChoice(Program.DeclareVariable dv) {
      MeldChoice(dv);
      Console.Write("\nWhitch One You Want Make Meld?");
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      int i = Console.ReadLine()[0] - 48;
      do {
        Console.Write("Wrong Enter Please Renter:");
        i = Console.ReadLine()[0] - 48;
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
      } while (i < 0 || i > 2);
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      List<string> temp = (i) switch {
        1 => dv.templl[0],
        2 => dv.templl[1],
      };
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      return temp;
    }

    // one choice
    private static List<string> OneChoice(Program.DeclareVariable dv) 
      => dv.templl[0];

    // want make meld or not
    public static void DoIt(Program.DeclareVariable dv,
                                   Player thisplayer, Player otherplayer) {
      // make choice
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      List<string> temp = (dv.templl.Count) switch {
        1 => OneChoice(dv),
        2 => TwoChoice(dv),
        3 => ThreeChoice(dv)
      };
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      foreach (string s in temp)
        thisplayer.Hand.Remove(s);
      // inser other player river last one to temp list
      temp.Insert(1, otherplayer.River.Last());
      // remove last one from other player river
      otherplayer.River.RemoveAt(otherplayer.River.Count - 1);
      thisplayer.Meld.Add(temp);

    }
  }
}
