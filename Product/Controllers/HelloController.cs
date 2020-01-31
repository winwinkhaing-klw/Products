namespace Product.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Hello controller for web api.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class HelloController : ApiController
    {
        /// <summary>
        /// Test web api for get method.
        /// </summary>
        /// <returns>String.</returns>
        /// <param name="stud">student.</param>
        [HttpGet]
        [Route("api/student")]
        public Student Get([FromUri] Student stud)
        {
            return stud;
        }

        /// <summary>
        /// Get Method from array.
        /// </summary>
        /// <returns>value.</returns>
        [HttpGet]
        public IEnumerable<string> Student()
        {
            return new string[] { "Aye Aye", "Zaw Zaw" };
        }

        // POST: api/student.
        [HttpPost]
        [Route("api/student")]
        public Student Post([FromUri]Student stud)
        {
            return stud;
        }

        /// <summary>
        ///  PUT: api/student/5.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="student">student.</param>
        [HttpPut]
        public void UpdateRecord(int id, [FromBody]string student)
        {
        }

        /// <summary>
        ///  DELETE: api/student/5.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete]
        public void RemoveRecord(int id)
        {
        }
    }
}
