 --Consultor: Leonardo Hern�n Goldfarb

 SELECT * 
 FROM COMP_RODC
 INNER JOIN COMP_CODC ON RODC_DIVISION = CODC_DIVISION
 AND RODC_TIPO_OC = CODC_TIPO_OC
 AND RODC_NUM_OC = CODC_NUM_OC
 INNER JOIN CPAG_PROV ON CODC_PROVEEDOR = PROV_PROVEEDOR
 INNER JOIN SIST_CIRP 
 ON RIGHT ('0000'+ CONVERT (VARCHAR,RODC_DIVISION),4) + '-'
 +'0000'  + '-' + RODC_TIPO_OC  + '-' + 
 RIGHT ('0000000000' + CONVERT(VARCHAR,RODC_NUM_OC),10)= CIRP_PK
 WHERE CIRP_SISTEMA = 'COMP'


 IF EXISTS (SELECT * FROM SIST_CIRP
 WHERE CIRP_UBIC_REPORTE_CBTE_ADJUNTO = '\\armengolsrv\Plataforma\Comprobantes_PDF')
 BEGIN
 PRINT 'EXISTO'
 END
 ELSE
 BEGIN
 PRINT 'NO EXISTO'
 END
