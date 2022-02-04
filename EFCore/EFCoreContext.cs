using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace EFCore
{
    public partial class EFCoreContext:DbContext
    {
        private string strConn= "Data Source=.;Initial Catalog=Medicine;Persist Security Info=True;User ID=lcac;Password=123456";


        public EFCoreContext(string strConn)
        {
            this.strConn = strConn;
        }

        /// <summary>
        /// 配置数据库连接
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            strConn = "Data Source=.;Initial Catalog=Medicine;Persist Security Info=True;User ID=lcac;Password=123456";
            optionsBuilder.UseSqlServer(strConn);
            base.OnConfiguring(optionsBuilder);
        }


        public virtual DbSet<Tab_operator> Tab_operators { get; set; }
        public virtual DbSet<dict_Comm> dict_Comms { get; set; }
        public virtual DbSet<dict_Company> dict_Companies { get; set; }
        public virtual DbSet<dict_Container> dict_Containers { get; set; }
        public virtual DbSet<dict_DecayPool> dict_DecayPools { get; set; }
        public virtual DbSet<dict_DecayPoolState> dict_DecayPoolStates { get; set; }
        public virtual DbSet<dict_Event> dict_Events { get; set; }
        public virtual DbSet<dict_Med> dict_Meds { get; set; }
        public virtual DbSet<dict_PUnit> dict_PUnits { get; set; }
        public virtual DbSet<dict_Pollutant> dict_Pollutants { get; set; }
        public virtual DbSet<dict_PollutantType> dict_PollutantTypes { get; set; }
        public virtual DbSet<dict_Position> dict_Positions { get; set; }
        public virtual DbSet<dict_Process> dict_Processes { get; set; }
        public virtual DbSet<dict_Source> dict_Sources { get; set; }
        public virtual DbSet<tb_CommLog> tb_CommLogs { get; set; }
        public virtual DbSet<tb_DecayPool> tb_DecayPools { get; set; }
        public virtual DbSet<tb_Emergency> tb_Emergencies { get; set; }
        public virtual DbSet<tb_FlowLog> tb_FlowLogs { get; set; }
        public virtual DbSet<tb_OperLog> tb_OperLogs { get; set; }
        public virtual DbSet<tb_Permission> tb_Permissions { get; set; }
        public virtual DbSet<tb_Pollutant_bf_gt> tb_Pollutant_bf_gts { get; set; }
        public virtual DbSet<tb_Pollutant_bf_qt> tb_Pollutant_bf_qts { get; set; }
        public virtual DbSet<tb_Pollutant_bf_yt> tb_Pollutant_bf_yts { get; set; }
        public virtual DbSet<tb_Pollutant_sc_gt> tb_Pollutant_sc_gts { get; set; }
        public virtual DbSet<tb_Pollutant_sc_qt> tb_Pollutant_sc_qts { get; set; }
        public virtual DbSet<tb_Pollutant_sc_yt> tb_Pollutant_sc_yts { get; set; }
        public virtual DbSet<tb_Pollutant_zs_gt_> tb_Pollutant_zs_gt_s { get; set; }
        public virtual DbSet<tb_Pollutant_zs_qt> tb_Pollutant_zs_qts { get; set; }
        public virtual DbSet<tb_Pollutant_zs_yt> tb_Pollutant_zs_yts { get; set; }
        public virtual DbSet<tb_QCFile> tb_QCFiles { get; set; }
        public virtual DbSet<tb_Ry> tb_Ries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<Tab_operator>(entity =>
            {
                entity.HasKey(e => e.opid)
                    .HasName("PK__Tab_oper__4D08CC1E5178C16C");

                entity.Property(e => e.opid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.op_code).IsUnicode(false);

                entity.Property(e => e.op_name).IsUnicode(false);

                entity.Property(e => e.op_sex).IsUnicode(false);

                entity.Property(e => e.zc).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Comm>(entity =>
            {
                entity.HasKey(e => e.CommUid)
                    .HasName("PK__dict_Com__D0F8D7027A492D02");

                entity.Property(e => e.CommUid).ValueGeneratedNever();

                entity.Property(e => e.CommCode).IsUnicode(false);

                entity.Property(e => e.CommMode).IsUnicode(false);

                entity.Property(e => e.CommName).IsUnicode(false);

                entity.Property(e => e.LocalTcpIP).IsUnicode(false);

                entity.Property(e => e.LocalTcpPort).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.RemoteTcpIP).IsUnicode(false);

                entity.Property(e => e.RemoteTcpPort).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Company>(entity =>
            {
                entity.HasKey(e => e.CompanyUid)
                    .HasName("PK__dict_Com__51C153AE40DA5616");

                entity.Property(e => e.CompanyUid).ValueGeneratedNever();

                entity.Property(e => e.CompanyCode).IsUnicode(false);

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Container>(entity =>
            {
                entity.HasKey(e => e.ContainerUid)
                    .HasName("PK__dict_Con__3D313ECB528D3FA8");

                entity.Property(e => e.ContainerUid).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.ContainerNo).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<dict_DecayPool>(entity =>
            {
                entity.HasKey(e => e.DecayPoolUid)
                    .HasName("PK__dict_Dec__44E37C12CA792D16");

                entity.Property(e => e.DecayPoolUid).ValueGeneratedNever();

                entity.Property(e => e.DecayPoolCode).IsUnicode(false);

                entity.Property(e => e.DecayPoolMax).IsUnicode(false);

                entity.Property(e => e.DecayPoolMin).IsUnicode(false);

                entity.Property(e => e.DecayPoolName).IsUnicode(false);

                entity.Property(e => e.DecayPoolPosition).IsUnicode(false);

                entity.Property(e => e.DecayPoolStandard).IsUnicode(false);

                entity.Property(e => e.DecayPoolType).IsUnicode(false);

                entity.Property(e => e.DecayPoolUnit).IsUnicode(false);

                entity.Property(e => e.DecayPoolVolume).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<dict_DecayPoolState>(entity =>
            {
                entity.HasKey(e => e.StateUid)
                    .HasName("PK__dict_Dec__AD784AB057C889E2");

                entity.Property(e => e.StateUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.StateCode).IsUnicode(false);

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Event>(entity =>
            {
                entity.Property(e => e.EventCode).IsUnicode(false);

                entity.Property(e => e.EventName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Med>(entity =>
            {
                entity.HasKey(e => e.MedUid)
                    .HasName("PK__dict_Med__83CF2670F4D665C0");

                entity.Property(e => e.MedUid).ValueGeneratedNever();

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedCompany).IsUnicode(false);

                entity.Property(e => e.MedHalfTime).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.MedStandard).IsUnicode(false);

                entity.Property(e => e.MedType).IsUnicode(false);

                entity.Property(e => e.MedUnit).IsUnicode(false);

                entity.Property(e => e.MedVolume).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<dict_PUnit>(entity =>
            {
                entity.HasKey(e => e.PUnitUid)
                    .HasName("PK__dict_PUn__96B0A725B3175E87");

                entity.Property(e => e.PUnitUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PUnitCode).IsUnicode(false);

                entity.Property(e => e.PUnitName).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Pollutant>(entity =>
            {
                entity.HasKey(e => e.PollutantUid)
                    .HasName("PK__dict_Pol__6E1B4E168F021F9F");

                entity.Property(e => e.PollutantUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCompany).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantStandard).IsUnicode(false);

                entity.Property(e => e.PollutantType).IsUnicode(false);

                entity.Property(e => e.PollutantUnit).IsUnicode(false);

                entity.Property(e => e.PollutantVolume).IsUnicode(false);
            });

            modelBuilder.Entity<dict_PollutantType>(entity =>
            {
                entity.HasKey(e => e.PollutantTypeUid)
                    .HasName("PK__dict_Pol__8BC08ACF9C3B6A33");

                entity.Property(e => e.PollutantTypeUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantType).IsUnicode(false);

                entity.Property(e => e.PollutantTypeCode).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Position>(entity =>
            {
                entity.HasKey(e => e.PositionUid)
                    .HasName("PK__dict_Pos__3BADBFC203469F52");

                entity.Property(e => e.PositionUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.PositionNo).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Process>(entity =>
            {
                entity.HasKey(e => e.ProcessUid)
                    .HasName("PK__dict_Pro__2F5E8B7636B5C1AA");

                entity.Property(e => e.ProcessUid).ValueGeneratedNever();

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.ProcessCode).IsUnicode(false);

                entity.Property(e => e.ProcessName).IsUnicode(false);

                entity.Property(e => e.ProcessNext).IsUnicode(false);

                entity.Property(e => e.ProcessNo).IsUnicode(false);

                entity.Property(e => e.ProcessType).IsUnicode(false);
            });

            modelBuilder.Entity<dict_Source>(entity =>
            {
                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.SourceNo).IsUnicode(false);
            });

            modelBuilder.Entity<tb_CommLog>(entity =>
            {
                entity.HasKey(e => e.CommLogUID)
                    .HasName("PK__tb_CommL__809770EB9ED648D2");

                entity.Property(e => e.CommLogUID).ValueGeneratedNever();

                entity.Property(e => e.CommContent).IsUnicode(false);

                entity.Property(e => e.CommFlow).IsUnicode(false);

                entity.Property(e => e.CommType).IsUnicode(false);
            });

            modelBuilder.Entity<tb_DecayPool>(entity =>
            {
                entity.HasKey(e => e.DecayPoolUID)
                    .HasName("PK__tb_Decay__44E2781AFA4580EA");

                entity.Property(e => e.DecayPoolUID).ValueGeneratedNever();

                entity.Property(e => e.DecayPoolCode).IsUnicode(false);

                entity.Property(e => e.DecayPoolName).IsUnicode(false);

                entity.Property(e => e.IntervalTime).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.OtherWater).IsUnicode(false);

                entity.Property(e => e.PreWater).IsUnicode(false);

                entity.Property(e => e.RecordNo).IsUnicode(false);

                entity.Property(e => e.ReferValue).IsUnicode(false);

                entity.Property(e => e.WaterTotal).IsUnicode(false);

                entity.Property(e => e.WorkMode).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Emergency>(entity =>
            {
                entity.HasKey(e => e.EmergencyUID)
                    .HasName("PK__tb_Emerg__41B8A3D685E37892");

                entity.Property(e => e.EmergencyUID).ValueGeneratedNever();

                entity.Property(e => e.EventCode).IsUnicode(false);

                entity.Property(e => e.EventName).IsUnicode(false);

                entity.Property(e => e.EventNo).IsUnicode(false);

                entity.Property(e => e.EventPosition).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.ProcessCode).IsUnicode(false);

                entity.Property(e => e.ProcessName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_FlowLog>(entity =>
            {
                entity.HasKey(e => e.FlowLogUID)
                    .HasName("PK__tb_FlowL__F2A2D78DC88B84E6");

                entity.Property(e => e.FlowLogUID).ValueGeneratedNever();

                entity.Property(e => e.FlowContent).IsUnicode(false);

                entity.Property(e => e.FlowName).IsUnicode(false);

                entity.Property(e => e.FlowType).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<tb_OperLog>(entity =>
            {
                entity.HasKey(e => e.OperLogUID)
                    .HasName("PK__tb_OperL__3838BA17EAEC18A8");

                entity.Property(e => e.OperLogUID).ValueGeneratedNever();

                entity.Property(e => e.OperContent).IsUnicode(false);

                entity.Property(e => e.OperType).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Permission>(entity =>
            {
                entity.Property(e => e.ryCode).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_bf_gt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy2");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_bf_qt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy8");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_bf_yt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy5");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_sc_gt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_sc_qt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy6");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_sc_yt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy3");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_zs_gt_>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy1");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_zs_qt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy7");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Pollutant_zs_yt>(entity =>
            {
                entity.HasKey(e => e.PollutantUID)
                    .HasName("PK__tb_Pollu__6E1A520E04FF4EBC_copy4");

                entity.Property(e => e.PollutantUID).ValueGeneratedNever();

                entity.Property(e => e.ContainerCode).IsUnicode(false);

                entity.Property(e => e.ContainerName).IsUnicode(false);

                entity.Property(e => e.MedClearTime).IsUnicode(false);

                entity.Property(e => e.MedCode).IsUnicode(false);

                entity.Property(e => e.MedName).IsUnicode(false);

                entity.Property(e => e.Memo).IsUnicode(false);

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.PollutantCode).IsUnicode(false);

                entity.Property(e => e.PollutantCount).IsUnicode(false);

                entity.Property(e => e.PollutantName).IsUnicode(false);

                entity.Property(e => e.PollutantNo).IsUnicode(false);

                entity.Property(e => e.PositionCode).IsUnicode(false);

                entity.Property(e => e.PositionName).IsUnicode(false);

                entity.Property(e => e.ProcessUser).IsUnicode(false);

                entity.Property(e => e.SourceCode).IsUnicode(false);

                entity.Property(e => e.SourceName).IsUnicode(false);

                entity.Property(e => e.UnitCode).IsUnicode(false);

                entity.Property(e => e.UnitName).IsUnicode(false);
            });

            modelBuilder.Entity<tb_QCFile>(entity =>
            {
                entity.HasKey(e => e.QCUID)
                    .HasName("PK__tb_QCFil__C8BEB7FE87CF1448");

                entity.Property(e => e.QCUID).ValueGeneratedNever();

                entity.Property(e => e.OperUser).IsUnicode(false);

                entity.Property(e => e.QCCode).IsUnicode(false);

                entity.Property(e => e.QCFile).IsUnicode(false);

                entity.Property(e => e.QCFormat).IsUnicode(false);

                entity.Property(e => e.QCName).IsUnicode(false);

                entity.Property(e => e.QCPath).IsUnicode(false);

                entity.Property(e => e.QCRoot).IsUnicode(false);

                entity.Property(e => e.QCType).IsUnicode(false);
            });

            modelBuilder.Entity<tb_Ry>(entity =>
            {
                entity.HasKey(e => e.ryId)
                    .HasName("PK__tb_Ry__D327D4FA376B7F90");

                entity.Property(e => e.ryId).ValueGeneratedNever();

                entity.Property(e => e.ryAge).IsUnicode(false);

                entity.Property(e => e.ryCode).IsUnicode(false);

                entity.Property(e => e.ryMemo).IsUnicode(false);

                entity.Property(e => e.ryName).IsUnicode(false);

                entity.Property(e => e.rySex).IsUnicode(false);

                entity.Property(e => e.ryZc).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    }

}
