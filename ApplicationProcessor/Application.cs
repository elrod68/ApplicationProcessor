using System;
using System.Text;
using ULaw.ApplicationProcessor.Enums;  

namespace ULaw.ApplicationProcessor
{
    public class Application
    {
        public Application(string faculty, string CourseCode, DateTime Startdate, string Title, string FirstName, string LastName, DateTime DateOfBirth, bool requiresVisa)
        {
            this.ApplicationId = new Guid();
            this.Faculty = faculty;
            this.CourseCode = CourseCode;
            this.StartDate = Startdate;
            this.Title = Title;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.RequiresVisa = RequiresVisa;
            this.DateOfBirth = DateOfBirth;
        }

        public Guid ApplicationId { get; private set; }
        public string Faculty { get; private set; }
        public string CourseCode { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public bool RequiresVisa { get; private set; }

        public DegreeGradeEnum DegreeGrade { get; set; }
        public DegreeSubjectEnum DegreeSubject { get; set; }

        //decide on application status
        public ApplicationResult AppResult()
        {
            if (DegreeGrade == DegreeGradeEnum.twoTwo) return ApplicationResult.Processing;
            else
            {
                if (DegreeGrade == DegreeGradeEnum.third) return ApplicationResult.Rejected;
                else
                {
                    if (DegreeSubject == DegreeSubjectEnum.law || DegreeSubject == DegreeSubjectEnum.lawAndBusiness) return ApplicationResult.Accepted;
                    else return ApplicationResult.Processing;
                }
            }
        }
        public string Process()
        {
            var result = new StringBuilder(HTMLBodyStart());
            result.Append(HTMLSalutation());

            if (DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                result.Append(HTMLProcessing());
            }
            else
            {
                if (DegreeGrade == DegreeGradeEnum.third)
                {
                    result.Append(HTMLApplicationRejected());
                }
                else
                {
                    if (DegreeSubject == DegreeSubjectEnum.law || DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
                    {
                        result.Append(HTMLApplicationAccepted());
                    }
                    else
                    {
                        result.Append(HTMLProcessing());
                    }
                }
            }

            result.Append(HTMLYours());
            result.Append(HTMLBodyEnd());

            return result.ToString();
        }

        //HTML we are processing
        public string HTMLProcessing()
        {
            return $"<p/> Further to your recent application for our course reference: {CourseCode} starting on {StartDate.ToLongDateString()}, we are writing to inform you that we are currently assessing your information and will be in touch shortly." +
                   $"<br/> If you wish to discuss any aspect of your application, please contact us at {AdmissionsEmail()}.";
        }

        //HTML application accepted
        public string HTMLApplicationAccepted()
        {
            return $"<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {CourseCode} starting on {StartDate.ToLongDateString()}." +
                   $"<br/> This offer will be subject to evidence of your qualifying {DegreeSubject.ToDescription()} degree at grade: {DegreeGrade.ToDescription()}." +
                   $"<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{DepositAmount().ToString()} deposit fee to secure your place." +
                    "<br/> We look forward to welcoming you to the University,";
        }

        //HTML application rejected
        public string HTMLApplicationRejected()
        {
            return "<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion." +
                   $"<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at {AdmissionsEmail()}.";
        }

        public string AdmissionsEmail()
        {
            //Might expand this to include different emails depending on the application data
            return "AdmissionsTeam@Ulaw.co.uk";
        }

        public decimal DepositAmount()
        {
            //Might expand this to calculate different amounts depending on the application data, year or do a query in a database etc.
            return 350.00M;
        }

        //primitive for HTML body start
        public string HTMLBodyStart()
        {
            return "<html><body><h1>Your Recent Application from the University of Law</h1>";
        }

        //primitive for HTML salutation
        public string HTMLSalutation()
        {
            return $"<p> Dear {FirstName}, </p>";
        }

        //primitive for HTML body end
        public string HTMLBodyEnd()
        {
            return "</body></html>";
        }

        //primitive for HTML yours
        public string HTMLYours()
        {
            return "<br/> Yours sincerely," +
                   "<p/> The Admissions Team,";
        }
    }
}

