using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoorControllerCS
{
    public partial class frmMain : Form
    {
        private

        string InterfaceDefinitionFileName = "DoorControllerInterfaceDefinition.xml";
        string XmlInterface = "";
        StaXCommsLib.StaxCommunications StaXComms;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!(System.IO.File.Exists(InterfaceDefinitionFileName)))
            {
                //MsgBox("Cannot find the interface definition file (" & InterfaceDefinitionFileName & ")", MsgBoxStyle.Critical, "Can't Find File")
                //Console.WriteLine("{0} does not exist.", InterfaceDefinitionFileName)
            }
            else
            {
                System.IO.StreamReader sr = System.IO.File.OpenText(InterfaceDefinitionFileName);
                string input;
                while ((input = sr.ReadLine()) != null) 
                {
                    XmlInterface+= input;
                    input = sr.ReadLine();
                }   //  end while
                Console.WriteLine("The end of the stream has been reached.");
                sr.Close();

                StaXComms = new StaXCommsLib.StaxCommunications();

            }   //  if file exists
        }   //  form load
    }   //  class declaration
}   //  namespace