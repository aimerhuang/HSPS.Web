﻿namespace HSPS.Web.Model.Models;

public class TokenInfoViewModel
{
    public bool success { get; set; }
    public string token { get; set; }
    public double expires_in { get; set; }
    public string token_type { get; set; }
}
