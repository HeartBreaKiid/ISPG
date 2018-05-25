declare @id nvarchar(128)
select @id=id
from AspNetUsers
where TipoUsuario='Estudiante'

insert into AspNetUserRoles
([UserId],[RoleId])
values(@id,4)
