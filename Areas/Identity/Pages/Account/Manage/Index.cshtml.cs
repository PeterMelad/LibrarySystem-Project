﻿@page
@model IndexModel
@{
    ViewData["Title"] = "Profile";
    ViewData["ActivePage"] = ManageNavPages.Index;
}

<h4>@ViewData["Title"]</h4>
<partial name="_StatusMessage" model="Model.StatusMessage" />
<form id="profile-form" method="post" enctype="multipart/form-data">
    <div class="row">
        <div class="col-md-6">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="Username"></label>
                <input asp-for="Username" class="form-control" disabled />
            </div>
            <div class="form-group">
                <label asp-for="Input.FirstName"></label>
                <input asp-for="Input.FirstName" class="form-control" />
            </div>
            <div class="form-group">
                <label asp-for="Input.LastName"></label>
                <input asp-for="Input.LastName" class="form-control" />
                <span asp-validation-for="Input.LastName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Input.PhoneNumber"></label>
                <input asp-for="Input.PhoneNumber" class="form-control" />
                <span asp-validation-for="Input.PhoneNumber" class="text-danger"></span>
            </div>
            <button id="update-profile-button" type="submit" class="btn btn-primary">Save</button>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label asp-for="Input.ProfilePic" class="w-100"></label>
                @if (Model.Input.ProfilePic != null)        // fe 7alet ene 3nde image fe el database , f h3mlha upload   
                {
                    <img id="ProfilePic" alt="profile" class="ProfilePic" src="data:image/*;base64,@(Convert.ToBase64String(Model.Input.ProfilePic))" /> //el image mawgoda as binary f ana b7tag a7welha to base64
                }
                else
                {       //fe 7alet en el image m4 mawgoda ( 'alt' ele m3 img => bys3dk tzhar klma aw image bdela) (mohem enha tkon mawgoda)
                    <img id="ProfilePic" alt="profile"class="ProfilePic" src="~/images/Profile.png" />        // hna kda lw mfe4 image h7ot el default image
                }
            </div>
            <div class="custom-file mt-2">
                <input type="file" accept="image/*" asp-for="Input.ProfilePic" class="custom-file-input"
                  onchange="document.getElementById('ProfilePic').src = window.URL.createObjectURL(this.files[0])"/>    @* hna kda lma y3ml upload l image , code el javascript da hy5leha tzhar 3latool*@

                <label class="custom-file-label">Upload Picture</label>
                <span asp-validation-for="Input.ProfilePic" class="text-danger"></span>
            </div>
        </div>
    </div>
</form>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    oft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccessDeniedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDat