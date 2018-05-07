﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSSA.Utils
{
    class Session
    {
        // USER_ID = -1 means Nobody logins int yet.
        //Whenever a User logs in we will update this variable..
        // We will maintain a Session for login user...
        // We will set this equal to -1 when user logs out..
        public static int USER_ID = -1;
    }
}
