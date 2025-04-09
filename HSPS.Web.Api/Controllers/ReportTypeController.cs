using AutoMapper;
using HSPS.Web.AuthHelper.OverWrite;
using HSPS.Web.Common;
using HSPS.Web.Common.Helper;
using HSPS.Web.Controllers;
using HSPS.Web.IServices;
using HSPS.Web.Model;
using HSPS.Web.Model.Dtos;
using HSPS.Web.Model.Models;
using HSPS.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HSPS.Web.Api.Controllers;

/// <summary>
/// 报告类别接口
/// </summary>
[Produces("application/json")]
[Route("api/ReportType")]
[AllowAnonymous]
public class ReportTypeController : BaseApiController
{
    private readonly IReportTypeServices _reportTypeServices;
    private readonly IMapper _mapper;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="reportTypeServices"></param>
    /// <param name="mapper"></param>
    public ReportTypeController(IReportTypeServices reportTypeServices, IMapper mapper)
    {
        _reportTypeServices = reportTypeServices;
        _mapper = mapper;
    }

    /// <summary>
    /// 获取所有报告类别（wcf）
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public MessageModel<List<Model.Models.Extensions.ReportType>> GetReportTypes()
    {
        List<Model.Models.Extensions.ReportType> reportTypeDto = new List<Model.Models.Extensions.ReportType>();
        bool suc = false;

        var reportType = _reportTypeServices.GetReportTypes();
        if (reportType.IsNotEmptyOrNull())
        {
            suc = true;
            reportTypeDto = reportType.ToList();
        }

        return new MessageModel<List<Model.Models.Extensions.ReportType>>()
        {
            success = suc,
            msg = suc ? "获取成功" : "获取失败",
            response = reportTypeDto
        };
    }



}
