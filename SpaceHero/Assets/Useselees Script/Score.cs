using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class Score 
{
	public int score1;
	public int score2;
	public int score3;
	public int score4;
	public int score5;

	public Score()
	{
		score1 = 25000;
		score2 = 20000;
		score3 = 15000;
		score4 = 10000;
		score5 = 5000;

	}

	public void save (string path)
	{
		var serializer = new XmlSerializer (typeof(Score));
		var stream = new FileStream (path, FileMode.Create);
		var streamWriter = new StreamWriter (stream, System.Text.Encoding.UTF8);

		serializer.Serialize (streamWriter, this);
		streamWriter.Close ();
	}

	public static Score Load(string path)
	{
		var serializer = new XmlSerializer (typeof(Score));
		using (var stream = new FileStream (path, FileMode.Open)) 
		{
			return serializer.Deserialize (stream)as Score;
		}
	}

	public void newScore(int point)
	{
		int temp1 = score1;
		int temp2 = score2;
		int temp3 = score3;
		int temp4 = score4;

		if (point >= score1) {
			score1 = point;
			score2 = temp1;
			score3 = temp2;
			score4 = temp3;
			score5 = temp4;
		
		} 
		else if (point >= score2)
		{
			score2 = point;
			score3 = temp2;
			score4 = temp3;
			score5 = temp4;
		}
		else if (point >= score3)
		{
			score3 = point;
			score4 = temp3;
			score5 = temp4;
		}
		else if (point >= score4)
		{
			score4 = point;
			score5 = temp4;
		}
		else if (point >= score5)
		{
			score5 = point;
		}

	}



}
