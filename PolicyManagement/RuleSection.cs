﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.PolicyManagement
{
    public class RuleSection
    {
        private string header1, footer1;
        private string header2, footer2;
        private string any;
        private string content;
        private Dictionary.Section sectionType;
        private bool isVoid;
        private string pid;

        const string ANYSUBJECT = "<AnySubject />";
        const string ANYRESOURCE = "<AnyResource />";
        const string ANYACTION = "<AnyAction />"; 

        public RuleSection(Dictionary.Section sectionType, string pid, bool isVoid)
        {
            this.isVoid = isVoid;
            this.pid = pid;
            this.sectionType = sectionType;

            if (sectionType == Dictionary.Section.SUBJECTS)
            {
                header1 = "<Subjects>";
                footer1 = "</Subjects>";
                header2 = "<Subject>";
                footer2 = "</Subject>";
                any = "<AnySubject />";
                
            }
            else if (sectionType == Dictionary.Section.RESOURCES)
            {
                header1 = "<Resources>";
                footer1 = "</Resources>";
                header2 = "<Resource>";
                footer2 = "</Resource>";
                any = "<AnyResource />";
            }
            else
            {
                header1 = "<Actions>";
                footer1 = "</Actions>";
                header2 = "<Action>";
                footer2 = "</Action>";
                any = "<AnyAction />";
                content = "<ActionMatch MatchId=\"" + Dictionary.STRING_EQ + "\">" + "\n"
                    + "<AttributeValue DataType=\"" + Dictionary.STRING_TYPE + "\">" + Dictionary.ID_GETDATASTREAMDISSEMINATION + "</AttributeValue>" + "\n"
                    + "<ActionAttributeDesignator DataType=\"" + Dictionary.STRING_TYPE + "\" AttributeId=\"" + Dictionary.ID + "\" />" + "\n"
                    + "</ActionMatch>" + "\n";
            }
        }

        public string Xml
        {
            get
            {
                string xml = header1 + "\n";

                if (this.isVoid)
                {
                    xml += any + "\n";
                }
                else
                {
                    xml += header2 + "\n";
                    xml += content;
                    xml += footer2 + "\n";
                }

                xml += footer1 + "\n";

                return xml;
            }
        }


    }
}
