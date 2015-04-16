using System;
using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(
    typeof(BusyBongo.Web.App_Start.DurandalConfig), "PreStart")]

namespace BusyBongo.Web.App_Start
{
    public static class DurandalConfig
    {
        public static void PreStart()
        {
            // Add your start logic here
            
        }
    }
}