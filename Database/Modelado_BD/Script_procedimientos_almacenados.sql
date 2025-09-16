DROP PROCEDURE IF EXISTS sp_devolver_municipios_por_departamento;
DELIMITER //
CREATE PROCEDURE sp_devolver_municipios_por_departamento(iNId_departamento INT)
BEGIN
	SELECT mun.Id_municipio AS IdMunicipio, mun.Municipio, mun.Departamento_al_que_pertenece AS 'DepartamentoAlQuePertenece'
    FROM tb_municipios AS mun
    WHERE Departamento_al_que_pertenece = iNId_departamento;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS sp_devolver_barrios_por_municipio;
DELIMITER //
CREATE PROCEDURE sp_devolver_barrios_por_municipio(iNId_municipio INT)
BEGIN
	SELECT barr.Id_barrio AS IdBarrio, barr.Barrio, barr.Municipio_al_que_pertenece AS 'MunicipioAlQuePertenece'
    FROM tb_barrios as barr
    WHERE Municipio_al_que_pertenece = iNId_municipio;
END //
DELIMITER ;
