using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace UserInfoRegistrationAPIData
{
    public class clsEntity
    {
               public class Response
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public object ResponseData { get; set; }

            public Response(string status, string message, object data)
            {
                Code = status;
                Message = message;
                ResponseData = data;
            }
        }

    }
}

#region Rao
//Code - Enum Message Relation

// By Ashis  For Code - Message Relation
public enum ResCode
{

    [Description("Exception Logged")]
    ExceptionLog = 0001,

    [Description("Successfully Loged In")]
    LoginSuccess = 1000,
    [Description("Login Failed Due to Invalid Credentials")]
    LoginFailed = 1001,
    [Description("User Account is Inactive")]
    AccountLocked = 1002,
    [Description("ID is blocked due to multiple login attempts.<br/> Please contact system administrator")]
    AccountInactive = 1003,
    [Description("User Data Found")]
    UserDataFound = 2000,
    [Description("User Data Not Found")]
    UserDataNotFound = 2001,
    [Description("User Name Already Exists")]
    UserNameAlreadyExits = 2002,
    [Description("User Data Already Exist.Can Not Proceed With The Same Email Id")]//  for 0

    EmployeeNoAlreadyExits = 2003,
    [Description("User StaffID Already Exist.Can Not Proceed With The Same EmployeeNo")]//  for 0
    UserDataAlEx = 3001,
    [Description("User Data Requested For Approval.")]// For 2
    UserDataInsForPendingReq = 3001,
    [Description("User Data Inserted Successfully.")]// For 1
    UserDataIns = 3002,
    [Description("Error In User Data Inserted.")]// For 1
    UserDataInsError = 3003,
    [Description("Requested User Approved.")]// For 1
    ReqUserApprove = 4000,
    [Description("Requested User Rejected.")]// For 1
    ReqUserRej = 4001,
    [Description("Requested User Not Found.")]// For 1
    ReqUserNotFound = 4002,
    [Description("Requested User Approve/Rejection Failed.")]// For 1
    UserReqApprFailed = 4003,
    [Description("User Uploaded Successfully.")]// For 1
    UserUploadSuc = 5001,
    [Description("User Uploaded Failed.")]// For 1
    UserUploadFailed = 5000,
    [Description("Fetch User Data By Id.")]// For 1
    UserById = 6000,
    [Description("No Data For The User Id.")]// For 1
    UserNotById = 6001,
    [Description("PDI Successfully Inserted")]
    inspectionSuccess = 2000,
    [Description("PDI Insertion Failed for this chesis no")]
    inspectionFailed = 2001,
    [Description("Password Policy Successfully Inserted/Updated")]
    passwordPolicySuccess = 7000,
    [Description("PDI Insertion Failed for this chesis no")]
    passwordPolicyFailed = 7001,
    [Description("Delivery Planning No Data Found")]
    deliveryPlanningDPnoSuccess = 8000,
    [Description("No Data Found")]
    deliveryPlanningDPnoFailed = 8001,
    [Description("Vehicle Delivery Note  Data Found")]
    deliveryNoteSuccess = 9000,
    [Description("Vehicle Delivery Note No Data Found")]
    deliveryNoteFailed = 9001,
    [Description("Vehicle Delivery Note  Updated Successfully")]
    deliveryNoteUpdatedSuccess = 10000,
    [Description("Vehicle Delivery Note Not Updated Successfully")]
    deliveryNoteUpdatedFailed = 10001,
    [Description("Successfully Updated")]
    PasswordChangedSuccess = 7000,
    [Description("Login Failed to Updated")]
    PasswordChangedFailed = 7001

}
#endregion
public class Response
{
    public string Code { get; set; }
    public string Message { get; set; }
    public object ResponseData { get; set; }

    public Response(string status, string message, object data)
    {
        Code = status;
        Message = message;
        ResponseData = data;
    }
}

