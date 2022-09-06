using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerraDotta_BusinessEntities;
using TerraDotta_Manager.TerraDottaSchedularManager;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TerraDotta_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerraDottaSchedularController : ControllerBase
    {
        private ITerraDottaSchedularManager _terradottaschedular;
        private IWebHostEnvironment _hostEnvironment;
        public TerraDottaSchedularController(ITerraDottaSchedularManager terradottaschedular, IWebHostEnvironment environment)
        {
            this._terradottaschedular = terradottaschedular;
            _hostEnvironment = environment;
        }
        [HttpGet]
        [Route("TestAPI")]
        public IActionResult Test()
        {
            List<TerraDottaSchedular> csv = new List<TerraDottaSchedular>();
            var lines = System.IO.File.ReadAllLines(@"D:\_Project\TerraDotta\TerraDotta_API\CSN_ISSS_RTDTexport08-17-2022_214219.txt");
            List<string> Reason = new List<string>();

            var Header = lines[0].Split(',');
            if (Header.Length != 52)
            {
                Reason.Add("Header part is missing");
            }
            if (lines[0].Split(',')[0].Replace('"', ' ').Trim() != "TD User ID")
            {
                Reason.Add("TD User ID is missing");
            }
            if (lines[0].Split(',')[1].Replace('"', ' ').Trim() != "SEVIS First Name")
            {
                Reason.Add("SEVIS First Name is missing");
            }
            if (lines[0].Split(',')[2].Replace('"', ' ').Trim() != "SEVIS Last Name")
            {
                Reason.Add("SEVIS Last Name is missing");
            }
            if (lines[0].Split(',')[3].Replace('"', ' ').Trim() != "Date of Birth")
            {
                Reason.Add("Date of Birth is missing");
            }
            if (lines[0].Split(',')[4].Replace('"', ' ').Trim() != "Gender")
            {
                Reason.Add("Gender is missing");
            }
            if (lines[0].Split(',')[5].Replace('"', ' ').Trim() != "Hispanic or Latino")
            {
                Reason.Add("Hispanic or Latino is missing");
            }
            if (lines[0].Split(',')[6].Replace('"', ' ').Trim() != "Applicant Race")
            {
                Reason.Add("Applicant Race is missing");
            }
            if (lines[0].Split(',')[7].Replace('"', ' ').Trim() != "EMAIL")
            {
                Reason.Add("EMAIL is missing");
            }
            if (lines[0].Split(',')[8].Replace('"', ' ').Trim() != "VISA")
            {
                Reason.Add("VISA is missing");
            }
            if (lines[0].Split(',')[9].Replace('"', ' ').Trim() != "City of Birth")
            {
                Reason.Add("City of Birth is missing");
            }
            if (lines[0].Split(',')[10].Replace('"', ' ').Trim() != "Country of Birth")
            {
                Reason.Add("Country of Birth is missing");
            }
            if (lines[0].Split(',')[11].Replace('"', ' ').Trim() != "Country of Citizenship")
            {
                Reason.Add("Country of Citizenship is missing");
            }
            if (lines[0].Split(',')[12].Replace('"', ' ').Trim() != "Marital Status")
            {
                Reason.Add("Marital Status is missing");
            }
            if (lines[0].Split(',')[13].Replace('"', ' ').Trim() != "Permanent Street Address")
            {
                Reason.Add("Permanent Street Address is missing");
            }
            if (lines[0].Split(',')[14].Replace('"', ' ').Trim() != "Permanent City")
            {
                Reason.Add("Permanent City is missing");
            }
            if (lines[0].Split(',')[15].Replace('"', ' ').Trim() != "Permanent Province-State-Territory")
            {
                Reason.Add("Permanent Province-State-Territory is missing");
            }
            if (lines[0].Split(',')[16].Replace('"', ' ').Trim() != "Permanent Postal Code")
            {
                Reason.Add("Permanent Postal Code is missing");
            }
            if (lines[0].Split(',')[17].Replace('"', ' ').Trim() != "Permanent Country")
            {
                Reason.Add("Permanent Country is missing");
            }
            if (lines[0].Split(',')[18].Replace('"', ' ').Trim() != "US Phone Number")
            {
                Reason.Add("US Phone Number is missing");
            }
            if (lines[0].Split(',')[19].Replace('"', ' ').Trim() != "US Street Address Line 1")
            {
                Reason.Add("US Street Address Line 1 is missing");
            }
            if (lines[0].Split(',')[20].Replace('"', ' ').Trim() != "US Street Address Line 2")
            {
                Reason.Add("US Street Address Line 2 is missing");
            }
            if (lines[0].Split(',')[21].Replace('"', ' ').Trim() != "US City")
            {
                Reason.Add("US City is missing");
            }
            if (lines[0].Split(',')[22].Replace('"', ' ').Trim() != "US State")
            {
                Reason.Add("US State is missing");
            }
            if (lines[0].Split(',')[23].Replace('"', ' ').Trim() != "US Postal Code")
            {
                Reason.Add("US Postal Code is missing");
            }
            if (lines[0].Split(',')[24].Replace('"', ' ').Trim() != "Program Options")
            {
                Reason.Add("Program Options is missing");
            }
            if (lines[0].Split(',')[25].Replace('"', ' ').Trim() != "Program of Study")
            {
                Reason.Add("Program of Study is missing");
            }
            if (lines[0].Split(',')[26].Replace('"', ' ').Trim() != "Degree-Certificate Type")
            {
                Reason.Add("Degree-Certificate Type is missing");
            }
            if (lines[0].Split(',')[27].Replace('"', ' ').Trim() != "School Name")
            {
                Reason.Add("School Name is missing");
            }
            if (lines[0].Split(',')[28].Replace('"', ' ').Trim() != "Graduation Date")
            {
                Reason.Add("Graduation Date is missing");
            }
            if (lines[0].Split(',')[29].Replace('"', ' ').Trim() != "College or University Name-1")
            {
                Reason.Add("College or University Name-1 is missing");
            }
            if (lines[0].Split(',')[30].Replace('"', ' ').Trim() != "Start Date College or University-1")
            {
                Reason.Add("Start Date College or University-1 is missing");
            }
            if (lines[0].Split(',')[31].Replace('"', ' ').Trim() != "End Date College or University-1")
            {
                Reason.Add("End Date College or University-1 is missing");
            }
            if (lines[0].Split(',')[32].Replace('"', ' ').Trim() != "Graduation Date from College or University-1")
            {
                Reason.Add("Graduation Date from College or University-1 is missing");
            }
            if (lines[0].Split(',')[33].Replace('"', ' ').Trim() != "Degree Completed at College or University-1")
            {
                Reason.Add("Degree Completed at College or University-1 is missing");
            }
            if (lines[0].Split(',')[34].Replace('"', ' ').Trim() != "College or University Name-2")
            {
                Reason.Add("College or University Name-2 is missing");
            }
            if (lines[0].Split(',')[35].Replace('"', ' ').Trim() != "Start Date College or University-2")
            {
                Reason.Add("Start Date College or University-2 is missing");
            }
            if (lines[0].Split(',')[36].Replace('"', ' ').Trim() != "End Date College or University-2")
            {
                Reason.Add("End Date College or University-2 is missing");
            }
            if (lines[0].Split(',')[37].Replace('"', ' ').Trim() != "Graduation Date from College or University-2")
            {
                Reason.Add("Graduation Date from College or University-2 is missing");
            }
            if (lines[0].Split(',')[38].Replace('"', ' ').Trim() != "Degree Completed at College or University-2")
            {
                Reason.Add("Degree Completed at College or University-2 is missing");
            }
            if (lines[0].Split(',')[39].Replace('"', ' ').Trim() != "College or University Name-3")
            {
                Reason.Add("College or University Name-3 is missing");
            }
            if (lines[0].Split(',')[40].Replace('"', ' ').Trim() != "Start Date College or University-3")
            {
                Reason.Add("Start Date College or University-3 is missing");
            }
            if (lines[0].Split(',')[41].Replace('"', ' ').Trim() != "End Date College or University-3")
            {
                Reason.Add("End Date College or University-3 is missing");
            }
            if (lines[0].Split(',')[42].Replace('"', ' ').Trim() != "Graduation Date from College or University-3")
            {
                Reason.Add("Graduation Date from College or University-3 is missing");
            }
            if (lines[0].Split(',')[43].Replace('"', ' ').Trim() != "Degree Completed at College or University-3")
            {
                Reason.Add("Degree Completed at College or University-3 is missing");
            }
            if (lines[0].Split(',')[44].Replace('"', ' ').Trim() != "College or University Name-4")
            {
                Reason.Add("College or University Name-4 is missing");
            }
            if (lines[0].Split(',')[45].Replace('"', ' ').Trim() != "Start Date College or University-4")
            {
                Reason.Add("Start Date College or University-4 is missing");
            }
            if (lines[0].Split(',')[46].Replace('"', ' ').Trim() != "End Date College or University-4")
            {
                Reason.Add("End Date College or University-4 is missing");
            }
            if (lines[0].Split(',')[47].Replace('"', ' ').Trim() != "Graduation Date from College or University-4")
            {
                Reason.Add("Graduation Date from College or University-4 is missing");
            }
            if (lines[0].Split(',')[48].Replace('"', ' ').Trim() != "Degree Completed at College or University-4")
            {
                Reason.Add("Degree Completed at College or University-4 is missing");
            }
            if (lines[0].Split(',')[49].Replace('"', ' ').Trim() != "NSHE-Nevada System of Higher Education Student Identification Number")
            {
                Reason.Add("NSHE-Nevada System of Higher Education Student Identification Number is missing");
            }
            if (lines[0].Split(',')[50].Replace('"', ' ').Trim() != "Requested Term of Admission")
            {
                Reason.Add("Requested Term of Admission is missing");
            }
            if (lines[0].Split(',')[51].Replace('"', ' ').Trim() != "Application Identifier")
            {
                Reason.Add("Application Identifier is missing");
            }
            int n;
            
            string sourcePath = @"Templates/TerraDottaTemplates.xlsx";

            string targetPath = @"Excel/" + DateTime.Now.ToString("MM/dd/yyyyHHmmssffff");
            string filePath = Path.Combine(this._hostEnvironment.WebRootPath, sourcePath);
            string destination = string.Empty;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(this._hostEnvironment.WebRootPath, targetPath));
                var filename = "TerraDotta" + DateTime.Now.ToString("MM/dd/yyyyHHmmssffff") + ".xlsx";
                var source = Path.Combine(this._hostEnvironment.WebRootPath, sourcePath);
                destination = Path.Combine(this._hostEnvironment.WebRootPath, targetPath, filename);
                System.IO.File.Copy(Path.Combine(this._hostEnvironment.WebRootPath, source), Path.Combine(this._hostEnvironment.WebRootPath, destination), true);
            }
            List<string> wrongData = new List<string>();
            FileInfo fi = new FileInfo(destination);
            using (ExcelPackage Package = new ExcelPackage(fi))
            {
                var currentsheet = Package.Workbook.Worksheets;
                var Sheet1 = currentsheet["Sheet1"];
                var RowCount = 2;
                for (int i = 1; i < lines.Count(); i++)
                {
                    bool isWrongData = false;
                    TerraDottaSchedular obj = new TerraDottaSchedular();
                   
                    obj.TDUserID = lines[i].Split(',')[0].Replace('"', ' ').Trim();
                    var TDUSERID_Validation = TDUSERID(obj.TDUserID, RowCount);
                    if(TDUSERID_Validation.wrongData.Count() > 0)
                    {
                        isWrongData = TDUSERID_Validation.isWrongData;
                        wrongData.AddRange(TDUSERID_Validation.wrongData.ToList());
                        Reason.AddRange(TDUSERID_Validation.Reason.ToList());
                    }

                    obj.SEVIS_First_Name = lines[i].Split(',')[1].Replace('"', ' ').Trim();
                    var First_Name = SEVIS_First_Name(obj.SEVIS_First_Name, RowCount);
                    if(First_Name.wrongData.Count > 0)
                    {
                        isWrongData = First_Name.isWrongData;
                        wrongData.AddRange(First_Name.wrongData.ToList());
                        Reason.AddRange(First_Name.Reason.ToList());
                    }

                    obj.SEVIS_Last_Name = lines[i].Split(',')[2].Replace('"', ' ').Trim();
                    var Last_Name = SEVIS_Last_Name(obj.SEVIS_Last_Name, RowCount);
                    if(Last_Name.wrongData.Count > 0)
                    {
                        isWrongData = Last_Name.isWrongData;
                        wrongData.AddRange(Last_Name.wrongData.ToList());
                        Reason.AddRange(Last_Name.Reason.ToList());
                    }

                    obj.Date_of_Birth = lines[i].Split(',')[3].Replace('"', ' ').Trim();
                    var DOB = Date_of_Birth(obj.Date_of_Birth, RowCount);
                    if(DOB.wrongData.Count > 0)
                    {
                        isWrongData = DOB.isWrongData;
                        wrongData.AddRange(DOB.wrongData.ToList());
                        Reason.AddRange(DOB.Reason.ToList());
                    }

                    obj.Gender = lines[i].Split(',')[4].Replace('"', ' ').Trim();
                    var gen = Gender(obj.Gender, RowCount);
                    if(gen.wrongData.Count > 0)
                    {
                        isWrongData = gen.isWrongData;
                        wrongData.AddRange(gen.wrongData.ToList());
                        Reason.AddRange(gen.Reason.ToList());
                    }

                    obj.Hispanic_or_Latino = lines[i].Split(',')[5].Replace('"', ' ').Trim();
                    var His = HispanicOrLatino(obj.Hispanic_or_Latino, RowCount);
                    if (His.wrongData.Count > 0)
                    {
                        isWrongData = His.isWrongData;
                        wrongData.AddRange(His.wrongData.ToList());
                        Reason.AddRange(DOB.Reason.ToList());
                    }

                    obj.Applicant_Race = lines[i].Split(',')[6].Replace('"', ' ').Trim();
                    var App = ApplicantRace(obj.Applicant_Race, RowCount);
                    if (App.wrongData.Count > 0)
                    {
                        isWrongData = App.isWrongData;
                        wrongData.AddRange(App.wrongData.ToList());
                        Reason.AddRange(App.Reason.ToList());
                    }

                    obj.EMAIL = lines[i].Split(',')[7].Replace('"', ' ').Trim();
                    var email = EmailValidation(obj.EMAIL, RowCount);
                    if (email.wrongData.Count > 0)
                    {
                        isWrongData = email.isWrongData;
                        wrongData.AddRange(email.wrongData.ToList());
                        Reason.AddRange(email.Reason.ToList());
                    }

                    obj.VISA = lines[i].Split(',')[8].Replace('"', ' ').Trim();
                    var visa = VisaValidation(obj.VISA, RowCount);
                    if (visa.wrongData.Count > 0)
                    {
                        isWrongData = visa.isWrongData;
                        wrongData.AddRange(visa.wrongData.ToList());
                        Reason.AddRange(visa.Reason.ToList());
                    }


                    if (isWrongData)
                    {
                        Sheet1.SetValue(RowCount, 1, lines[i].Split(',')[0].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 2, lines[i].Split(',')[1].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 3, lines[i].Split(',')[2].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 4, lines[i].Split(',')[3].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 5, lines[i].Split(',')[4].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 6, lines[i].Split(',')[5].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 7, lines[i].Split(',')[6].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 8, lines[i].Split(',')[7].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 9, lines[i].Split(',')[8].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 10, lines[i].Split(',')[9].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 11, lines[i].Split(',')[10].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 12, lines[i].Split(',')[11].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 13, lines[i].Split(',')[12].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 14, lines[i].Split(',')[13].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 15, lines[i].Split(',')[14].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 16, lines[i].Split(',')[15].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 17, lines[i].Split(',')[16].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 18, lines[i].Split(',')[17].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 19, lines[i].Split(',')[18].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 20, lines[i].Split(',')[19].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 21, lines[i].Split(',')[20].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 22, lines[i].Split(',')[21].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 23, lines[i].Split(',')[22].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 24, lines[i].Split(',')[23].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 25, lines[i].Split(',')[24].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 26, lines[i].Split(',')[25].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 27, lines[i].Split(',')[26].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 28, lines[i].Split(',')[27].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 29, lines[i].Split(',')[28].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 30, lines[i].Split(',')[29].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 31, lines[i].Split(',')[30].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 32, lines[i].Split(',')[31].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 33, lines[i].Split(',')[32].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 34, lines[i].Split(',')[33].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 35, lines[i].Split(',')[34].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 36, lines[i].Split(',')[35].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 37, lines[i].Split(',')[36].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 38, lines[i].Split(',')[37].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 39, lines[i].Split(',')[38].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 40, lines[i].Split(',')[39].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 41, lines[i].Split(',')[40].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 42, lines[i].Split(',')[41].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 43, lines[i].Split(',')[42].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 44, lines[i].Split(',')[43].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 45, lines[i].Split(',')[44].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 46, lines[i].Split(',')[45].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 47, lines[i].Split(',')[46].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 48, lines[i].Split(',')[47].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 49, lines[i].Split(',')[48].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 50, lines[i].Split(',')[49].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 51, lines[i].Split(',')[50].Replace('"', ' ').Trim());
                        Sheet1.SetValue(RowCount, 52, lines[i].Split(',')[51].Replace('"', ' ').Trim());
                        RowCount++;
                    }
                    Package.DoAdjustDrawings = false;
                    Package.Save();
                }
                foreach (var item in wrongData)
                {
                    ExcelPackage ExcelPkg = new ExcelPackage();
                    using (ExcelPackage p = new ExcelPackage(fi))
                    {
                        {
                            string[] words = item.Split('-');
                            int count1 = Convert.ToInt32(words[0]);
                            int cname = Convert.ToInt32(words[1]);
                            ExcelWorksheet ws = p.Workbook.Worksheets.First();
                            ExcelRange cell = ws.Cells[count1, cname] as ExcelRange;
                            ws.Cells[count1, cname].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Cells[count1, cname].Style.Fill.BackgroundColor.SetColor(Color.Red);
                            p.Save();
                        }
                    }
                }
            }
            byte[] files = System.IO.File.ReadAllBytes(destination);
            Stream stream = new MemoryStream(files);
            var excelname = System.IO.Path.GetFileName(destination);
            var mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(stream, mimeType, excelname);
        }
        public static DataValidation TDUSERID(string TDUserID,int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            if (!String.IsNullOrEmpty(TDUserID) && !String.IsNullOrWhiteSpace(TDUserID))
            {
                obj.isWrongData = false;
                bool isNumeric = int.TryParse(TDUserID, out _);
                if (isNumeric == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 1 + "TD User ID value is incorrect because of the is not in numeric format" + TDUserID);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 1));
                }
                if (TDUserID.Length != 5)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 1 + "TD User ID value is incorrect because of the length is" + TDUserID.Length);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 1));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("TD User ID is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 1));
            }
            obj.Reason = ReasonList;
            obj.wrongData = wrongDataList;
            return obj;
        }
        public static DataValidation SEVIS_First_Name(string SEVIS_First_Name, int RowCount)
        {
            DataValidation obj = new DataValidation();
            obj.isWrongData = false;
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            if (!String.IsNullOrEmpty(SEVIS_First_Name) && !String.IsNullOrWhiteSpace(SEVIS_First_Name))
            {
                bool ischaracter = Regex.IsMatch(SEVIS_First_Name, @"^[a-zA-Z ]+$");
                if(ischaracter == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 2 + "SEVIS First Name value is incorrect because of the is not in character format" + SEVIS_First_Name);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 1));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("SEVIS First Name is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 2));
            }
            obj.Reason = ReasonList;
            obj.wrongData = wrongDataList;
            return obj;
        }
        public static DataValidation SEVIS_Last_Name(string SEVIS_Last_Name, int RowCount)
        {
            DataValidation obj = new DataValidation();
            obj.isWrongData = false;
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            if (!String.IsNullOrEmpty(SEVIS_Last_Name) && !String.IsNullOrWhiteSpace(SEVIS_Last_Name))
            {
                bool ischaracter = Regex.IsMatch(SEVIS_Last_Name, @"^[a-zA-Z ]+$");
                if (ischaracter == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 3 + "SEVIS Last Name value is incorrect because of the is not in character format" + SEVIS_Last_Name);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 3));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("SEVIS Last Name is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 3));
            }
            obj.Reason = ReasonList;
            obj.wrongData = wrongDataList;
            return obj;
        }
        public static DataValidation Date_of_Birth(string Date_of_Birth,int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Date_of_Birth) && !String.IsNullOrWhiteSpace(Date_of_Birth))
            {
                string[] formats = { "MM/dd/yyyy" };
                DateTime parsedDateTime;
                bool isDate = DateTime.TryParseExact(Date_of_Birth, formats, new CultureInfo("en-US"),DateTimeStyles.None, out parsedDateTime);
                if(isDate == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + " Column: " + 4 + " Date of Birth value is incorrect because of the is not in correct date format " + Date_of_Birth);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 4));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Date of Birth is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 4));
            }
            obj.Reason = ReasonList;
            obj.wrongData = wrongDataList;
            return obj;
        }
        public static DataValidation Gender(string Gender, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Gender) && !String.IsNullOrWhiteSpace(Gender))
            {
                if(!Gender.Contains("Female")  || !Gender.Contains("Male"))
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + " Column: " + 5 + " Gender value is incorrect because of the is not in correct format " + Gender);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 5));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Gender is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 5));
            }
            return obj;
        }
        public static DataValidation HispanicOrLatino(string Hispanic_or_Latino, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Hispanic_or_Latino) && !String.IsNullOrWhiteSpace(Hispanic_or_Latino))
            {
                if (!Hispanic_or_Latino.Contains("YES") || !Hispanic_or_Latino.Contains("NO"))
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + " Column: " + 6 + " Hispanic or Latino value is incorrect because of the is not in correct YES or NO format " + Hispanic_or_Latino);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 6));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Hispanic or Latino is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 6));
            }
            return obj;
        }
        public static DataValidation ApplicantRace(string Applicant_Race, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(Applicant_Race) && String.IsNullOrWhiteSpace(Applicant_Race))
            {
                obj.isWrongData = true;
                ReasonList.Add("Applicant Race is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 7));
            }
            return obj;
        }
        public static DataValidation EmailValidation(string Email, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Email) && !String.IsNullOrWhiteSpace(Email))
            {
                bool isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if(isEmail == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + " Column: " + 8 + " Email value is incorrect because of the is not in correct format " + Email);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 8));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Email address is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 8));
            }
            return obj;
        }

        public static DataValidation VisaValidation(string VISA, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(VISA) && String.IsNullOrWhiteSpace(VISA))
            {
                obj.isWrongData = true;
                ReasonList.Add("VISA is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 9));
            }
            return obj;
        }
        public static DataValidation CityOfBirth(string Cityofbirth, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Cityofbirth) && !String.IsNullOrWhiteSpace(Cityofbirth))
            {
                obj.isWrongData = false;
                bool ischaracter = Regex.IsMatch(Cityofbirth, @"^[a-zA-Z ]+$");
                if (ischaracter == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 10 + "City Of Birth value is incorrect because of the is not in alphabet formation " + Cityofbirth);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 10));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("City Of Birth is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 10));
            }
            obj.Reason = ReasonList;
            obj.wrongData = wrongDataList;
            return obj;
        }
        public static DataValidation CountryOfBirth(string Countryofbirth, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(Countryofbirth) && !String.IsNullOrWhiteSpace(Countryofbirth))
            {
                obj.isWrongData = false;
                bool ischaracter = Regex.IsMatch(Countryofbirth, @"^[a-zA-Z ]+$");
                if (ischaracter == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 11 + "Country Of Birth value is incorrect because of the is not in alphabet formation " + Countryofbirth);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 11));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Country Of Birth is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 11));
            }
            return obj;
        }
        public static DataValidation CountryOfCitizenship(string CountryofCitizenship, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(CountryofCitizenship) && !String.IsNullOrWhiteSpace(CountryofCitizenship))
            {
                obj.isWrongData = false;
                bool ischaracter = Regex.IsMatch(CountryofCitizenship, @"^[a-zA-Z ]+$");
                if (ischaracter == false)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 12 + "Country Of Citizenship value is incorrect because of the is not in alphabet formation " + CountryofCitizenship);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 12));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Country Of Birth is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 12));
            }
            return obj;
        }
        public static DataValidation MaritalStatus(string MaritalStatus, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(MaritalStatus) && !String.IsNullOrWhiteSpace(MaritalStatus))
            {
                if(MaritalStatus.Length > 1)
                {
                    obj.isWrongData = true;
                    ReasonList.Add("Row: " + RowCount + "Column: " + 13 + "Marital Status value is incorrect because of the is not in single formation " + MaritalStatus);
                    wrongDataList.Add(string.Format("{0}-{1}", RowCount, 13));
                }
            }
            else
            {
                obj.isWrongData = true;
                ReasonList.Add("Marital Status is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 13));
            }
            return obj;
        }
        public static DataValidation PermanentStreetAddress(string PermanentStreetAddress,int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(PermanentStreetAddress) && String.IsNullOrWhiteSpace(PermanentStreetAddress))
            {
                obj.isWrongData = true;
                ReasonList.Add("Permanent Street Address is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 14));
            }
            return obj;
        }
        public static DataValidation PermanentCity(string PermanentCity, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(PermanentCity) && String.IsNullOrWhiteSpace(PermanentCity))
            {
                obj.isWrongData = true;
                ReasonList.Add("Permanent City is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 15));
            }
            return obj;
        }
        public static DataValidation PermanentProvinceStateTerritory(string Territory,int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(Territory) && String.IsNullOrWhiteSpace(Territory))
            {
                obj.isWrongData = true;
                ReasonList.Add("Permanent Province-State-Territory is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 16));
            }
            return obj;
        }
        public static DataValidation PermanentPostalCode(string PermanentPostalCode, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(PermanentPostalCode) && String.IsNullOrWhiteSpace(PermanentPostalCode))
            {
                obj.isWrongData = true;
                ReasonList.Add("Permanent Postal Code is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 17));
            }
            return obj;
        }
        public static DataValidation PermanentCountry(string PermanentCountry, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (String.IsNullOrEmpty(PermanentCountry) && String.IsNullOrWhiteSpace(PermanentCountry))
            {
                obj.isWrongData = true;
                ReasonList.Add("Permanent Country is blank");
                wrongDataList.Add(string.Format("{0}-{1}", RowCount, 18));
            }
            return obj;
        }
        public static DataValidation USPhoneNumber(string USPhoneNumber, int RowCount)
        {
            DataValidation obj = new DataValidation();
            List<string> ReasonList = new List<string>();
            List<string> wrongDataList = new List<string>();
            obj.isWrongData = false;
            if (!String.IsNullOrEmpty(USPhoneNumber) && String.IsNullOrWhiteSpace(USPhoneNumber))
            {

            }
            return obj;
        }
    }
}
