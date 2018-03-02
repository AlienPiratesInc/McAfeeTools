using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mEpoApi;

namespace APISystemTagger
{
    class PublicVariables
    {
        public static string _fullProps = "True";
        public static string _allSuperAgents = "False";
        public static string _fullPolicyUpdate = "True";
        public static string _allAgentHandlers = "True";

        public static string _randomizeMinutes = "0";
        public static string _attempts = "0";
        public static string _retrySeconds = "60";
        public static string _abortMinutes = "20";
        public static string _batchFileSize = "25";

        public static McAfeeApi mcafeeApi;
    }
}
