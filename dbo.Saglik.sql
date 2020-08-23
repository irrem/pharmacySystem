CREATE TABLE [dbo].[Saglik] (
    [SaglikId]          INT            IDENTITY (1, 1) NOT NULL,
    [AgizDis]           NVARCHAR (MAX) NULL,
    [KulakBurunBogaz]   NVARCHAR (MAX) NULL,
    [Cildiye]           NVARCHAR (MAX) NULL,
    [Diyet]             NVARCHAR (MAX) NULL,
    [Vitamin Takviyesi] NVARCHAR (MAX) NULL,
    [Alerjiler]         NVARCHAR (MAX) NULL,
    [MideHastalik]      NVARCHAR (MAX) NULL,
    [Sac]               NVARCHAR (MAX) NULL,
    [BebekBakim]        NVARCHAR (MAX) NULL,
    [Vücut]             NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([SaglikId] ASC)
);

