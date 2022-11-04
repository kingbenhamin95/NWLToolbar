#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

#endregion

namespace NWLToolbar
{
    internal class NWLToolbar : IExternalApplication
    {
        static void AddRibbonPanel(UIControlledApplication application)
        {
            string tabName1 = "NWLToolbar";
            application.CreateRibbonTab(tabName1);

            RibbonPanel curPanel = application.CreateRibbonPanel(tabName1, "Tools");
            RibbonPanel curPanel1 = application.CreateRibbonPanel(tabName1, "Resources");

            string curAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string curAssemblyPath = System.IO.Path.GetDirectoryName(curAssembly);

            PushButtonData pbd1 = new PushButtonData("Sheets to Uppercase", "All Sheets" + "\r" + "To Uppercase", curAssembly, "NWLToolbar.CapitalizeSheets");
            PushButtonData pbd2 = new PushButtonData("Teams Link", "BIM Tools" + "\r" + "& Resources", curAssembly, "NWLToolbar.TeamsLink");

            pbd1.LargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(curAssemblyPath, "aA.png")));
            pbd2.LargeImage = new BitmapImage(new Uri(System.IO.Path.Combine(curAssemblyPath, "teams.png")));

            PushButton pb1 = (PushButton)curPanel.AddItem(pbd1);
            PushButton pb2 = (PushButton)curPanel1.AddItem(pbd2);
            
        }
        public Result OnStartup(UIControlledApplication a)
        {

            AddRibbonPanel(a);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
