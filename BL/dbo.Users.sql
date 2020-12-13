CREATE TABLE [dbo].[Users] (
    [ID]       INT            NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Gender]   NVARCHAR       NOT NULL,
    [Birth]    INT            NOT NULL,
    [Weight]   FLOAT (53)     NOT NULL,
    [Height]   FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
   
);




