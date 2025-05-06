<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="emp_calendar.aspx.cs" Inherits="Calendar_Web.emp_calendar" %>
<%@ Register assembly="DevExpress.XtraScheduler.v23.2.Core.Desktop, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v23.2, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register assembly="DevExpress.XtraScheduler.v23.2.Core, Version=23.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">



        var lastDept = null;
        var selDept = null;
        var selEmp = null;
        
       function onUpdateClick(s, e) {
           
           
          // selDept = cmdDept.GetValue().toString();
          //// console.log("Selected Dept : - " + selDept);
          // hfSelDep.Set("hfSelDep", selDept);

           

           if (cmbEmp.InCallback())
               lastDept = cmdDept.GetValue().toString();
           else
               cmbEmp.PerformCallback(cmdDept.GetValue().toString());

           //callbackPanel.PerformCallback("All");



           BootstrapScheduler1.Refresh();


          
        }

        function onEmpUpdateClick(s, e) {

            //if (cmbEmp.GetValue() != null) {
               selEmp = cmbEmp.GetValue().toString();
            //}
            //else {

            //    selEmp = null;
            //}

            hfSelDep.Set("hfSelDep", selDept);
            hfSelEmp.Set("hfSelEmp", selEmp);

            //console.log(selEmp);

           
            callbackPanel.PerformCallback(selEmp);
            //BootstrapScheduler1.Refresh();
        }

        function OnEndCallback(s, e) {


            if (lastDept) {
                cmbEmp.PerformCallback(lastDept);
                hfSelDep.Set('hfSelDep', lastDept);
                lastDept = null;
            }
            
        }

        

        function OnEmpEndCallback(s, e) {

            if (selEmp) {

                selEmp = null;

               // console.log(selEmp);
            }
        }


    </script>

    
       
    <div class="row">
        
                <div class="col-sm-6">
                  <div class="card mb-6">
                    <dx:BootstrapComboBox ID="cmdDept" runat="server" CssClasses-Control="form-control" DataSourceID="SqlDataSource1" ClientInstanceName="cmdDept"
            TextField="name" ValueField="sap_no" NullText="- Select Department -" OnInit="cmdDept_Init" OnLoad="cmdDept_Load">
<CssClasses Control="form-control"></CssClasses>

            <ClientSideEvents SelectedIndexChanged="onUpdateClick"  EndCallback=" OnEndCallback" />
        </dx:BootstrapComboBox>
                  </div>
                </div>

        <div class="col-sm-6">
                  <div class="card mb-3">
                    <dx:BootstrapComboBox ID="cmbEmp" runat="server" CssClasses-Control="form-control"  ClientInstanceName="cmbEmp" 
            TextField="Nname" ValueField="CODEMPID" NullText ="- Select Employee -" OnCallback="cmbEmp_Callback" AllowNull="True" OnInit="cmbEmp_Init" OnLoad="cmbEmp_Load" OnDataBinding="cmbEmp_DataBinding" ForceDataBinding="True">
<CssClasses Control="form-control"></CssClasses>               
            <ClientSideEvents SelectedIndexChanged="onEmpUpdateClick" EndCallback=" OnEmpEndCallback" />

                       

        </dx:BootstrapComboBox>
                  </div>
                </div>


<%--        <div class="col-sm-2">
                  <div class="card mb-3">
                    <dx:BootstrapButton ID="btnReset" runat="server" AutoPostBack="false" Text="Reset" CssClasses-Control="btn btn-primary btn-lg" 
                        CssClasses-Icon="tf-icons bx bx-pie-chart-alt" Visible="false">
                        <ClientSideEvents Click="btnClear" />
                    </dx:BootstrapButton>
                  </div>
                </div>--%>



              </div>

   

    <dx:BootstrapCallbackPanel runat="server" ClientInstanceName="callbackPanel" OnCallback="CallbackPanel_Callback">
    <ContentCollection>
        <dx:ContentControl>

    <dx:BootstrapScheduler ID="BootstrapScheduler1" runat="server"   ClientIDMode="AutoID" ClientInstanceName="BootstrapScheduler1"
          OptionsAppearance-DefaultAppointmentColorsMode="Bootstrap" ActiveViewType="Month" Start="1752-12-31" OnInit="BootstrapScheduler1_Init" 
        OnDataBinding="BootstrapScheduler1_DataBinding" AppointmentDataSourceID="ObjectDataSource1" ResourceDataSourceID="ObjectDataSource1" >
        <CssClasses DayHeader="table-primary text-primary" Control="bg-white" DateHeader="bg-dark text-white" />
        <Views>
            <DayView ViewSelectorCaption="Day" GoToDateDialogCaption="Day Calendar" ContextMenuCaption="&amp;Day View" ViewSelectorItemAdaptivePriority="2">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>
            </DayView>

            <WorkWeekView ViewSelectorCaption="Work Week" GoToDateDialogCaption="Work Week Calendar" ContextMenuCaption="Wo&amp;rk Week View" ViewSelectorItemAdaptivePriority="6" ShowMoreButtons="False" Enabled="False">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>
            </WorkWeekView>

            <WeekView ViewSelectorCaption="Week" GoToDateDialogCaption="Week Calendar" ContextMenuCaption="&amp;Week View" ViewSelectorItemAdaptivePriority="4" ShowMoreButtons="False">
                <CssClasses TodayCellHeader="bg-dark text-white" />
            </WeekView>

            <MonthView ViewSelectorCaption="Month" GoToDateDialogCaption="Month Calendar" ContextMenuCaption="&amp;Month View" ViewSelectorItemAdaptivePriority="5">
                <CssClasses TodayCellHeader="bg-dark text-white text-center" DateCellHeader="text-white text-center" />
            </MonthView>

            <TimelineView ViewSelectorCaption="Timeline" GoToDateDialogCaption="Timeline Calendar" ContextMenuCaption="&amp;Timeline View" ViewSelectorItemAdaptivePriority="3" IntervalCount="14"></TimelineView>

            <FullWeekView ViewSelectorCaption="Full Week" GoToDateDialogCaption="Full Week Calendar" ContextMenuCaption="&amp;Full Week View" ViewSelectorItemAdaptivePriority="7">
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>
               
            </FullWeekView>

            <AgendaView ViewSelectorCaption="Agenda" GoToDateDialogCaption="Agenda Calendar" ContextMenuCaption="&amp;Agenda View" ViewSelectorItemAdaptivePriority="1" Enabled="False"></AgendaView>
        </Views>

        <OptionsAppearance>
            <ResourceColorSchemas>
                <dxwschs:SchedulerColorSchema Cell="255, 244, 188" CellBorder="243, 228, 177" CellBorderDark="234, 208, 152" CellLight="255, 255, 213" CellLightBorder="255, 239, 199" CellLightBorderDark="246, 219, 162" ResourceHeaderBackground="255, 255, 213" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="240, 240, 240" CellBorder="160, 160, 160" CellBorderDark="160, 160, 160" CellLight="255, 255, 255" CellLightBorder="160, 160, 160" CellLightBorderDark="160, 160, 160" ResourceHeaderBackground="255, 255, 255" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="179, 212, 151" CellBorder="168, 203, 138" CellBorderDark="140, 180, 104" CellLight="213, 236, 188" CellLightBorder="205, 228, 180" CellLightBorderDark="186, 209, 162" ResourceHeaderBackground="213, 236, 188" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="139, 158, 191" CellBorder="128, 147, 181" CellBorderDark="97, 116, 152" CellLight="207, 216, 230" CellLightBorder="193, 201, 219" CellLightBorderDark="161, 175, 204" ResourceHeaderBackground="207, 216, 230" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="190, 134, 161" CellBorder="180, 124, 149" CellBorderDark="156, 101, 122" CellLight="227, 203, 214" CellLightBorder="218, 189, 199" CellLightBorderDark="197, 163, 171" ResourceHeaderBackground="227, 203, 214" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="137, 177, 167" CellBorder="123, 168, 156" CellBorderDark="84, 142, 128" CellLight="193, 214, 209" CellLightBorder="174, 202, 195" CellLightBorderDark="145, 182, 173" ResourceHeaderBackground="193, 214, 209" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="247, 180, 127" CellBorder="235, 167, 113" CellBorderDark="202, 131, 71" CellLight="250, 208, 174" CellLightBorder="238, 196, 163" CellLightBorderDark="225, 166, 118" ResourceHeaderBackground="250, 208, 174" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="221, 140, 142" CellBorder="210, 129, 131" CellBorderDark="179, 100, 101" CellLight="239, 200, 201" CellLightBorder="233, 187, 189" CellLightBorderDark="222, 164, 166" ResourceHeaderBackground="239, 200, 201" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="137, 150, 132" CellBorder="129, 138, 122" CellBorderDark="102, 100, 89" CellLight="208, 216, 203" CellLightBorder="196, 207, 191" CellLightBorderDark="172, 181, 169" ResourceHeaderBackground="208, 216, 203" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="0, 199, 200" CellBorder="0, 186, 187" CellBorderDark="0, 151, 153" CellLight="168, 236, 236" CellLightBorder="144, 226, 227" CellLightBorderDark="84, 203, 204" ResourceHeaderBackground="168, 236, 236" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="168, 148, 207" CellBorder="155, 136, 194" CellBorderDark="118, 99, 155" CellLight="221, 213, 236" CellLightBorder="210, 199, 230" CellLightBorderDark="185, 169, 216" ResourceHeaderBackground="221, 213, 236" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
                <dxwschs:SchedulerColorSchema Cell="204, 204, 204" CellBorder="189, 189, 189" CellBorderDark="121, 121, 121" CellLight="230, 230, 230" CellLightBorder="204, 204, 204" CellLightBorderDark="177, 177, 177" ResourceHeaderBackground="230, 230, 230" ResourceHeaderText="0, 0, 0, 0"></dxwschs:SchedulerColorSchema>
            </ResourceColorSchemas>

        </OptionsAppearance>

        <OptionsEditing AllowAppointmentCreate="None" AllowAppointmentDelete="None" AllowAppointmentEdit="None" AllowDisplayAppointmentForm="Never" AllowInplaceEditor="None" AllowDisplayAppointmentDependencyForm="Never" AllowDisplayAppointmentFlyout="False" />

        <OptionsViewVisibleInterval>
            <OptionsCalendar AppointmentDatesHighlightMode="Labels"></OptionsCalendar>
        </OptionsViewVisibleInterval>
        <Storage>
            <Appointments AutoRetrieveId="True">
                <Labels>

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-success me-1" Text="0" TextCssClass="text-dark" />

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-info me-1" Text="1" TextCssClass="text-dark" /> <%--Personal leave--%>

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-success me-1" Text="2" TextCssClass="text-dark" /> <%--Annual Leave--%>

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-warning" Text="3" TextCssClass="text-dark" /> <%--Sick Leave--%>

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-danger" Text="4" TextCssClass="text-dark" />

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-primary me-1" Text="5" TextCssClass="text-dark" />

                    <dx:BootstrapAppointmentLabel BackgroundCssClass="bg-success" Text="6" TextCssClass="text-dark" />


                </Labels>

                <Mappings AppointmentId="CODEMPID" End="EndTime" Label="Label" Location="TYPLEAVE" Start="StartTime" Subject="NICKNAME" Description="Description" />
            </Appointments>
            <Resources>
                <%--<Mappings Caption="CODEMPID" ResourceId="ROW_NO" />--%>
                <Mappings Caption="NAMETHAI" ResourceId="CODEMPID" />
            </Resources>
        </Storage>
        <OptionsBehavior ShowFloatingActionButton="False" />

    </dx:BootstrapScheduler>   
</dx:ContentControl>
    </ContentCollection>
</dx:BootstrapCallbackPanel>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlConn %>" SelectCommand="sp_CalendarDept" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="OTD01050" Name="emp_no" SessionField="emp_no" Type="String" />
        </SelectParameters>
</asp:SqlDataSource>


    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetListEmpLeave" TypeName="ORA_BLL.Emp_leave_info">
        <SelectParameters>
            <asp:SessionParameter  Name="dept" SessionField="SelDept" Type="String" />
            <asp:SessionParameter Name="emp" SessionField="Selempno" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GeEmpInfoByDep" TypeName="ORA_BLL.empInfoBLL">
         <SelectParameters>
            <asp:ControlParameter ControlID="cmdDept" Name="dept" PropertyName="Value" Type="String"  />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <dx:ASPxHiddenField ID="hfSelDep" runat="server" ClientInstanceName="hfSelDep"></dx:ASPxHiddenField>
    <dx:ASPxHiddenField ID="hfSelEmp" runat="server" ClientInstanceName="hfSelEmp"></dx:ASPxHiddenField>
</asp:Content>
