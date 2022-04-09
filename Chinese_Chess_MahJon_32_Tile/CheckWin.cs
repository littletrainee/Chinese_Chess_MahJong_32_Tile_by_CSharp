namespace Chinese_Chess_MahJon_32_Tile {
  internal class CheckWin {
    private List<string> probablypair = new();
    private List<string> pair = new();
    private static void CheckPair(List<string> probablypair, List<string> hand) {
      foreach (string target in hand)
        if (hand.Count(targetvariable => targetvariable == target) >= 2 &&
          !hand.Contains(target)) {
          probablypair.Add(target);
        } else if (hand.Contains("1b") && hand.Contains("1r")) {
          probablypair.Add("1b");
          probablypair.Add("1r");
        }
    }

    private bool Sequence(List<string> hand) {
      if ((int)hand[0][0] - 47 == (int)hand[1][0] - 48 &&
          (int)hand[1][0] - 47 == (int)hand[2][0] - 48)
        return true;
      else
        return false;
    }

    private bool PairIs1bAnd1r(List<string> hand) {
      List<string> temphand = hand.ToList();
      temphand.Remove("1b");
      temphand.Remove("1r");
      if (Sequence(temphand)) {
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
        if (Sequence(temphand)) {
          pair.Add(target);
          return true;
        }
      }
      return false;
    }

    public bool CheckIsWinning(Player player) {
      // if player doesn't have meld (count to 0)
      if (player.Meld.Count == 0) {
        // check pair first
        CheckPair(probablypair, player.Hand);
        // probably pair is 1b and 1r
        if (probablypair.Contains("1b") && probablypair.Contains("1r")) {
          PairIs1bAnd1r(player.Hand);
          // probably pair isn't 1b and 1r but isn't empty
        } else if (probablypair.Any()) {
          // pair isn't empty
          if (PairNotEmpty(player.Hand)) {
            return true;
            // Special kind with 7b
          } else if (player.Hand.Count(targetvalue => targetvalue == "7b") == 5) {
            pair.Add("7b");
            return true;
            // Special kind with 7r
          } else if (player.Hand.Count(targetvalue => targetvalue == "7r") == 5) {
            pair.Add("7r");
            return true;
          }
          // probably pair is empty
        } else {
          return false;
        }
        // if player has meld(count to 1)
      } else {
        // hand[0] == hand[1]
        if (player.Hand[0] == player.Hand[1]) {
          pair.Add(player.Hand[0]);
          return true;
        // hand contains 1b and 1r
        } else if (player.Hand.Contains("1b") && player.Hand.Contains("1r")) {
          pair.Add("1b");
          pair.Add("1r");
          return true;
        // pair is different
        } else {
          return false;
        }
      }
      // other
      return false;
    }
  }
}
