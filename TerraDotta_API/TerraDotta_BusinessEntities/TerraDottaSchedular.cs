using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraDotta_BusinessEntities
{
    public class TerraDottaSchedular
    {
        public string TDUserID { get; set; }
        public string SEVIS_First_Name { get; set; }
        public string SEVIS_Last_Name { get; set; }
        public string Date_of_Birth { get; set; }
        public string Gender { get; set; }
        public string Hispanic_or_Latino { get; set; }
        public string Applicant_Race { get; set; }
        public string EMAIL { get; set; }
        public string VISA { get; set; }
        public string City_of_Birth { get; set; }
        public string Country_of_Birth { get; set; }
        public string Country_of_Citizenship { get; set; }
        public string Marital_Status { get; set; }
        public string Permanent_Street_Address { get; set; }
        public string Permanent_City { get; set; }
        public string Permanent_Province_State_Territory { get; set; }
        public string Permanent_Postal_Code { get; set; }
        public string Permanent_Country { get; set; }
        public string US_Phone_Number { get; set; }
        public string US_Street_Address_Line_1 { get; set; }
        public string US_Street_Address_Line_2 { get; set; }
        public string US_City { get; set; }
        public string US_State { get; set; }
        public string US_Postal_Code { get; set; }
        public string Program_Options { get; set; }
        public string Program_of_Study { get; set; }
        public string Degree_Certificate_Type { get; set; }
        public string School_Name { get; set; }
        public string Graduation_Date { get; set; }
        public string College_or_University_Name_1 { get; set; }
        public string Start_Date_College_or_University_1 { get; set; }
        public string End_Date_College_or_University_1 { get; set; }
        public string Graduation_Date_from_College_or_University_1 { get; set; }
        public string Degree_Completed_at_College_or_University_1 { get; set; }
        public string College_or_University_Name_2 { get; set; }
        public string Start_Date_College_or_University_2 { get; set; }
        public string End_Date_College_or_University_2 { get; set; }
        public string Graduation_Date_from_College_or_University_2 { get; set; }
        public string Degree_Completed_at_College_or_University_2 { get; set; }
        public string College_or_University_Name_3 { get; set; }
        public string Start_Date_College_or_University_3 { get; set; }
        public string End_Date_College_or_University_3 { get; set; }
        public string Graduation_Date_from_College_or_University_3 { get; set; }
        public string Degree_Completed_at_College_or_University_3 { get; set; }
        public string College_or_University_Name_4 { get; set; }
        public string Start_Date_College_or_University_4 { get; set; }
        public string End_Date_College_or_University_4 { get; set; }
        public string Graduation_Date_from_College_or_University_4 { get; set; }
        public string Degree_Completed_at_College_or_University_4 { get; set; }
        public string NSHE_Nevada_System_of_Higher_Education_Student_Identification_Number { get; set; }
        public string Requested_Term_of_Admission { get; set; }
        public string Application_Identifier { get; set; }
        public string AdmitType { get; set; }
    }
    public class DataValidation
    {
        public bool isWrongData { get; set; }
        public List<string> Reason { get; set; }
        public List<string> wrongData { get; set; }
    }
}
