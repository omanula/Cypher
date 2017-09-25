using System;
using System.IO;

namespace CeaserCypher
{

    /* Abstraction is used through encryptCharacter and decryptCharacter as the 
     * code is condensed and is able to be used multiple times. The methods are 
     * called to condense and clean up the code for usabilty. 
     * encryptCharacter: a character is encrypted then added to the end of the 
     * encryptedMessage. This repeats for each character in the input from the 
     * user and s ignored if not part of the character list. The same concept 
     * applies to the decryptCharachter, but in the opposite direction.
     * Common abstraction is used from the C# database, including the movement
     * and reformation of string. The Console brings up abstraction as code
     * can be condensed to follow through without being typed out completely
     * each time. 
     */
	/// <summary>
	/// This program implements the most basic message encryption technique.  
	/// It is called a Ceaser Cypher (See Wikipedia for more details)
	/// 
	/// Your job is to read and understand this code.
	/// Annotate this example code by commenting on every line that you have not 
	/// seen before in this class.  There are many new things here.  Tell me
	/// what new methods do, and why (you think) they are used here.
	/// 
	/// Run the program, give it some example input, see what happens.
	/// 
	/// There are new methods, opperators, and implicit data conversions here.
	/// 
	/// Make sure to read the rubric on Haiku so you know you have 
	/// covered all the points I'm looking for!
	/// 
	/// </summary>
	class MainClass
	{

		/// <summary>
		/// The alphabet in lower case.
		/// </summary>
		public static String alphabet = "abcdefghijklmnopqrstuvwxyz";


		/// <summary>
		/// The alphabet in upper case.
		/// </summary>
		public static String ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		/// <summary>
		/// Encrypts the character using the given key in the given character set.
		/// </summary>
		/// <returns>The character.</returns>
		/// <param name="charSet">Character set which the given character is a part of.</param>
		/// <param name="ch">The character.</param>
		/// <param name="key">Key for the cypher.</param>
		// Abstraction to be used in other method, simplify
        public static char EncryptCharacter(String charSet, char ch, int key)
		{
			if (charSet.IndexOf(ch) >= 0)
			{
				int charNumber = charSet.IndexOf(ch);
                // Identify the position of the chracter in the alphabet, corresponding #

				int encryptedCharNumber = (charNumber + key) % charSet.Length;
                // Key length is added to the character's number

				char encryptedChar = charSet[encryptedCharNumber];
                // The new character after encryption is established

				return encryptedChar;
                // New encrypted character is the encryptedMessage
			}
			else
			{
				return ch;
                // If not part of the character set, ignored
			}
		}

		/// <summary>
		/// Reads text from file and returns it as a String.
		/// </summary>
		/// <returns>The contents from file.</returns>
		/// <param name="fileName">Full file path.</param>
		public static String ReadFromFile(String fileName)
		{
			String contents = "";
			StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open));
            // Read the file to return the String

			while (!reader.EndOfStream)
			{
				contents += String.Format("{0}{1}", reader.ReadLine(), Environment.NewLine);
			}

			reader.Close();

			return contents;
		}

        // Abstraction of code to be used in other method
		public static char DecryptCharacter(String charSet, char ch, int key)
		{
			if (charSet.IndexOf(ch) >= 0)
			{
				int charNumber = charSet.IndexOf(ch);

				//instead of added the key to the charNumber, it is subtracted 
				int encryptedCharNumber = (charNumber - key) % charSet.Length;

				if (encryptedCharNumber < 0)
				{
					encryptedCharNumber += 26;
				}

				char encryptedChar = charSet[encryptedCharNumber];

				return encryptedChar;
			}
			else
			{
				return ch;
			}

		}

		public static void Main(string[] args)
		{
			// Ask about encrytpion of decryption option 
			Console.WriteLine("Would you like to encyrpt or decrypt a message?");
			string c = Console.ReadLine();

			// First letter is e, run encrypt method
			if (c[0] == 'e')
			{
				// Get a secret message from the user.
				Console.WriteLine("Enter a message to encrypt:");
				String message = Console.ReadLine();

				// Get the KEY with which to encrypt this secret message.  This must be an INTEGER. (can be positive or negative) 
				Console.Write("Enter the KEY to encrypt this message with >> ");
				int key = Convert.ToInt32(Console.ReadLine());

				// Make a place to store the encrypted message while I'm working on building it.
				String encryptedMessage = "";

				// Iterate through the message that the user typed one character at a time.
				foreach (char ch in message.ToCharArray())
				{
					// If this is a lowercase letter, encrypt the character using the lowercase alphabet string.
					// IndexOf returns -1 if the character does not appear in the string!
					if (alphabet.IndexOf(ch) >= 0)
					{

						// stick that encrypted character on the end of the encryptedMessage.
						encryptedMessage += EncryptCharacter(alphabet, ch, key);
					}

					// Do the same thing, if the character is a Capital letter.
					else if (ALPHABET.IndexOf(ch) >= 0)
					{
						encryptedMessage += EncryptCharacter(ALPHABET, ch, key);
					}

					// If the character is neither a capital nor lowercase, then ignore it and don't try to encrypt. (i.e. a space or punctuation)
					else
					{
						encryptedMessage += ch;
					}


				}


				// Print the encrypted message!
				Console.WriteLine("_________________________________________________");
				Console.WriteLine("Your encrypted message is:\n\n{0}", encryptedMessage);
				Console.ReadKey();

			}
			else if (c[0] == 'd')
			{

				// Message input from the user to decrypt
				Console.WriteLine("Enter a message to decrypt:");
				String message = Console.ReadLine();

				// Integer key to decrypt phrase
				Console.Write("Enter the KEY this message was encrypted with >> ");
				int key = Convert.ToInt32(Console.ReadLine());

				// Store the message
				String decryptedMessage = "";

				// Iterate through the message that the user typed one character at a time.
				foreach (char ch in message.ToCharArray())
				{
					// If this is a lowercase letter, encrypt the character using the lowercase alphabet string.
					// IndexOf returns -1 if the character does not appear in the string!
					if (alphabet.IndexOf(ch) >= 0)
					{

						// Stick that encrypted character on the end of the encryptedMessage.
						decryptedMessage += DecryptCharacter(alphabet, ch, key);
					}

					// Do the same thing, if the character is a Capital letter.
					else if (ALPHABET.IndexOf(ch) >= 0)
					{
						decryptedMessage += DecryptCharacter(ALPHABET, ch, key);
					}

					// If the character is neither a capital nor lowercase, then ignore it and don't try to encrypt.
					else
					{
						decryptedMessage += ch;
					}
				}


				// Print the encrypted message!
				Console.WriteLine("_________________________________________________");
				Console.WriteLine("Your decrypted message is:\n\n{0}", decryptedMessage);
				Console.ReadKey();
			}


		}
	}
}

