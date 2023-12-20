namespace AdventOfCodeTDD
{
      enum CardValues
  {
      FiveofAkind,
      FourofAkind,
      FullHouse,
      ThreeofAkind,
      twoPair,
      OnePair,
      HighCard

  }
  public class CamelGame
  {

      public int bidAmount;
      public int rank;
      public string cardFaceValue;
      public string HandValue;


      public List<string> hands = new List<string>();
      public List<int> bids = new List<int>();
      public List<CamelGame> games = new List<CamelGame>();

      public void ReadData(string FileName)
      {
          string file = @"C:\Users\MSUSERSL123\Documents\Data\" + FileName;
          if (File.Exists(file))
          {
              string[] allLines = File.ReadAllLines(file);
              foreach (var line in allLines)
              {
                  String[] splitted = line.Split(" ");
                  foreach (string value in splitted)
                  {
                      if (!string.IsNullOrEmpty(value))
                      {
                          if (!Regex.IsMatch(value, @"^[0-9]+$"))
                          {
                              hands.Add(value);
                          }
                          else
                          {
                              int i = int.Parse(value);
                              bids.Add(i);
                          }
                      }
                  }
              }

              for (int i = 0; i < hands.Count; i++)
              {
                  CamelGame game = new CamelGame();
                  game.bidAmount = bids[i];
                  game.HandValue = hands[i];
                  games.Add(game);
              }
          }
          else
          {
              throw new FileNotFoundException();
          }
      }

      public Int64 CheckRank()
      {
          Int64 sum = 0;
          foreach (var game in games)
          {
              string cardValue = GetCardValue(game);
              game.cardFaceValue = cardValue;
          }

          var highCardList = games.Where(x => x.cardFaceValue == CardValues.HighCard.ToString()).ToList();
          findRanks (highCardList);
          var onePairsList = games.Where(x => x.cardFaceValue == CardValues.OnePair.ToString()).ToList();
          findRanks(onePairsList);
          var twoPairsList = games.Where(x => x.cardFaceValue == CardValues.twoPair.ToString()).ToList();
          findRanks(twoPairsList);
          var threeOfList = games.Where(x => x.cardFaceValue == CardValues.ThreeofAkind.ToString()).ToList();
          findRanks(threeOfList);
          var fullHouseList = games.Where(x => x.cardFaceValue == CardValues.FullHouse.ToString()).ToList();
          findRanks(fullHouseList);
          var fourOfList = games.Where(x => x.cardFaceValue == CardValues.FourofAkind.ToString()).ToList();
          findRanks(fourOfList);
          var fiveOfList = games.Where(x => x.cardFaceValue == CardValues.FiveofAkind.ToString()).ToList();
          findRanks(fiveOfList);

          foreach (var game in games)
          {
              sum = sum + (game.rank * game.bidAmount);
          }
          return sum;
      }

      public void findRanks(List<CamelGame> pairsList)
      {
          int maxRank = games.Max(x => x.rank);
          var alphabetList = pairsList.Where(s => char.IsLetter(s.HandValue.FirstOrDefault())).ToList();
          var numberList = pairsList.Where(s => char.IsDigit(s.HandValue.FirstOrDefault())).ToList();

          var formednumList =numberList.OrderBy(x => x.HandValue).ToList();
          var formedalphaList = alphabetList.OrderByDescending(x => x.HandValue).ToList();
          foreach (var item in formednumList)
          {
              item.rank = maxRank + 1;
              maxRank++;
          }
          foreach (var item in formedalphaList)
          {
              item.rank = maxRank + 1;
              maxRank++;
          }

      }
      public string GetCardValue(CamelGame game)
      {
          string type = string.Empty;
          string data = game.HandValue;
          Dictionary<char, int> alphabetCount = new Dictionary<char, int>();
          for (int i = 0; i < data.Length; i++)
          {
              if (alphabetCount.ContainsKey(data[i]))
              {
                  alphabetCount[data[i]]++;
              }
              else
              {
                  alphabetCount[data[i]] = 1;
              }
          }


          switch (alphabetCount.Count)
          {
              case 1:
                  type = CardValues.FiveofAkind.ToString();
                  break;
              case 2:
                  if (alphabetCount.ContainsValue(4))
                  { type = CardValues.FourofAkind.ToString(); }
                  else
                  {
                      type = CardValues.FullHouse.ToString();
                  }
                  break;
              case 3:
                  if (alphabetCount.ContainsValue(3))
                  { type = CardValues.ThreeofAkind.ToString(); }
                  else
                  {
                      type = CardValues.twoPair.ToString();
                  }
                  break;
              case 4:
                  type = CardValues.OnePair.ToString();
                  break;
              case 5:
                  type = CardValues.HighCard.ToString();
                  break;
          }

          return type;
      }

  }
            foreach (var list in allLists) {

                for (int n = 0; n < STRENGTHS.Length; n++) {
                    var l = new List<Bid>() { };
                    list.Add(l);
                }; // one sublist for each label
            }

            foreach (var data in input) {

                var kind = cg.getKind(data);

                if (kind == "highcard") {
                    highcards=cg.placeData(data, highcards, STRENGTHS, rev_strength); continue;
                }
                if (kind == "onepair") { 
                    onepairs=cg.placeData(data, onepairs, STRENGTHS, rev_strength); continue; }
                if (kind == "twopairs") { 
                    twopairs= cg.placeData(data, twopairs, STRENGTHS, rev_strength); continue; }
                if (kind == "threesome") { 
                    threesomes=cg.placeData(data, threesomes, STRENGTHS, rev_strength); continue; }
                if (kind == "fullhouse") {
                    fullhouses=cg.placeData(data, fullhouses, STRENGTHS, rev_strength); continue; }
                if (kind == "foursome") { 
                    foursomes=cg.placeData(data, foursomes, STRENGTHS, rev_strength); continue; }
                if (kind == "fivesome") { 
                    fivesomes=cg.placeData(data, fivesomes, STRENGTHS, rev_strength); continue; }
            }

            var l2 = new List<List<List<Bid>>>();
            foreach (var list in allLists) {
                var l1 = new List<List<Bid>>();
                foreach (var sublist in list) {
                    var l3= cg.sort(sublist.ToArray());
                    l1.Add(l3);
                }
                l2.Add(l1);
            }
            //253905649
            //250946742
            var totalWinnings = 0;
            var rank = 0;
            foreach (var list in l2) {
                foreach (var sublist in list) {
                    foreach (var data in sublist) {

                        rank += 1;

                        totalWinnings += rank * data.bid;
                    }
                }
            }
            Console.WriteLine("Total winnings:", totalWinnings);
        }
        public new List<Bid> processInput(string STRENGTHS, string rev_strength)
        {
            var input = new List<Bid>();
            var lines = File.ReadLines(@"C:\Users\CamelGame.txt");
            foreach (var line in lines) {

                var tokens = line.Trim().Split(" ").ToList();


                var original = tokens.FirstOrDefault();
                tokens.Remove(original);
                var hand = convertHand(original, STRENGTHS, rev_strength);
                var bid = int.Parse(tokens.FirstOrDefault());
                input.Add(new Bid { hand = hand, bid = bid });
            }
            return input;
        }

        public string convertHand(string original,string STRENGTHS,string rev_strength)
        { // for a faster sorting

            var converted = "";


            foreach (var ch in original) {

                var index = STRENGTHS.IndexOf(ch);
                converted += rev_strength[index];
            }
            return converted;
        }
        public string getKind(Bid data)
        {

            var cards = new Dictionary<char,int>() ;

            foreach (var ch in data.hand) {

                if (cards.ContainsKey(ch))
                { var val = cards[ch];
                    cards[ch] = val + 1;
                }
                else
                {
                    cards.Add(ch, 1);
                }
            }

            var labels = cards.Keys.ToArray();


            if (labels.Length == 5) { return "highcard"; }

            if (labels.Length == 4) { return "onepair"; }

            if (labels.Length == 3)
            {

                if (cards[labels[0]] == 3) { return "threesome"; }
                if (cards[labels[1]] == 3) { return "threesome"; }
                if (cards[labels[2]] == 3) { return "threesome"; }

                return "twopairs";
            }

            if (labels.Length == 2)
            {

                if (cards[labels[0]] == 4) { return "foursome"; }
                if (labels.Length > 1 && cards[labels[1]] == 4) { return "foursome"; }
                if (labels.Length>2 && cards[labels[2]] == 4) { return "foursome"; }
                if (labels.Length > 3 && cards[labels[3]] == 4) { return "foursome"; }
                return "fullhouse";
            }

            return "fivesome";

        }

        public List<List<Bid>> placeData(Bid data, List<List<Bid>> list, string STRENGTHS, string rev_strength)
        {

            var index = STRENGTHS.Length - 1 - rev_strength.IndexOf(data.hand[0]);
               list[index].Add(data);
            return list;
        }

        public List<Bid> sort(Bid[] list)
        {
            var n = -1;
            while (true && list.Length>0)
            {
                n += 1;
                if (n+1 >= list.Length) break;
                var current = list[n];
                var next = list[n + 1];
                if (next==null)
                {
                    var bid=new List<Bid>();
                    break;
                }

                if (string.Compare(current.hand , next.hand)<0)
                {
                    list[n] = next;
                    list[n + 1] = current;
                    n = -1;
                }

            }
            return list.ToList();
        }
    }
    public class Bid
    {
        public string hand;
        public int bid;
    }

public static void Main(string[] args)
{
      amelGame camelgame = new CamelGame();
camelgame.ReadData("Day7.txt");
Int64 finalValue = camelgame.CheckRank();
Console.WriteLine("Final ways are {0}", finalValue);
}

}

