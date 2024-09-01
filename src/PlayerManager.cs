using Akequ.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Additional
{
    public class ClientManager : Akequ.Base.Room
    {
        public void GiveItem(string text)
        {
            SendToServer("Kick_Server", text);
        }

        private void GiveItem_Server(string text, Mirror.NetworkConnectionToClient conn)
        {
            PlayerUtilities.GetServerPlayer(conn).GiveItem(text);
        }

        public void Kick(string text)
        {
            SendToServer("Kick_Server", text);
        }

        private void Kick_Server(string text, Mirror.NetworkConnectionToClient conn)
        {
            PlayerUtilities.GetServerPlayer(conn).KickMessage(text);
        }
    }
}
