using OtomotivServisSatis.Entities;
using System.Net;
using System.Net.Mail;

namespace OtomotivServisSatis.WebUI.Utils
{
    public class MailHelper
    {

        //Metoda dışarıdan parametre verilecek musteri bilgileri
        public static async Task SendMailAsync(Musteri musteri)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com",587); //Email göndermek için gerekli bir yapi
            smtpClient.Credentials = new NetworkCredential("emailkullaniciad","emailsifre");
            smtpClient.EnableSsl = false;

            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("info@siteadi.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"Mail Bilgileri <hr/> Ad Soyad: {musteri.Adi} {musteri.Soyadi} <hr/>" +
                $"İlgilendiğiniz Araç Id: {musteri.AracId} <hr/> Email: {musteri.Email} <hr/> Telefon: {musteri.Telefon}<hr/> Notlar: {musteri.Notlar} ";
            message.IsBodyHtml = true;
            //smtpClient.Send(message);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
