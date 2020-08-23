CREATE TABLE [dbo].[Personel] (
    [PersonalId]    INT            IDENTITY (1, 1) NOT NULL,
    [PersonelAd]    NCHAR (10)     NOT NULL,
    [PersonelSoyad] NVARCHAR (50)  NOT NULL,
    [PersonelTarih] DATETIME       NOT NULL,
    [OkuduguYer]    NVARCHAR (50)  NOT NULL,
    [MezunYil]      INT            NOT NULL,
    [YasadıgıYer]   NVARCHAR (50)  NOT NULL,
    [Ozgecmis]      NVARCHAR (MAX) NOT NULL,
    [Tc] NCHAR(11) NOT NULL, 
    PRIMARY KEY CLUSTERED ([PersonalId] ASC)
);

