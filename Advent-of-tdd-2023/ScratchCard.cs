public class ScratcCards
{
  int winningPoints = 0;
  int cardNo = 0;
  List<int> card Numbers = new List<int>();
  List<int> winning Numbers = new List<int>();
  public ScratchCards()
  {
    
  }
  public ScratchCards(int cardNo, List<int> winning Numbers, List<int> cardNumbers)
  {
    this.cardNo = cardNo;
    this.winning Numbers = winning Numbers;
    this.cardNumbers = cardNumbers;
  }

  public static void Main()
  {
    string file = @"C:\MSDE\POC\TDD\ScratchCard.txt";
    var obj = new ScratchCards();
    obj. TotalPoints(file);
  }
  public int get TotalCards (string file = "")
  {
    if(File.Exists(file))
    {
      string[] lines = File.ReadAllLines(file);
      return cardNo = lines.Count();
    }
    else
    {
      throw new FileNotFoundExecption();
    }
    
    public bool isWinner_in_Card()
    {
      foreach(var card in cardNumbers)
      {
        if(winningNumbers.Contains(card))
        {
          return true;
        }
      }
      return false;
    }
    public int GetTotalPoints_In_EachCardNumber(List<int> winningNumbers, List<int> cardNumbers)
    {
     int result = 0;
     winningPoints = 0;
     //calculating winning points
     foreach(var card in cardNumbers)
     {
      if (winning Numbers. Contains (card))
      {
        winningPoints++;
      }
     }
    for(int i = 0; i < winningPoints; i++)
    {
     if(result == 0)
     {
       result = 1;//first match
     }
     else
     {
       result = 2;//doubling the subsequent matches
     }
     }
      return result;
    }

    public int TotalPoints(string file)
    { 
      string[] lines ={};
      if(Files.Exists(file))
      {
        lines=Files.ReadAllLines(file);
      }
      int finalCount=0;
      var list= new List<string>();
      var TotalCardNumbers= new List<string[]>();
      foreach(var ln in lines)
      {
        list.Add(ln.Split(':'));
      }
      if(list!=null&&list.Count>0)
      {
        for(int i=0;i<list.Count;i++)
        {
          cardNumbers=new List<int>();
          winningNumbers = new List<int>();
          TotalCardNumbers.Add(List[i][1].ToString().Split('|'));
           foreach(var wn in TotalCardNumbers[i][0].Trim().Split(' '))
           {
             winningNumbers.Add(int.Parse(wn));
           }
            foreach(var wn in TotalCardNumbers[i][1].Trim().Split(' '))
           {
             cardNumbers.Add(int.Parse(wn));
           }
          finalCount+=GetTotalPoints_In_EachCardNumber(winningNumbers,cardNumbers);
        }
      }
      return finalCount;
    }
}
