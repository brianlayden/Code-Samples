import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

public class Deck
{
	static ArrayList<Card> cardDeck = new ArrayList<Card>();
	static Suit[] suit = Suit.values();
	static Rank[] rank = Rank.values();
	static int[] value = {2,3,4,5,6,7,8,9,10,10,10,10,11};
	static final int DECKSIZE = 52;
	
	
	int counter = 0;
	static int cardsInHand = 0;

	public String toString()
	{
		String deckPrint="";
		for(int i =counter; i <cardDeck.size();i++)
		{
			deckPrint+=cardDeck.get(i);
			
			if(i%5==0)
			{
				deckPrint+='\n';
			}
		}
		return deckPrint;
	
		
	}
	public void generateDeck()
	{
	for(int j=0; j<suit.length;j++)
	{
		for(int i=0; i<rank.length;i++)
		{
			
			
			
				cardDeck.add(new Card(rank[i], suit[j],  value[i]));
			
				
			
			
		}
	}
	Collections.shuffle(cardDeck);
	
	
	}
	public void shuffleDeck()
	{
		
		Collections.shuffle(cardDeck);
		counter = 0;
		Hand.initializeHand();
		Hand.handvalue=0;
	}
	
	public Card dealCard()
	{
		Card nextCard;
		
		
		nextCard = cardDeck.get(counter);
		counter++;
		
		
		Hand.myHand.add(nextCard);
		cardsInHand++;
				
		return nextCard;
		
		
	}
	public int cardsLeft()
	{
		return 52-counter;
	}
	
	
}
