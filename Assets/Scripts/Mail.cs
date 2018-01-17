using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Mail : MonoBehaviour {

	public InputField nameUser;
	public InputField email;
	public Text error;


	// Use this for initialization
	public void SendMailStart () {
		StartCoroutine (SendMail());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator SendMail() {
		yield return new WaitForSeconds (0.0f);

		if (nameUser.text == "" || email.text == "") {
			error.text = "Please fill in all the fields";
		}


		MailMessage mail = new MailMessage ();

		mail.From = new MailAddress ("makeamapum@gmail.com"); 
		mail.To.Add (email.text);
		mail.Subject = "Make a Map";
		mail.Body = "Hi " + nameUser.text + ", in this email you will find attached the map you created in Make a Map.\nHave a great day.\nBest,\nMake a Map Developer"; //Change this!!


		Attachment attachment = new Attachment ("Assets/ScreenPics/MapPic.png");
		mail.Attachments.Add (attachment);

		SmtpClient	smtpServer = new SmtpClient ("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential ("makeamapum@gmail.com", "universityofmiami") as ICredentialsByHost; 
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = delegate  (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors SslPolicyErrors ) {
			return true;
		};
		smtpServer.Send (mail);
		error.text = "Mail sent succesfully";
		StartCoroutine (NextLevel());
	}


	public IEnumerator NextLevel() {
		yield return new WaitForSeconds (1.0f); 
		SceneManager.LoadScene ("Video");
	}



}
