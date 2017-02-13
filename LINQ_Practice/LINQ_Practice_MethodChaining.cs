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
            //.Where returns data (pick out the cohorts with)
            //.Any whether any elements of a sequence satisfies a condition (returns bool)
            //.ToList adds to a list
            var ActualCohorts = PracticeData.Where(p => p.PrimaryInstructor.FirstName == "Zachary"  || p.JuniorInstructors.Any(j => j.FirstName == "Zachary")).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort2, CohortBuilder.Cohort3 });
        }

        [TestMethod]
        public void GetAllCohortsWhereFullTimeIsFalseAndAllInstructorsAreActive()
        {
            //.All whether all elements of a sequence satisfy a condition (returns a bool)
            var ActualCohorts = PracticeData.Where(p=> p.FullTime == false && p.PrimaryInstructor.Active == true && p.JuniorInstructors.All(j => j.Active == true)).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1 });
        }

        [TestMethod]
        public void GetAllCohortsWhereAStudentOrInstructorFirstNameIsKate()
        {
            var ActualCohorts = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1, CohortBuilder.Cohort3, CohortBuilder.Cohort4 });
        }

        [TestMethod]
        public void GetOldestStudent()
        {
            var student = PracticeData/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(student, CohortBuilder.Student18);
        }

        [TestMethod]
        public void GetYoungestStudent()
        {
            var student = PracticeData/*FILL IN LINQ EXPRESSION*/;
            Assert.AreEqual(student, CohortBuilder.Student3);
        }

        [TestMethod]
        public void GetAllInactiveStudentsByLastName()
        {
            var ActualStudents = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            CollectionAssert.AreEqual(ActualStudents, new List<Student> { CohortBuilder.Student2, CohortBuilder.Student11, CohortBuilder.Student12, CohortBuilder.Student17 });
        }
    }
}
