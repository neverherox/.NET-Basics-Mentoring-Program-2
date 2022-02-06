/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
declare @addressId int
declare @personId int

insert into Address
(Street)
values ('Yanki Kupaly')
set @addressId = @@IDENTITY

insert into Person
(FirstName, LastName)
values ('Kiryl', 'Ramashkevich')
set @personId = @@IDENTITY

insert into Employee
(AddressId, PersonId, CompanyName)
values (@addressId, @personId, 'epam')

insert into Company
(AddressId, Name)
values (@addressId, 'epam')