USE [WebApplication2Context-4a3e300f-d106-4039-830c-67e30e1ec67e]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Name], [imgPath]) VALUES (1, N'קטגוריה א', N'images/categories\14.jpeg')
INSERT [dbo].[Category] ([CategoryId], [Name], [imgPath]) VALUES (2, N'קטגוריה ב', N'images/categories\05.jpeg')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Prodact] ON 

INSERT [dbo].[Prodact] ([Id], [Name], [Price]) VALUES (1, N'מוצר א', 15)
INSERT [dbo].[Prodact] ([Id], [Name], [Price]) VALUES (2, N'מוצר ב', 10)
INSERT [dbo].[Prodact] ([Id], [Name], [Price]) VALUES (3, N'מוצר ג', 26)
INSERT [dbo].[Prodact] ([Id], [Name], [Price]) VALUES (4, N'מוצר ה', 14)
INSERT [dbo].[Prodact] ([Id], [Name], [Price]) VALUES (5, N'מוצר ו', 6)
SET IDENTITY_INSERT [dbo].[Prodact] OFF
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (1, 1)
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (2, 1)
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (1, 2)
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (2, 3)
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (1, 5)
INSERT [dbo].[CategoryProduct] ([CategoriesCategoryId], [ProdactsId]) VALUES (2, 5)
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Password], [Type], [Discriminator], [Telephone], [E_Mail]) VALUES (4, N'משתמש 2', N'12345', 0, N'Client', N'0512345699', NULL)
INSERT [dbo].[User] ([Id], [Name], [Password], [Type], [Discriminator], [Telephone], [E_Mail]) VALUES (5, N'משתמש 3', N'12345', 0, N'Client', N'0501234569', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Total], [ClientId], [userId], [Status]) VALUES (3, 10, NULL, 3, 1)
INSERT [dbo].[Order] ([Id], [Total], [ClientId], [userId], [Status]) VALUES (5, 25, NULL, 3, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[OrderProduct] ([OrdersId], [ProdactsId]) VALUES (5, 1)
INSERT [dbo].[OrderProduct] ([OrdersId], [ProdactsId]) VALUES (3, 2)
INSERT [dbo].[OrderProduct] ([OrdersId], [ProdactsId]) VALUES (5, 2)
SET IDENTITY_INSERT [dbo].[productImage] ON 

INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (1, N'images/product\01.jpeg', 1)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (2, N'images/product\02.jpeg', 2)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (3, N'images/product\03.jpeg', 3)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (4, N'images/product\05.jpeg', NULL)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (5, N'images/product\04.jpeg', 4)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (6, N'images/product\01.jpeg', NULL)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (7, N'images/product\02.jpeg', NULL)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (8, N'images/product\03.jpeg', NULL)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (9, N'images/product\01.jpeg', NULL)
INSERT [dbo].[productImage] ([Id], [Image], [ProductId]) VALUES (10, N'images/product\04.jpeg', 5)
SET IDENTITY_INSERT [dbo].[productImage] OFF
