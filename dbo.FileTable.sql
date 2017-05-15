/*


USE [master]
GO

DROP TABLE [FileTable];

CREATE TABLE [FileTable] (
    [FileId]     INT             NOT NULL,
    [FileData]   VARBINARY (MAX) NULL,
    [FileType]   NVARCHAR(50) NULL, 
    [FileExt]    NVARCHAR(4) NULL, 
    [FileName]   NVARCHAR(50) NULL, 
    [FileFolder] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([FileId] ASC)
);


*//*


TRUNCATE TABLE [FileTable];

INSERT INTO [FileTable]
(
	[FileId],[FileFolder],[FileName],[FileExt],[FileType],[FileData]
)
VALUES
(
    '3',					-- [FileId]
    'Folder',				-- [FileFolder]
    'Sheet2012-1040Smi',	-- [FileName]
    'xls',					-- [FileExt]
    'SpreadSheet',			-- [FileType]
    CAST('A0FACBB5851C1EF18307228FEE3CE911C704F2B44E40' AS VARBINARY (MAX)) -- [FileData]
)

INSERT INTO [FileTable]	([FileId],[FileFolder],[FileName],[FileExt],[FileType],[FileData])
VALUES							('2','Folder','Sheet2012-1040Rak','xls','SpreadSheet',CAST('304A6E80FA9C87C54DBBAD4C38' AS VARBINARY (MAX)))


*/

USE [master]
GO


SELECT [FileType], [FileName], [FileData], [FileExt]
FROM [FileTable]
--WHERE [FileData] IS NOT NULL