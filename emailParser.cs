using UnityEngine;
using System.Collections;
using System.Xml;

public class emailParser : MonoBehaviour {
	public TextAsset GameAsset;
	public static ArrayList emails = new ArrayList();
	public static ArrayList answerChoices = new ArrayList();
	public static ArrayList answerList = new ArrayList();
	public static ArrayList correctAnswerChoices;

	public static Answer returnAnswer;
	private static string emailName;
	private static string subject;
	private static string to;
	private static string from;
	private static string body;
	private string date;
	public string answerContent;
	private bool attachment;
	private bool spam;
	public Email x;
	public static int i;
	public static int numberOfAnswers;
	public static int chosenIndex;
	public string test;
	// Use this for initialization
	void Start () 
	{
		GetEmails();
		populateAnswerChoices();
		numberOfAnswers=answerChoices.Count;


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetEmails()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(GameAsset.text);
		XmlNodeList emailList = xmlDoc.GetElementsByTagName("EMAIL");

		foreach(XmlNode emailInfo in emailList)
		{
			XmlNodeList emailContent = emailInfo.ChildNodes;

			foreach(XmlNode emailItems in emailContent)
			{

				if(emailItems.Name == "NAME")
				{
					emailName = emailItems.InnerText;

				}

				if(emailItems.Name=="SUBJECT")
				{
					subject=emailItems.InnerText;

				}

				if(emailItems.Name=="TO")
				{
					to=emailItems.InnerText;
				
				}
				if(emailItems.Name=="FROM")
				{
					from = emailItems.InnerText;
				
				}
				if(emailItems.Name=="DATE")
				{
					date = emailItems.InnerText;

				}
				if(emailItems.Name=="SPAM")
				{
					spam = bool.Parse(emailItems.InnerText);

				}

				if(emailItems.Name=="ANSWERS")
				{
					XmlNodeList answerChildren = emailItems.ChildNodes;
					correctAnswerChoices = new ArrayList();
					foreach(XmlNode answerChoice in answerChildren)
					{
					
					answerContent = answerChoice.InnerText;
					correctAnswerChoices.Add (answerContent);
					}
					Answer tempAnswer = new Answer(emailName,correctAnswerChoices);

					answerList.Add (tempAnswer);

				}


				if(emailItems.Name=="ATTACHMENT")
				{
					attachment = bool.Parse (emailItems.InnerText);

				}
				if(emailItems.Name=="BODY")
				{
					body = emailItems.InnerText;

				}

			}
			Email tempEmail = new Email(emailName,subject,to,from,date,spam,attachment,body);

			emails.Add(tempEmail);
		}
		 i = emailParser.emails.Count;


	}
	public static Email getRandomEmail()
	{

		chosenIndex = Random.Range(0,i-1);
		return (Email)emails[chosenIndex];
	}
	public static void cleanUpRandomizer()
	{
		emails.RemoveAt(chosenIndex);
		i--;
	}

	public static Email getFirstEmails(int x)
	{
		Email tempEmail = (Email)emails[x];
		emails.RemoveAt(x);
		i--;
		return (Email)tempEmail;
	}
	public static void personalizeEmail()
	{
		foreach(Email x in emails)
		{
			x.to.Replace("yname",GetName.playerName);
			x.to.Replace("ycompany",GetName.companyName);
			x.from.Replace("yname",GetName.playerName);
			x.from.Replace("ycompany",GetName.companyName);
			x.body.Replace("yname",GetName.playerName);
			x.body.Replace("ycompany",GetName.companyName);
			x.subject.Replace("yname",GetName.playerName);
			x.subject.Replace("ycompany",GetName.companyName);
			Debug.Log (i + " personalized");
		}
		
	}
	public static Answer findAnswer(Email tempEmail)
	{

		foreach(Answer temp in answerList)
		{
			if(temp.questionName == tempEmail.name)
			{
				returnAnswer=new Answer(temp);
				Debug.Log(temp.ToString());
			}
		}
		return returnAnswer;
	}

	public static string populateAnswers()
	{
		chosenIndex = Random.Range(0,numberOfAnswers-1);
		return (string)answerChoices[chosenIndex];
	}

	public static string returnTheAnswer(int i)
	{
		string returnedAnswer = (string)answerChoices[i];
		answerChoices.RemoveAt(i);
		return returnedAnswer;
	}



	public static void populateAnswerChoices()
	{
		answerChoices.Add("Recipient");
		answerChoices.Add ("Sender");
		answerChoices.Add ("Grammar and Spelling");
		answerChoices.Add ("Physical Location");
		answerChoices.Add ("Subject");
		answerChoices.Add ("Personally Indentifiable Information");
		answerChoices.Add ("Threat");
		answerChoices.Add ("Promises or Too Good to Be True");
		answerChoices.Add ("Copyright");
		answerChoices.Add ("Link");
		answerChoices.Add("Scam");
	}



	public class Email
	{
		public string name;
		public string subject;
		public string to;
		public string from;
		public string body;
		public string date;
		public bool attachment;
		public bool spam;
		public Answer answer;
	public Email(string name,string subject,string to,string from, string date, bool spam, bool attachment, string body)
	{
		this.name=name;
		this.subject=subject;
		this.to=to;
		this.from=from;
		this.date=date;
		this.spam=spam;
		this.attachment=attachment;
		this.body=body;
		
	}
		public override string ToString()
		{
			return name + subject + to + from + body+date+attachment+spam;
		}

		public Email(Email email)
		{
			this.name = email.name;
			this.subject = email.subject;
			this.to=to;
			this.from=from;
			this.date=date;
			this.spam=spam;
			this.attachment=attachment;
			this.body=body;

		}
		public Email()
		{

		}


	}

	public class Answer
	{
		public string questionName;
		public ArrayList answerList1;
		public string output;

		public Answer(string questionName,ArrayList answerList1)
		{
			this.questionName = questionName;
			this.answerList1 = answerList1;
		}
		public Answer(Answer answer)
		{
			this.questionName = answer.questionName;
			this.answerList1 = answer.answerList1;
		}
		public override string ToString ()
		{
			for(int i = 0;i<answerList1.Count;i++)
			{

				output += (string)answerList1[i] + " ";
			}
			return questionName + " " + output;
		}
		public Answer()
		{

		}
}
}