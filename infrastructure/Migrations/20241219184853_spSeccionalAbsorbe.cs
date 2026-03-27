using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class spSeccionalAbsorbe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE dbo.spSeccionalAbsorbe
                -- Autor: alexis, Date: 18/12/2024
        
                @SeccionalAbsorbidaId int OUTPUT,
                @SeccionalAbsorbenteId int OUTPUT,
                @UserId nvarchar(40)

            AS
            BEGIN
                DECLARE @currDate DATETIME;
				DECLARE @SeccionalAbsorbidaDesc nvarchar(100);
				DECLARE @SeccionalAbsorbenteDesc nvarchar(100);

                SET @currDate = GETDATE();
				SELECT @SeccionalAbsorbidaDesc = CONCAT(codigo, descripcion) from Seccionales where id = @SeccionalAbsorbidaId;
				SELECT @SeccionalAbsorbenteDesc = CONCAT(codigo, descripcion) from Seccionales where id = @SeccionalAbsorbenteId;

                --AUDITORIA
                INSERT INTO [UatreAuditoria].dbo.[AuditoriasDatos]
                       ([Usuario]
                       ,[Tabla]
                       ,[TablaIdentificador]
                       ,[Accion]
                       ,[Cambios]
                       ,[FechaHoraAuditoria])
                 SELECT 
                       @UserId,
                       'Afiliados',
	                   Guid,
                       'Absorbido',
                       'SeccionalId: De '+CONVERT(VARCHAR(10),@SeccionalAbsorbidaId)+': '+ @SeccionalAbsorbidaDesc+' a '+
					   CONVERT(VARCHAR(10),@SeccionalAbsorbenteId)+': '+@SeccionalAbsorbenteDesc+'',
                       @currDate
                FROM Afiliados
                WHERE SeccionalId = @SeccionalAbsorbidaId

                --SECCIONALESLOCALIDADES
                UPDATE SeccionalesLocalidades set
				DeletedDate = @currDate,
				DeletedBy = @UserId ,
				DeletedObs = 'Absorción de Seccional',
                LastModifiedDate = @currDate,
                LastModifiedBy = @UserId 
                where SeccionalId = @SeccionalAbsorbidaId

                --AFILIADOS
                declare @Count int 
                select @Count=count(*) from Afiliados where SeccionalId = @SeccionalAbsorbidaId
                UPDATE Afiliados set
                SeccionalId = @SeccionalAbsorbenteId,
                LastModifiedDate = @currDate,
                LastModifiedBy = @UserId 
                where SeccionalId = @SeccionalAbsorbidaId

                --AUTORIDADES
                UPDATE SeccionalAutoridades set 
                fechavigenciahasta = @currDate,
                lastmodifiedDate = @currDate,
                LastModifiedBy = @UserId 
                where SeccionalId = @SeccionalAbsorbidaId

                return @Count
            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.spSeccionalAbsorbe");
        }
    }
}
