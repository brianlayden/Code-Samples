import java.util.Arrays;
import java.util.Scanner;

public class TestDriver {
	public static Deck myDeck = new Deck();
	

	public static void main(String[] args) {

		myDeck.generateDeck();

		boolean done = false;
		Scanner input = new Scanner(System.in);
		int choice;
		
		
		

		while (!done) {
			System.out.println("Enter choice");
			System.out.println("1. Display Deck");
			System.out.println("2. Deal Card");
			System.out.println("3. Shuffle Deck");
			System.out.println("4. Number of Cards Left in Deck");
			System.out.println("5. Print Current Hand");
			System.out.println("6. Hand Information");
			System.out.println("7. Check for an Ace");
			System.out.println("8. Check for bust");
			choice = input.nextInt();

			switch (choice) {
			case 1:
				System.out.println(myDeck.toString());
				break;
			case 2:
				if (myDeck.cardsLeft() == 0) {
					System.out
							.println("No cards left in the deck, unable to deal. Please shuffle to continue");
				} else if (myDeck.cardsLeft() <= 10) {
					System.out.println(myDeck.dealCard());
					System.out.println("There are only " + myDeck.cardsLeft()
							+ "cards left in the deck. Shuffle Soon");

				}

				else {
					System.out.println(myDeck.dealCard());
				}
				break;
			case 3:
				myDeck.shuffleDeck();

				break;
			
			case 4:
				System.out.println("Number of cards left =" + myDeck.cardsLeft());

				break;
			case 5:
				System.out.println(Hand.myHand.toString());
				

				break;
			case 6:
				System.out.println("The current value of your hand is " + Hand.handValue());
				

				break;
			case 7:
				System.out.println(Hand.acePresent());
				

				break;
			case 8:
				System.out.println(Hand.over21());
				

				break;

			default:
				done = true;
			}
		}
	}
}
