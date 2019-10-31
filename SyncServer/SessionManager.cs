using SyncServer;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SyncServer
{

    public class SessionManager : ISessionManager
    {
        private List<Guid> sessionTokens = new List<Guid>();

        public void SaveSession(Guid tokenID)
        {
            sessionTokens.Add(tokenID);
        }

        public bool VerifySession(Guid tokenID)
        {

            foreach (Guid Id in sessionTokens)
            {
                if (Id.Equals(tokenID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
