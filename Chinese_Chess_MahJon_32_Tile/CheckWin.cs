namespace Chinese_Chess_MahJon_32_Tile {
  internal class CheckWin {
    private List<string> probablypair { get; set; } = new();
    private List<string> pair { get; set; } = new();
    private static void CheckPair(List<string> probablypair, List<string> hand) {
      foreach (string target in hand) {
        if (hand.Count(targetvariable => targetvariable == target) >= 2 &&
          ! probablypair.Contains(target)) {
          probablypair.Add(target);
        } else if (hand.Contains("1b") && hand.Contains("1r")) {
          probablypair.Add("1b");
          probablypair.Add("1r");
        }
      }
    }

    private static bool SequenceOrTriple(List<string> hand) {
      // sequence
      if (hand[0][0] - 47 == hand[1][0] - 48 &&
          hand[1][0] - 47 == hand[2][0] - 48 ||
          // triple
           hand[0] == hand[1] && hand[1] == hand[2])
        return true;
      // not meld
      else
        return false;
    }

    private bool PairIs1bAnd1r(List<string> hand) {
      List<string> temphand = hand.ToList();
      temphand.Remove("1b");
      temphand.Remove("1r");
      if (SequenceOrTriple(temphand)) {
        pair.Add("1b");
        pair.Add("1r");
        return true;
      } else {
        return false;
      }
    }

    private bool PairNotEmpty(List<string> hand) {
      foreach (string target in probablypair) {
        List<string> temphand = hand.ToList();
        // remove pair from temphand
        for (int j = 0; j < 2; j++)
          temphand.Remove(target);
        if (SequenceOrTriple(temphand)) {
          pair.Add(target);
          return true;
        }
      }
      return false;
    }

    public List<string> Pair() => pair;

    public bool CheckIsWinning(Player thisplayer, Player otherplayer) {
      // if player doesn't have meld (count to 0)
      if (thisplayer.Meld.Count == 0) {
        List<string> temphand = thisplayer.Hand.ToList();
        if (temphand.Count != 5)
          temphand.Add(otherplayer.River.Last());
        // check pair first
        CheckPair(probablypair, temphand);
        // probably pair is 1b and 1r
        if (probablypair.Contains("1b") && probablypair.Contains("1r")) {
          return PairIs1bAnd1r(temphand);
          // probably pair isn't 1b and 1r but isn't empty
        } else if (probablypair.Any()) {
          // pair isn't empty
          if (PairNotEmpty(temphand)) {
            return true;
            // Special kind with 7b
          } else if (temphand.Count(targetvalue => targetvalue == "7b") == 5) {
            pair.Add("7b");
            return true;
            // Special kind with 7r
          } else if (temphand.Count(targetvalue => targetvalue == "7r") == 5) {
            pair.Add("7r");
            return true;
          }
          // probably pair is empty
        } else {
          return false;
        }
        // if player has meld(count to 1)
      } else {
        List<string> temphand = thisplayer.Hand.ToList();
        if (temphand.Count != 2)
          temphand.Add(otherplayer.River.Last());
        // hand[0] == hand[1]
        if (temphand[0] == temphand[1]) {
          pair.Add(temphand[0]);
          return true;
        // hand[0] != hand[1] but hand contains 1b and 1r
        } else if (temphand.Contains("1b") && temphand.Contains("1r")) {
          pair.Add("1b");
          pair.Add("1r");
          return true;
        // pair isn't 1b or 1r
        } else {
          return false;
        }
      }
      // other
      return false;
    }
  }
}
