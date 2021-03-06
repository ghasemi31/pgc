﻿using kFrameWork.UI;
using pgc.Model.Patterns;
using pgc.Model.Enums;

public partial class Pages_Admin_User_Search : BaseSearchControl<UserPattern>
{
    public override UserPattern Pattern
    {
        get
        {
            return new UserPattern()
            {
                AccessLevel_ID = lkcAccessLevel.GetSelectedValue<long>(),
                ActivityStatus = lkcActivityStatus.GetSelectedValue<UserActivityStatus>(),
                Address = txtAddress.Text,
                City_ID = lkcCity.GetSelectedValue<long>(),
                Email = txtEmail.Text,
               
                Mobile = txtMobile.Text,
                Name = txtName.Text,
                NationalCode = txtNationalCode.Text,
                PostalCode = txtPostalCode.Text,
                Province_ID = lkcProvince.GetSelectedValue<long>(),
                Role = lkcRole.GetSelectedValue<Role>(),
                Tel = txtTel.Text,
                FatherName=txtFatherName.Text,
                //Username = txtUsername.Text,
                SignUpPersianDate = pdrSignUpPersianDate.DateRange,
                Gender=lkcGender.GetSelectedValue<Gender>(),
           
            };
        }
        set
        {
            lkcAccessLevel.SetSelectedValue(value.AccessLevel_ID);
            lkcActivityStatus.SetSelectedValue(value.ActivityStatus);
            txtAddress.Text = value.Address;
            lkcCity.SetSelectedValue(value.City_ID);
            txtEmail.Text = value.Email;
           
            txtMobile.Text = value.Mobile;
            txtName.Text = value.Name;
            txtNationalCode.Text = value.NationalCode;
            txtPostalCode.Text = value.PostalCode;
            lkcProvince.SetSelectedValue(value.Province_ID);
            lkcRole.SetSelectedValue(value.Role);
            txtTel.Text = value.Tel ;
            txtFatherName.Text = value.FatherName;
            //txtUsername.Text = value.Username;
            pdrSignUpPersianDate.DateRange = value.SignUpPersianDate;
            lkcGender.SetSelectedValue(value.Gender);
            
        }
    }
    protected override void OnPreRender(System.EventArgs e)
    {
        base.OnPreRender(e);
        Session["UserListPattern"] = Pattern;
    }
}