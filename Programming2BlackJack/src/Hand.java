import java.util.ArrayList;
import java.util.Arrays;

public class Hand extends Deck
{
	static ArrayList<Card> myHand = new ArrayList<Card>();
	public static int handvalue = 0;
	
	
	public String toString()
	{
		return myHand.toString();
		
	}
	
	public static boolean acePresent()
	{
		boolean acepresent = false;
		for(int i =0;i<myHand.size();i++)
		{
			if(myHand.get(i).isAce()==true)
				acepresent=true;
		}
		return acepresent;
	}
	public static int handValue()
	{
		handvalue=0;
		for(int i = 0; i<cardsInHand;i++)
				handvalue+=myHand.get(i).value;
		for(int k = 0; k <cardsInHand;k++)
			if(myHand.get(k).isAce()&&handvalue>21)
				handvalue-=10;
		return handvalue;
	}
	public static boolean over21()
	{
		if(handValue()>21)
			return true;
		else
			return false;
	}
	public static void initializeHand()
	{
		myHand.clear();
		Deck.cardsInHand=0;
		
		
	}

}
