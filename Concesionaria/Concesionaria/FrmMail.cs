using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Concesionaria
{
    public partial class FrmMail : FormularioBase 
    {
        public FrmMail()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string Desde = "pablomartinzabala2@gmail.com";
            string Para = "pablozabala.jakemate@gmail.com";
            string Asunto = "Prueba de mensaje";
            string Cuerpo = "Este es el cuerpo del mensaje";
            System.Net.Mail.MailMessage msj = new System.Net.Mail.MailMessage();
            msj.To.Add(Para);
            msj.Subject = Asunto;
            msj.SubjectEncoding = System.Text.Encoding.UTF8;
            msj.Body = Cuerpo;
            msj.BodyEncoding = System.Text.Encoding.UTF8;
            msj.IsBodyHtml = true;
            msj.From = new System.Net.Mail.MailAddress(Desde);

            System.Net.Mail.SmtpClient  Cliente = new System.Net.Mail.SmtpClient();
           // System.Net.Mail.SmtpClient Cliente;
            Cliente.Credentials = new System.Net.NetworkCredential(Desde,"villaallende");
        //    Cliente.Port = 587;
          //  Cliente.Port = 465;
            Cliente.EnableSsl = false;
            Cliente.Host = "smtp.gmail.com";

            Cliente.Send(msj);

             
        }
    }
}
