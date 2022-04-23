
SET IDENTITY_INSERT [dbo].[CashFlows] ON 

INSERT [dbo].[CashFlows] ([Id], [Name]) VALUES (3, N'Income')
INSERT [dbo].[CashFlows] ([Id], [Name]) VALUES (4, N'Expense')
SET IDENTITY_INSERT [dbo].[CashFlows] OFF

SET IDENTITY_INSERT [dbo].[CashFlowTypes] ON 

INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (1, 3, N'Type1')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (2, 3, N'Type2')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (3, 3, N'Type3')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (4, 4, N'Type1')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (5, 4, N'Type2')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (6, 4, N'Type3')
INSERT [dbo].[CashFlowTypes] ([Id], [CashFlowId], [TypeName]) VALUES (7, 4, N'Type4')
SET IDENTITY_INSERT [dbo].[CashFlowTypes] OFF

SET IDENTITY_INSERT [dbo].[YearMonthIncomeExpenses] ON 

INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (3, N'Jan', N'2019', 3, 100)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (4, N'Feb', N'2019', 3, 50)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (5, N'Mar', N'2019', 3, 150)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (6, N'Apr', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (7, N'May', N'2019', 3, 800)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (8, N'Jun', N'2019', 3, 50)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (9, N'Jul', N'2019', 3, 100)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (10, N'Aug', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (12, N'Sep', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (13, N'Oct', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (14, N'Dec', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (15, N'Jan', N'2019', 4, 200)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (16, N'Feb', N'2019', 4, 70)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (17, N'Mar', N'2019', 4, 120)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (18, N'Apr', N'2019', 4, 200)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (19, N'May', N'2019', 4, 300)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (20, N'Jun', N'2019', 4, 50)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (21, N'Jul', N'2019', 4, 50)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (22, N'Aug', N'2019', 4, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (23, N'Sep', N'2019', 4, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (24, N'Oct', N'2019', 4, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (25, N'Dec', N'2019', 4, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (26, N'Nov', N'2019', 3, 0)
INSERT [dbo].[YearMonthIncomeExpenses] ([Id], [Month], [Year], [CashFlowId], [Amount]) VALUES (27, N'Nov', N'2019', 4, 0)
SET IDENTITY_INSERT [dbo].[YearMonthIncomeExpenses] OFF

SET IDENTITY_INSERT [dbo].[CashFlowLogs] ON 

INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (1, 1, 1200, N'jan', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (2, 1, 52, N'apr', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (3, 2, 251, N'jan', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (4, 2, 152, N'mar', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (5, 2, 522, N'may', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (6, 3, 225, N'apr', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (7, 4, 300, N'apr', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (8, 4, 100, N'aug', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (9, 5, 200, N'jan', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (10, 5, 500, N'jun', N'2019')
INSERT [dbo].[CashFlowLogs] ([Id], [CashFlowTypeId], [Amount], [Month], [Year]) VALUES (11, 7, 250, N'mar', N'2019')
SET IDENTITY_INSERT [dbo].[CashFlowLogs] OFF


