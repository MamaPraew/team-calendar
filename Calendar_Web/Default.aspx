<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calendar_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"
     lang="en"
  class="light-style customizer-hide"
  dir="ltr"
  data-theme="theme-default"
  data-assets-path="../sneat-1.0.0/assets/"
  data-template="vertical-menu-template-free"
    >
<head runat="server" >
    <meta charset="utf-8" />
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0" />
    <title></title>

    <meta name="description" content="" />

    <!-- Favicon -->
    <link rel="icon" type="image/x-icon" href="../sneat-1.0.0/assets/img/favicon/favicon.ico" />

    <!-- Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Public+Sans:ital,wght@0,300;0,400;0,500;0,600;0,700;1,300;1,400;1,500;1,600;1,700&display=swap"
      rel="stylesheet"
    />

    <!-- Icons. Uncomment required icon fonts -->
    <link rel="stylesheet" href="../sneat-1.0.0/assets/vendor/fonts/boxicons.css" />

    <!-- Core CSS -->
    <link rel="stylesheet" href="../sneat-1.0.0/assets/vendor/css/core.css" class="template-customizer-core-css" />
    <link rel="stylesheet" href="../sneat-1.0.0/assets/vendor/css/theme-default.css" class="template-customizer-theme-css" />
    <link rel="stylesheet" href="../sneat-1.0.0/assets/css/demo.css" />

    <!-- Vendors CSS -->
    <link rel="stylesheet" href="../sneat-1.0.0/assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.css" />

    <!-- Page CSS -->
    <!-- Page -->
    <link rel="stylesheet" href="../sneat-1.0.0/assets/vendor/css/pages/page-auth.css" />
    <!-- Helpers -->
    <script src="../sneat-1.0.0/assets/vendor/js/helpers.js"></script>

 
    <script src="../sneat-1.0.0/assets/js/config.js"></script>
</head>
<body>

    <!-- Content -->

     
        
    

    <div class="container-xxl">
      <div class="authentication-wrapper authentication-basic container-p-y">
        <div class="authentication-inner">
          <!-- Register -->
          <div class="card">
            <div class="card-body">
              <!-- Logo -->
              <div class="app-brand justify-content-center">
                <a href="index.html" class="app-brand-link gap-2">
                  <span class="app-brand-logo demo">
                    <i class="bx bxs-calendar-heart bx-tada bx-md"></i>
                  </span>
                  <span class="app-brand-text demo text-body fw-bolder">Team Calendar</span>
                </a>
              </div>
              <!-- /Logo -->
              <h4 class="mb-2">Welcome 👋</h4>
              <p class="mb-4">Please sign-in with your Evaluation account</p>

             <form id="formAuthentication" class="mb-3" runat="server">
                <div class="mb-3">
                  <label for="username" class="form-label">Username</label>
                  <input
                    type="text"
                    class="form-control"
                    id="username"
                    name="email-username"
                    placeholder="Enter your Employee No."
                    autofocus
                      runat="server"
                  />
                </div>
                <div class="mb-3 form-password-toggle">
                  <div class="d-flex justify-content-between">
                    <label class="form-label" for="password">Password</label>
                    <a href="http://eva.oneeclick.co:8001/#/authentication/forgot-password" target="_blank">
                      <small>Forgot Password?</small>
                    </a>
                  </div>
                  <div class="input-group input-group-merge">
                    <input
                      type="password"
                      id="password"
                      class="form-control"
                      name="password"
                      placeholder="&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;"
                      aria-describedby="password"
                      runat="server"
                    />
                    <span class="input-group-text cursor-pointer"><i class="bx bx-hide"></i></span>
                  </div>
                </div>


                


                <div class="mb-3">
                 <%-- <div class="form-check">
                    <input class="form-check-input" type="checkbox" id="remember-me" />
                    <label class="form-check-label" for="remember-me"> Remember Me </label>
                  </div>--%>
        <dx:BootstrapCheckBox ID="chkRemember" runat="server" Text="Remember Me"></dx:BootstrapCheckBox>
                </div>
                <div class="mb-3">
                  <%--<button class="btn btn-primary d-grid w-100" type="submit" id="btnLogin" runat="server">Sign in</button>--%>
            <dx:BootstrapButton ID="btnLogin" runat="server" AutoPostBack="false" Text="Sign in" CssClasses-Control="btn btn-primary d-grid w-100" OnClick="btnLogin_Click"></dx:BootstrapButton>
                </div>
              </form>

             <%-- <p class="text-center">
                <span>New on our platform?</span>
                <a href="auth-register-basic.html">
                  <span>Create an account</span>
                </a>
              </p>--%>
            </div>
          </div>
          <!-- /Register -->
        </div>
      </div>
    </div>

    <!-- / Content -->

         



    <!-- Core JS -->
    <!-- build:js assets/vendor/js/core.js -->
    <script src="../sneat-1.0.0/assets/vendor/libs/jquery/jquery.js"></script>
    <script src="../sneat-1.0.0/assets/vendor/libs/popper/popper.js"></script>
    <script src="../sneat-1.0.0/assets/vendor/js/bootstrap.js"></script>
    <script src="../sneat-1.0.0/assets/vendor/libs/perfect-scrollbar/perfect-scrollbar.js"></script>

    <script src="../sneat-1.0.0/assets/vendor/js/menu.js"></script>
    <!-- endbuild -->

    <!-- Vendors JS -->

    <!-- Main JS -->
    <script src="../sneat-1.0.0/assets/js/main.js"></script>

    <!-- Page JS -->

    <!-- Place this tag in your head or just before your close body tag. -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>

   
</body>
</html>
