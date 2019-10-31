using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncServer
{
    public interface ISessionManager
    {
        void SaveSession(Guid tokenID);
        bool VerifySession(Guid tokenID);
    }
}
