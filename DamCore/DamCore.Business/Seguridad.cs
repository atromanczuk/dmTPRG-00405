using DamCore.Common;
using DamCore.DamExceptions;
using DamCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamCore.Business
{
    public static class Seguridad
    {
        public static string DesencriptoContraseña(string sPlPwd)
        {
            try
            {

                Int32 i;
                string sVlCadenaAux;
                string sVlCadenaPares;
                string sVlCadenaImpares;
                string sVlCadenaFinal;


                string cadenaAux2 = "";


                sVlCadenaAux = "";
                sVlCadenaPares = "";
                sVlCadenaImpares = "";
                sVlCadenaFinal = "";


                sVlCadenaAux = sPlPwd;

                cadenaAux2 = "";

                //invierto la cadena
                for (i = sVlCadenaAux.Length - 1; i >= 0; i--)
                {
                    cadenaAux2 = cadenaAux2 + sVlCadenaAux.Substring(i, 1);
                }


                //SEPARO EN DOS LA CADENA

                sVlCadenaPares = cadenaAux2.Substring(0, (cadenaAux2.Length / 2));

                sVlCadenaImpares = cadenaAux2.Substring((cadenaAux2.Length / 2));



                //SE UNIFICAN LAS DOS CADENAS EN 1

                i = 0;
                cadenaAux2 = "";

                while (i < sVlCadenaPares.Length)
                {
                    cadenaAux2 = cadenaAux2 + sVlCadenaPares[i].ToString() + sVlCadenaImpares[i].ToString();
                    i = i + 1;
                }

                //SE TRADUCE DE HEXA A STRING   
                sVlCadenaFinal = "";

                int numberChars = cadenaAux2.Length;
                byte[] bytes = new byte[numberChars / 2];
                for (int ind = 0; ind < numberChars; ind += 2)
                {
                    bytes[ind / 2] = Convert.ToByte(cadenaAux2.Substring(ind, 2), 16);
                }

                sVlCadenaFinal = Encoding.GetEncoding("ISO-8859-1").GetString(bytes);


                return sVlCadenaFinal;
            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }


        public static void ValidarPermisosUsuario(string Programa = "")
        {
            try
            {


                new operacionesPF().VerificoPermisosUsuario(Programa);

            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }


        public static void validoExistenciaUsuario(UsuarioPF usuario)
        {


            try
            {


                UsuarioPF usuarioAux = new operacionesPF().getUsuario(usuario);

                if (usuarioAux == null)
                {
                    throw new BusinessException("Usuario no registado en el sistema", new Exception());
                }

                if (usuarioAux.getContraseñaComprobantes().Length == 0)
                {
                    throw new BusinessException("La contraseña de comprobantes del usuario indicado no está cargada.", new Exception());
                }


            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }


        public static bool ValidoPasswordIngresada(string Clave, string programa, string Usuario)
        {

            try
            {
                string passwordEncriptada;
                string passwordComparacion;

                passwordEncriptada = EncriptoContraseña(Usuario + Clave);
                //passwordComparacion = new BusinessParametrosGenerales().buscoParametro("CONTRASEÑA_HABILITACION_CARGA_MANUAL", programa).getValorParametro();
                passwordComparacion = new operacionesPF().ObtengoContraseñaUsuario(Usuario);
                if (passwordEncriptada == passwordComparacion)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public static string EncriptoContraseña(string sPlPwd)
        {
            try
            {
                Int32 i;
                string sVlCadenaAux;
                string sVlCadenaPares;
                string sVlCadenaImpares;
                string sVlCadenaFinal;

                //'Paso a hexadecimal caracter a caracter 
                //'Ej: AJHR se convierte a 414A4852

                sVlCadenaAux = "";
                sVlCadenaPares = "";
                sVlCadenaImpares = "";
                sVlCadenaFinal = "";



                string hex = "";
                foreach (char c in sPlPwd)
                {
                    int tmp = c;
                    hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
                }
                sVlCadenaAux = hex.ToUpper();
                //return hex;
                //for (i = 0; i < sPlPwd.Length;i++ )
                //{
                //    sVlCadenaAux = sVlCadenaAux + StringToHex(sPlPwd.Substring(i,1));
                //}
                //'Luego se separan los caracteres de posiciones pares e impares en 2 string y se los concatena.
                //'Ej.: 4445 y 1A82

                for (i = 0; i < sVlCadenaAux.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sVlCadenaPares = sVlCadenaPares + sVlCadenaAux.Substring(i, 1);
                    }
                    else
                    {
                        sVlCadenaImpares = sVlCadenaImpares + sVlCadenaAux.Substring(i, 1);
                    }

                }

                sVlCadenaAux = sVlCadenaPares + sVlCadenaImpares;

                //'Finalmente la cadena se invierte.
                //'Ej.: 28A15444
                sVlCadenaFinal = "";
                for (i = sVlCadenaAux.Length - 1; i >= 0; i--)
                {
                    sVlCadenaFinal = sVlCadenaFinal + sVlCadenaAux.Substring(i, 1);
                }

                return sVlCadenaFinal;
            }
            catch (BusinessException be)
            {
                throw new BusinessException(be.Message, be);
            }

            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }


    }

}
