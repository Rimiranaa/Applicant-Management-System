//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppManagement.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string PassportNumber { get; set; }
        public string Phone { get; set; }
        public int idProfession { get; set; }
        public int idExam { get; set; }
        public int idStatus { get; set; }
    
        public virtual Exams Exams { get; set; }
        public virtual Professions Professions { get; set; }
        public virtual Status Status { get; set; }
    }
}
