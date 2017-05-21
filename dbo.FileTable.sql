


USE [master]
GO

DROP TABLE [FileTable];

CREATE TABLE [dbo].[FileTable] (
	[FileId]     INT             NOT NULL,
	[FileType]   NVARCHAR (50)   NULL,
	[FileExt]    NVARCHAR (4)    NULL,
	[FileName]   NVARCHAR (50)   NULL,
	[FileFolder] NVARCHAR (50)   NULL,
	[FileData_VARBINARY]   VARBINARY (50) NULL,
	[FileData_IMAGE] IMAGE NULL, 
	[FileData_NVARCHAR] NVARCHAR(50) NULL, 
	[FileData_VARCHAR] VARCHAR(50) NULL, 
	[FileData_CHAR] CHAR(50) NULL, 
	[FileData_TEXT] TEXT NULL, 
	[FileData_NTEXT] NTEXT NULL, 
	[FileData_NCHAR] NCHAR(50) NULL, 
	PRIMARY KEY CLUSTERED ([FileId] ASC)
);

/*


--TRUNCATE TABLE [FileTable];


INSERT INTO [dbo].[FileTable] 
([FileId], [FileData_VARBINARY], [FileType], [FileExt], [FileName], [FileFolder], [FileData_NVARCHAR], [FileData_VARCHAR], [FileData_CHAR], [FileData_TEXT], [FileData_NTEXT], [FileData_NCHAR])
 VALUES (0,  CAST('A0FACBB5851C1EF1830722' AS VARBINARY (MAX)), N'SpreadSheet', N'XLS', N'1040EZ_RAK', N'Spreads', N'AB23F990BD', N'E09FF', N'AAAB008', N'00100012AB', N'7891A0B', N'911C7')

INSERT INTO [dbo].[FileTable] 
([FileId], [FileData_VARBINARY], [FileType], [FileExt], [FileName], [FileFolder], [FileData_NVARCHAR], [FileData_VARCHAR], [FileData_CHAR], [FileData_TEXT], [FileData_NTEXT], [FileData_NCHAR]) 
VALUES (2,  CAST('304A6E80FA9C87C5' AS VARBINARY (MAX)), N'SpreadSheet', N'XLS', N'1040EZ_SMI', N'Spreads', N'8FEE3CE', N'04F2B44E40', N'A0F89E6A6A60', N'00012FFAAAA', N'4DBBAD4C38', N'Aghsh')

--Image
--INSERT INTO [dbo].[FileTable] ([FileId], [FileData_VARBINARY], [FileType], [FileExt], [FileName], [FileFolder], [FileData_IMAGE], [FileData_NVARCHAR], [FileData_VARCHAR], [FileData_CHAR], [FileData_TEXT], [FileData_NTEXT], [FileData_NCHAR]) 
--VALUES (1,  CAST('32759CC4E3' AS VARBINARY (MAX)), N'SpreadSheet', N'XLS', N'1040EZ_PIK', N'Spreads', N'A288480B6CA5E', N'8B7AE1472', N'CDABB8D8CFF808', N'D23B0E690878', N'94733763CA', N'7F5A96836', N'2307AD65B2FB777')



*/

USE [master]
GO


SELECT [FileType], [FileName], [FileExt], 
		[FileData_VARBINARY],[FileData_IMAGE],[FileData_NVARCHAR], [FileData_VARCHAR], [FileData_CHAR], [FileData_TEXT], [FileData_NTEXT],[FileData_NCHAR]
FROM [FileTable]
--WHERE [FileData] IS NOT NULL