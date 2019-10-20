using System;
using System.Collections;
using System.Collections.Generic;

public static class SessionManager
{
    private static Guid token;
    private static List<Guid> sessionTokens = new List<Guid>();

    public static void SaveSession(Guid tokenID)
	{
        sessionTokens.Add(tokenID);
	}

    public static bool VerifySession(Guid tokenID)
    {

        foreach (Guid Id in sessionTokens)
        {
            if (Id.Equals(token))
            {
                return true;
            }
        }
    return false;
    }
}
