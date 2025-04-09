using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSPS.Web.Model.Models;

    public enum ParseFieldEnum
    {

       // [EnumDescription("关键词", true)]
        Title = 0,
       // [EnumDescription("条码号", true)]
        BarCode = 1,
       // [EnumDescription("患者姓名", true)]
        PatientName = 2,
       // [EnumDescription("影像号/检查号", true)]
        CheckID = 3,
       // [EnumDescription("检查部位", true)]
        CheckPart = 4,
       // [EnumDescription("检查时间", true)]
        CheckTime = 5,
       // [EnumDescription("年龄", true)]
        Age = 6,
       // [EnumDescription("性别", true)]
        Sex = 7,
       // [EnumDescription("自定义名称", true)]
        Other = 8,
       // [EnumDescription("身份证号", true)]
        IDNO = 9,
       //[EnumDescription("体检单位", true)]
        ExaminationCompany = 10,
       //[EnumDescription("体检部门", true)]
        ExaminationDepartment = 11,
       //[EnumDescription("院区", true)]
        HospitalArea = 12,
       //[EnumDescription("病区", true)]
        PatientArea = 13,
       //[EnumDescription("临床科室", true)]
        ClinicalDepartment = 14,
       //[EnumDescription("住院号", true)]
       HospitalNo = 15,
       //[EnumDescription("报告医生", true)]
       ReportDoctor = 16,
       //[EnumDescription("一审医生", true)]
       FirstAudtiDoctor = 17,
       //[EnumDescription("二审医生", true)]
       SecondAuditDoctor = 18,
       //[EnumDescription("三审医生", true)]
       ThirdAuditDoctor = 19,
    }

