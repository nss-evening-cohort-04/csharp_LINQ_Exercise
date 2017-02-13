using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_MethodChaining
    {
        public List<Cohort> PracticeData { get; set; }
        public CohortBuilder CohortBuilder { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            CohortBuilder = new CohortBuilder();
            PracticeData = CohortBuilder.GenerateCohorts();
        }

        [TestCleanup]
        public void TearDown()
        {
            CohortBuilder = null;
            PracticeData = null;
        }

        [TestMethod]
        public void GetAllCohortsWithZacharyZohanAsPrimaryOrJuniorInstructor()
        {
            var ActualCohorts = PracticeData.Where(zachPrim => zachPrim.PrimaryInstructor.FirstName == "Zachary" && zachPrim.PrimaryInstructor.LastName == "Zohan" || zachPrim.JuniorInstructors.Any(item => item.FirstName == "Zachary" && item.LastName == "Zohan")).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort2, CohortBuilder.Cohort3 });
        }

        [TestMethod]
        public void GetAllCohortsWhereFullTimeIsFalseAndAllInstructorsAreActive()
        {
            var ActualCohorts = PracticeData.Where(fullAndActive => fullAndActive.FullTime == false && fullAndActive.PrimaryInstructor.Active == true && fullAndActive.JuniorInstructors.All(junAct => junAct.Active == true)).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1 });
        }

        [TestMethod]
        public void GetAllCohortsWhereAStudentOrInstructorFirstNameIsKate()
        {
            var ActualCohorts = PracticeData.Where(studOrIn => studOrIn.PrimaryInstructor.FirstName == "Kate" || studOrIn.JuniorInstructors.Any(newJunInstruc => newJunInstruc.FirstName == "Kate")||studOrIn.Students.Any(newItemName => newItemName.FirstName == "Kate")).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1, CohortBuilder.Cohort3, CohortBuilder.Cohort4 });
        }

        [TestMethod]
        public void GetOldestStudent()
        {
            var student = PracticeData.SelectMany(oldStudent => oldStudent.Students).OrderBy(oldAge => oldAge.Birthday).First();
            Assert.AreEqual(student, CohortBuilder.Student18);
        }

        [TestMethod]
        public void GetYoungestStudent()
        {
            var student = PracticeData.SelectMany(youngStud => youngStud.Students).OrderBy(youngStud2 => youngStud2.Birthday.Year).Last();
            Assert.AreEqual(student, CohortBuilder.Student3);
        }

        [TestMethod]
        public void GetAllInactiveStudentsByLastName()
        {
            var ActualStudents = PracticeData.SelectMany(studLastName => studLastName.Students).Where(lastName => lastName.Active == false).ToList();
            CollectionAssert.AreEqual(ActualStudents, new List<Student> { CohortBuilder.Student2, CohortBuilder.Student11, CohortBuilder.Student12, CohortBuilder.Student17 });
        }
    }
}
