using CollegeLMS.FileServer;
using CollegeLMS.DatabaseServer;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace CollegeLMS{
    public partial class startUpCheck:Form{
        public startUpCheck(){
            InitializeComponent();
            tim.Start();
        }

        DatabaseServerClient server = new DatabaseServerClient();//Server Connection
        FileControlClient fileServer = new FileControlClient();//File Server Connection
        GUIEffects effects = new GUIEffects();//GUI Effects

        int validServers = 0;//Online Server Count

        private void checkServer(Panel pnl, Label lbl, String name, String path){//Check Server Availability
            try{
                WebRequest request = WebRequest.Create(path);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if(response != null || response.StatusCode == HttpStatusCode.OK){
                    pnl.BackColor = Color.LightSeaGreen;
                    lbl.Text = name + " is Online";
                }
                request.Abort();
                response.Dispose();
                if(validServers < 2)
                    validServers++;
            }catch(Exception ex){
                pnl.BackColor = Color.FromArgb(170, 3, 5);
                lbl.Text = name + " is Offline";
                if(validServers > 0)
                    validServers--;
            }
        }

        private void tim_Tick(object sender, EventArgs e){
            checkServer(pnlDatabase, lblDatabse, "Database Server", server.Endpoint.Address.ToString());//Checks Database Server
            checkServer(pnlFile, lblFile, "File Server", fileServer.Endpoint.Address.ToString().Replace("Library",""));//Checks File Server
            if(validServers == 2) {
                tim.Stop();
                effects.showThisHide(this, new signIn());
            }
        }
    }
}
