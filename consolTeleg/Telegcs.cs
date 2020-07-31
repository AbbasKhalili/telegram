using System;
using System.IO;
using System.Linq;
using TeleSharp.TL;
using TeleSharp.TL.Auth;
using TLSharp.Core;
using TLSharp.Core.Network;

namespace consolTeleg
{
    public class Telegcs
    {

        private const int ApiId = 1469590000811;
        const string ApiHash = "b0dd0731c440911a360ca15ad88b14ca";

        private readonly TelegramClient _tele;

        public Telegcs()
        {
            _tele = new TelegramClient(ApiId, ApiHash,new FileSessionStore());
        }
        
        public void Connect()
        {
            _tele.ConnectAsync().Wait();
        }

        public async void Authentication()
        {
            if (!File.Exists("session.dat"))
            {
                var hash = await _tele.SendCodeRequestAsync("+989308110000");
                var code = "w5070"; // you can change code in debugger
                var user = await _tele.MakeAuthAsync("+989308110000", hash, code);
            }
        }

        public async void SendMessage(string msg)
        {
            var result = await _tele.GetContactsAsync();

            //find recipient in contacts
            var user = result.users.lists
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.phone == "989905090000");

            //send message
            await _tele.SendMessageAsync(new TLInputPeerUser() { user_id = user.id }, msg);
        }

    }
}
