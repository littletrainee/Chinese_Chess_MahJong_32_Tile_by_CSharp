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

    private static List<List<string>> Templl { get; set; } = new();
    // only chi 
    public static void Presence(Player thisplayer, Player otherplayer) {
      string target = otherplayer.River.Last();
      Check c = new Check(M2M1);
      c += new Check(M1P1);
      c += new Check(P1P2);
      c(target, thisplayer.Hand);
      Templl = i;
    }

    // three choice
    private static void ThreeChoice() {
      MeldChoice(Templl);
      Console.Write("\nWhitch One You Want Make Meld?");
      // player enter choice
      string? s = Console.ReadLine();
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      // convert player enter choice to int
      int i = s[0] - 48;
      // check the enter is correct
      while (i < 0 || i > 3 || s[0] != 'n' || s[0] != 'N') {
        Console.Write("Wrong Enter Please Renter:");
        s = Console.ReadLine();
        i = s[0] - 48;
      }
      // player enter n
      if (s[0] == 'n' || s[0] == 'N') {
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
        // return empty list
        Temp = new();
        // player want make meld
      } else {
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
        Temp = (i) switch {
          1 => Templl[0],
          2 => Templl[1],
          3 => Templl[3],
        };
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      }
    }

    // two choice
    private static void TwoChoice() {
      MeldChoice(Templl);
      Console.Write("\nWhitch One You Want Make Meld?");
      // player enter choice
      string? s = Console.ReadLine();
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      // conver player enter choice to int
      int i = s[0] - 48;
      while (i < 0 || i > 2 || s[0] != 'n' || s[0] != 'N') {
        Console.Write("Wrong Enter Please Renter:");
        s = Console.ReadLine();
        i = s[0] - 48;
      }
      // player enter n
      if (s[0] == 'n' || s[0] == 'N') {
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
        // return empty list
        Temp = new();
        // player want amek meld
      } else {
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
        Temp = (i) switch {
          1 => Templl[0],
          2 => Templl[1],
        };
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      }
    }

    // one choice
    private static void OneChoice() {
      Console.Write("Do You Want Make Meld?(y/n)");
      // player enter choice
      string? s = Console.ReadLine();
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
      while (s[0] != 'y' || s[0] != 'Y' || s[0] != 'n' || s[0] != 'N') {
        Console.Write("Wrong Enter Please Renter:");
        s = Console.ReadLine();
      }
      if (s[0] == 'n' || s[0] == 'N') 
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
        Temp = new();
       else 
        Temp = Templl[0];
    }

    private static List<string> Temp { get; set; } = new();
    // want make meld or not
    public static bool MakeOrNot() {
#pragma warning disable CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      // make choice
      switch (Templl.Count) {
        case 1:
          OneChoice();
          break;
        case 2:
          TwoChoice();
          break;
        case 3:
          ThreeChoice();
          break;
      }
#pragma warning restore CS8509 // switch 運算式未處理其輸入類型可能的值 (並非全部)。
      // temp isn't empty
      if (!Temp.Any()) {
        // make meld
        return true;
      } else {
        // don't make meld
        return false;
      }
    }

    public static void Make(Player thisplayer, Player otherplayer) {
        // remove element by temp step by step
        foreach (string s in Temp)
          thisplayer.Hand.Remove(s);
        // inser other player river last one to temp list
        Temp.Insert(1, otherplayer.River.Last());
        // remove last one from other player river
        otherplayer.River.RemoveAt(otherplayer.River.Count - 1);
        // add meld to this player meld list
        thisplayer.Meld.Add(Temp);

    }
  }
}
