using AutoMapper;
using Entities;
using HSPS.Web.Model.Dtos;


namespace HSPS.Web.AutoMapper;

public class AutoMapperProfile : Profile
{
    /// <summary>
    /// 配置构造函数，创建关系映射
    /// </summary>
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<PermissionDto, Permission>();


        CreateMap<Model.Models.Extensions.ReportType, ReportTypeDto>();
        //CreateMap<Report, ReportDto>();

        //.ForMember(a => a.ReportID, o => o.MapFrom(d => d.ReportID))
        //.ForMember(a => a.ID, o => o.MapFrom(d => d.ID))
        //.ForMember(a => a.RelationID, o => o.MapFrom(d => d.RelationID))
        //.ForMember(a => a.PrintColorValue, o => o.MapFrom(d => d.PrintColorValue))
        //.ForMember(a => a.PrintMediaValue, o => o.MapFrom(d => d.PrintMediaValue))
        //.ForMember(a => a.PrintSizeValue, o => o.MapFrom(d => d.PrintSizeValue))
        //.ForMember(a => a.PrintStatusValue, o => o.MapFrom(d => d.PrintStatusValue))
        //.ForMember(a => a.ReportStatusValue, o => o.MapFrom(d => d.ReportStatusValue))
        //.ForMember(a => a.ParseRuleTypeValue, o => o.MapFrom(d => d.ParseRuleTypeValue))
        //.ForMember(a => a.BarCode, o => o.MapFrom(d => d.BarCode))
        //.ForMember(a => a.CheckID, o => o.MapFrom(d => d.CheckID))
        //.ForMember(a => a.CheckTime, o => o.MapFrom(d => d.CheckTime))
        //.ForMember(a => a.PatientIDStr, o => o.MapFrom(d => d.PatientIDStr))
        //.ForMember(a => a.PatientName, o => o.MapFrom(d => d.PatientName))
        //.ForMember(a => a.StationID, o => o.MapFrom(d => d.StationID))
        //.ForMember(a => a.StationName, o => o.MapFrom(d => d.StationName))
        //.ForMember(a => a.StationIP, o => o.MapFrom(d => d.StationIP))
        //.ForMember(a => a.DepartmentID, o => o.MapFrom(d => d.DepartmentID))
        //.ForMember(a => a.DepartmentName, o => o.MapFrom(d => d.DepartmentName))
        //.ForMember(a => a.Age, o => o.MapFrom(d => d.Age))
        //.ForMember(a => a.Sex, o => o.MapFrom(d => d.Sex))
        //.ForMember(a => a.CheckPart, o => o.MapFrom(d => d.CheckPart))
        //.ForMember(a => a.ReportTypeName, o => o.MapFrom(d => d.ReportTypeName))
        //.ForMember(a => a.ReportTypeID, o => o.MapFrom(d => d.ReportTypeID))
        //.ForMember(a => a.ReportStatusName, o => o.MapFrom(d => d.ReportStatusName))
        //.ForMember(a => a.DiscernStatusName, o => o.MapFrom(d => d.DiscernStatusName))
        //.ForMember(a => a.PrintStatusName, o => o.MapFrom(d => d.PrintStatusName))
        //.ForMember(a => a.ParseRuleTypeName, o => o.MapFrom(d => d.ParseRuleTypeName))
        //.ForMember(a => a.ReceiveTime, o => o.MapFrom(d => d.ReceiveTime))
        //.ForMember(a => a.PrintMediaName, o => o.MapFrom(d => d.PrintMediaName))
        //.ForMember(a => a.PrintSizeName, o => o.MapFrom(d => d.PrintSizeName))
        //.ForMember(a => a.PrintColorName, o => o.MapFrom(d => d.PrintColorName))
        //.ForMember(a => a.PrintLastTime, o => o.MapFrom(d => d.PrintLastTime))
        //.ForMember(a => a.Layout, o => o.MapFrom(d => d.Layout))
        //.ForMember(a => a.PageCount, o => o.MapFrom(d => d.PageCount))
        //.ForMember(a => a.PrintFileType, o => o.MapFrom(d => d.PrintFileType))
        //.ForMember(a => a.Title, o => o.MapFrom(d => d.Title))
        //.ForMember(a => a.ReportPath, o => o.MapFrom(d => d.ReportPath))
        //.ForMember(a => a.CustomFieldsValueList, o => o.MapFrom(d => d.CustomFieldsValueList))
        //.ForMember(a => a.HspsPatientID, o => o.MapFrom(d => d.HspsPatientID))
        //.ForMember(a => a.ParseData, o => o.MapFrom(d => d.ParseData))
        //.ForMember(a => a.DiscernStatusValue, o => o.MapFrom(d => d.DiscernStatusValue))
        //.ForMember(a => a.IsColorful, o => o.MapFrom(d => d.IsColorful))
        //.ForMember(a => a.PrintStatus, o => o.MapFrom(d => d.PrintStatus))
        //.ForMember(a => a.Media, o => o.MapFrom(d => d.Media))
        //.ForMember(a => a.PintQuality, o => o.MapFrom(d => d.PintQuality))
        //.ForMember(a => a.PrintSize, o => o.MapFrom(d => d.PrintSize))
        //.ForMember(a => a.PrintWay, o => o.MapFrom(d => d.PrintWay))
        //.ForMember(a => a.ParseRuleType, o => o.MapFrom(d => d.ParseRuleType))
        //.ForMember(a => a.FileExtType, o => o.MapFrom(d => d.FileExtType))
        //.ForMember(a => a.ExaminationCompany, o => o.MapFrom(d => d.ExaminationCompany))
        //.ForMember(a => a.ExaminationDepartment, o => o.MapFrom(d => d.ExaminationDepartment))
        //.ForMember(a => a.IDNO, o => o.MapFrom(d => d.IDNO))
        //.ForMember(a => a.Phone, o => o.MapFrom(d => d.Phone))
        //.ForMember(a => a.VisitType, o => o.MapFrom(d => d.VisitType))
        //.ForMember(a => a.PrintCount, o => o.MapFrom(d => d.PrintCount))
        //.ForMember(a => a.HospitalArea, o => o.MapFrom(d => d.HospitalArea))
        //.ForMember(a => a.PatientArea, o => o.MapFrom(d => d.PatientArea))
        //.ForMember(a => a.ClinicalDepartment, o => o.MapFrom(d => d.ClinicalDepartment))
        //.ForMember(a => a.HospitalNo, o => o.MapFrom(d => d.HospitalNo))
        //.ForMember(a => a.AuditDoctor, o => o.MapFrom(d => d.AuditDoctor))
        //.ForMember(a => a.IsExamination, o => o.MapFrom(d => d.IsExamination))
        //.ForMember(a => a.ReportAudit, o => o.MapFrom(d => d.ReportAudit))
        //.ForMember(a => a.ReportDoctor, o => o.MapFrom(d => d.ReportDoctor))
        //.ForMember(a => a.FirstAuditDoctor, o => o.MapFrom(d => d.FirstAuditDoctor))
        //.ForMember(a => a.FirstAuditTime, o => o.MapFrom(d => d.FirstAuditTime))
        //.ForMember(a => a.SecondAuditDoctor, o => o.MapFrom(d => d.SecondAuditDoctor))
        //.ForMember(a => a.SecondAuditTime, o => o.MapFrom(d => d.SecondAuditTime))
        //.ForMember(a => a.ThirdAuditDoctor, o => o.MapFrom(d => d.ThirdAuditDoctor))
        //.ForMember(a => a.ThirdAuditTime, o => o.MapFrom(d => d.ThirdAuditTime))
        //.ForMember(a => a.AuditLevel, o => o.MapFrom(d => d.AuditLevel))
        //.ForMember(a => a.ReportCurrentAuditLevel, o => o.MapFrom(d => d.ReportCurrentAuditLevel));




        //CreateMap<ReportDto, Report>();
        //CreateMap<BlogArticle, BlogViewModels>();
        //CreateMap<BlogViewModels, BlogArticle>();

        //CreateMap<SysUserInfo, SysUserInfoDto>()
        //    .ForMember(a => a.uID, o => o.MapFrom(d => d.Id))
        //    .ForMember(a => a.RIDs, o => o.MapFrom(d => d.RIDs))
        //    .ForMember(a => a.addr, o => o.MapFrom(d => d.Address))
        //    .ForMember(a => a.age, o => o.MapFrom(d => d.Age))
        //    .ForMember(a => a.birth, o => o.MapFrom(d => d.Birth))
        //    .ForMember(a => a.uStatus, o => o.MapFrom(d => d.Status))
        //    .ForMember(a => a.uUpdateTime, o => o.MapFrom(d => d.UpdateTime))
        //    .ForMember(a => a.uCreateTime, o => o.MapFrom(d => d.CreateTime))
        //    .ForMember(a => a.uErrorCount, o => o.MapFrom(d => d.ErrorCount))
        //    .ForMember(a => a.uLastErrTime, o => o.MapFrom(d => d.LastErrorTime))
        //    .ForMember(a => a.uLoginName, o => o.MapFrom(d => d.LoginName))
        //    .ForMember(a => a.uLoginPWD, o => o.MapFrom(d => d.LoginPWD))
        //    .ForMember(a => a.uRemark, o => o.MapFrom(d => d.Remark))
        //    .ForMember(a => a.uRealName, o => o.MapFrom(d => d.RealName))
        //    .ForMember(a => a.name, o => o.MapFrom(d => d.Name))
        //    .ForMember(a => a.tdIsDelete, o => o.MapFrom(d => d.IsDeleted))
        //    .ForMember(a => a.RoleNames, o => o.MapFrom(d => d.RoleNames));
        //CreateMap<SysUserInfoDto, SysUserInfo>()
        //    .ForMember(a => a.Id, o => o.MapFrom(d => d.uID))
        //    .ForMember(a => a.Address, o => o.MapFrom(d => d.addr))
        //    .ForMember(a => a.RIDs, o => o.MapFrom(d => d.RIDs))
        //    .ForMember(a => a.Age, o => o.MapFrom(d => d.age))
        //    .ForMember(a => a.Birth, o => o.MapFrom(d => d.birth))
        //    .ForMember(a => a.Status, o => o.MapFrom(d => d.uStatus))
        //    .ForMember(a => a.UpdateTime, o => o.MapFrom(d => d.uUpdateTime))
        //    .ForMember(a => a.CreateTime, o => o.MapFrom(d => d.uCreateTime))
        //    .ForMember(a => a.ErrorCount, o => o.MapFrom(d => d.uErrorCount))
        //    .ForMember(a => a.LastErrorTime, o => o.MapFrom(d => d.uLastErrTime))
        //    .ForMember(a => a.LoginName, o => o.MapFrom(d => d.uLoginName))
        //    .ForMember(a => a.LoginPWD, o => o.MapFrom(d => d.uLoginPWD))
        //    .ForMember(a => a.Remark, o => o.MapFrom(d => d.uRemark))
        //    .ForMember(a => a.RealName, o => o.MapFrom(d => d.uRealName))
        //    .ForMember(a => a.Name, o => o.MapFrom(d => d.name))
        //    .ForMember(a => a.IsDeleted, o => o.MapFrom(d => d.tdIsDelete))
        //    .ForMember(a => a.RoleNames, o => o.MapFrom(d => d.RoleNames));
    }
}