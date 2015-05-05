
public class Card 
{
	Rank rank;
	Suit suit;
	int value;
	
	public Card(Rank rank2, Suit suit2, int value)
	{
		this.rank = rank2;
		this.suit=suit2;
		this.value=value;
		
	}

	public Card(Card card) 
	{
		this.rank=card.rank;
		this.suit=card.suit;
		this.value=card.value;
	}

	@Override
	public String toString() 
	{
		return "Card [rank=" + rank + ", suit=" + suit + ", value=" + value
				+ "]";
	}
	
	public boolean isAce()
	{
		return rank==Rank.ACE;
	}

	public int getValue() 
	{
		return value;
	}
	
	
	

}
