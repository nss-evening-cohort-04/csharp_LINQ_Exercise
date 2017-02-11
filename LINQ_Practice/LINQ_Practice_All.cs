using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_All
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
        public void DoAllCohortsHaveTwoOrMoreJuniorInstructors()
        {
            var doAll = PracticeData.All(Cohort => Cohort.JuniorInstructors.Count >= 2);
            Assert.IsTrue(doAll); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllCohortsFiveStudents()
        {
            var doAll = PracticeData.All(cohorts => cohorts.Students.Count == 5);
            Assert.IsTrue(doAll); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllCohortsHavePrimaryInstructorsBornIn1980s()
        {
            var doAll = PracticeData.All(instructors => instructors.PrimaryInstructor.Birthday.Year >= 1980 && instructors.PrimaryInstructor.Birthday.Year <= 1989);
            Assert.IsFalse(doAll); //<-- change true to doAll
        }

        [TestMethod]
        public void DoAllCohortsHaveActivePrimaryInstructors()
        {
            var doAll = PracticeData.All(cohorts => cohorts.PrimaryInstructor.Active);
            Assert.IsTrue(doAll); //<-- change true to doAll
        }

        [TestMethod]
        public void DoAllStudentsInCohort1HaveFirstNamesThatContainTheLetterE()
        {
            var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/; //Hint: Cohort1 would be PracticeData[0]
            Assert.IsTrue(false); //<-- change false to doAll
        }

        [TestMethod]
        public void DoAllActiveCohortsHavePrimaryInstructorsWithFirstNamesThatContainTheLetterA()
        {
            var doAll = PracticeData.All(instructors => instructors.PrimaryInstructor.FirstName.Contains("A"));
            Assert.IsFalse(doAll); //<-- change false to doAll
        }
    }
}
