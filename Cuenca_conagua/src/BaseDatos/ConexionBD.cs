﻿using Cuenca_conagua.src.Entidades;
using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.BaseDatos
{
    /// <summary>
    /// Esta clase es la que realiza la conexión con la base de datos, así como 
    /// las acciones del CRUD para las tablas de la misma.
    /// </summary>
    public class ConexionBD
    {
        /// <summary>
        /// Constante que indica el volumen asignado DR.
        /// </summary>
        public const int VOL_DR_ASIGNADO = 0;

        /// <summary>
        /// Constante que indica el volumen autorizado DR.
        /// </summary>
        public const int VOL_DR_AUTORIZADO = 1;

        /// <summary>
        /// Constante que indica el volumen utilizado DR.
        /// </summary>
        public const int VOL_DR_UTILIZADO = 2;

        /// <summary>
        /// Constante que indica el volumen asignado PI.
        /// </summary>
        public const int VOL_PI_ASIGNADO = 3;

        /// <summary>
        /// Constante que indica el volumen autorizado PI.
        /// </summary>
        public const int VOL_PI_AUTORIZADO = 4;

        /// <summary>
        /// Constante que indica el volumen asignado PI.
        /// </summary>
        public const int VOL_PI_UTILIZADO = 5;

        public const int VOL_GT_ASIGNADO = 6;

        public const int VOL_GT_AUTORIZADO = 7;

        public const int VOL_GT_UTILIZADO = 8;

        public const int VOL_AG_ASIGNADO = 9;

        public const int VOL_AG_AUTORIZADO = 10;

        public const int VOL_AG_UTILIZADO = 11;

        /// <summary>
        /// Es la cadena de conexion con la BD.
        /// </summary>
        private static string connectionString;

        /// <summary>
        /// Es el objeto de conexion con la BD.
        /// </summary>
        private static SqlConnection conexion;

        /// <summary>
        /// Inicia la conexión con la base de datos, en caso de que aún no se haga.
        /// </summary>
        public static void InitConnection()
        {
            if (conexion == null)
            {
                connectionString = ConfigurationManager
                    .ConnectionStrings["sqlConnectionString"].ConnectionString;
                Logger.AddToLog(connectionString, true);
                //connectionString = "Data Source=PORFIRIO\\SQLEXPRESS;Initial Catalog=cuenca_conagua;Integrated Security=True";
                conexion = new SqlConnection(connectionString);
            }
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        /// <summary>
        /// Cierra la conexión con la base de datos, en caso de que este abierta.
        /// </summary>
        public static void CloseConnection()
        {
            if (conexion != null)
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        /// <summary>
        /// Devuelve el almacenamiento histórico de chapala con la fecha dada.
        /// </summary>
        /// <param name="fecha">
        /// Es la fecha que identifica al registro.
        /// </param>
        /// <returns>
        /// El almacenamiento buscado en caso de ser encontrado, o null si no 
        /// </returns>
        public static AlmacenamientoHistoricoChapala GetAlmacenamientoHistoricoChapala(DateTime fecha)
        {
            InitConnection();

            string query = "SELECT * FROM [almacenamiento_historico_chapala] " +
                "WHERE fecha=@fecha";
            SqlCommand command = new SqlCommand(query, conexion);
            string formatedDate = DateUtils.ConvertDateTimeToSqlDate(fecha);
            command.Parameters.AddWithValue("@fecha", formatedDate);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                AlmacenamientoHistoricoChapala alm = null;

                if (reader.Read())
                {
                    alm = new AlmacenamientoHistoricoChapala();
                    alm.Fecha = reader.GetDateTime(0);
                    alm.Almacenamiento = double.Parse(reader.GetValue(1).ToString());
                }

                reader.Close();
                return alm;
            }
        }

        /// <summary>
        /// Inserta un registro a la tabla almacenamiento_historico_chapala.
        /// </summary>
        /// <param name="alm">
        /// Es el registro de almacenamiento histórico de chapala a ingresar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado o false si no se pudo insertar.
        /// </returns>
        public static bool InsertarAlmacenamientoHistoricoChapala(AlmacenamientoHistoricoChapala alm)
        {
            InitConnection();
            bool insertado = false;

            string formatedDate = DateUtils.ConvertDateTimeToSqlDate(alm.Fecha);

            string sql = string.Format("INSERT INTO " +
                "almacenamiento_historico_chapala VALUES('{0}', {1})",
                formatedDate, alm.Almacenamiento);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetAlmacenamientoHistoricoChapala(alm.Fecha) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }

            return insertado;
        }

        /// <summary>
        /// Devuelve todos los registros de almacenamientos históricos de 
        /// chapala.
        /// </summary>
        /// <returns>
        /// Una lista con los almacenamientos históricos de chapala.
        /// </returns>
        public static List<AlmacenamientoHistoricoChapala> GetAllAlmacenamientoHistoricoChapala()
        {
            InitConnection();
            string query = "SELECT * FROM [almacenamiento_historico_chapala]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<AlmacenamientoHistoricoChapala> alms = new List<AlmacenamientoHistoricoChapala>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                AlmacenamientoHistoricoChapala alm = null;

                while (reader.Read())
                {
                    alm = new AlmacenamientoHistoricoChapala();
                    alm.Fecha = reader.GetDateTime(0);
                    alm.Almacenamiento = double.Parse(reader.GetValue(1).ToString());
                    alms.Add(alm);
                }

                reader.Close();
            }

            return alms;
        }

        /// <summary>
        /// Devuelve el almacenamiento principal con el año dado.
        /// </summary>
        /// <param name="anio">
        /// Es el año que identifica al registro.
        /// </param>
        /// <returns>
        /// El almacenamiento buscado en caso de ser encontrado, o null si no 
        /// existe.
        /// </returns>
        public static AlmacenamientoPrincipal GetAlmacenamientoPrincipal(string anio)
        {
            InitConnection();

            string query = "SELECT * FROM [almacenamientos_principales] " +
                "WHERE anio=@anio";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@anio", anio);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                AlmacenamientoPrincipal alm = null;

                if (reader.Read())
                {
                    alm = ReadAlmPrincipalFromReader(reader);
                }

                reader.Close();
                return alm;
            }
        }

        /// <summary>
        /// Inserta un registro a la tabla almacenamientos_principales.
        /// </summary>
        /// <param name="alm">
        /// Es el registro de almacenamiento principal a ingresar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado o false si no se pudo insertar.
        /// </returns>
        public static bool InsertarAlmacenamientoPrincipal(AlmacenamientoPrincipal alm)
        {
            InitConnection();
            bool insertado = false;

            string sql = string.Format("INSERT INTO " +
                "almacenamientos_principales VALUES('{0}', {1}, {2}, {3}, " +
                "{4}, {5}, {6}, {7}, {8}, {9}, {10})", alm.Anio, alm.Alzate,
                alm.Ramirez, alm.Tepetitlan, alm.Tepuxtepec, alm.Solis,
                alm.Yuriria, alm.Allende, alm.MOcampo, alm.Purisima,
                alm.Chapala);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetAlmacenamientoPrincipal(alm.Anio) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }
            return insertado;
        }

        /// <summary>
        /// Devuelve todos los registros de almacenamientos principales.
        /// </summary>
        /// <returns>
        /// Una lista con los almacenamientos principales.
        /// </returns>
        public static List<AlmacenamientoPrincipal> GetAllAlmacenamientoPrincipal()
        {
            InitConnection();
            string query = "SELECT * FROM [almacenamientos_principales]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<AlmacenamientoPrincipal> alms = new List<AlmacenamientoPrincipal>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                AlmacenamientoPrincipal alm = null;
                while (reader.Read())
                {
                    alm = ReadAlmPrincipalFromReader(reader);
                    alms.Add(alm);
                }
                reader.Close();
            }
            return alms;
        }

        /// <summary>
        /// Lee los datos de un almacenamiento principal a partir de un
        /// SqlDataReader que contiene un registro de la tabla 
        /// almacenamientos_principales.
        /// </summary>
        /// <param name="reader">
        /// Es el reader que contiene el registro leido.
        /// </param>
        /// <returns>
        /// Instancia de AlmacenamientoPrincipal generada a partir del reader.
        /// </returns>
        private static AlmacenamientoPrincipal ReadAlmPrincipalFromReader(SqlDataReader reader)
        {
            AlmacenamientoPrincipal alm = new AlmacenamientoPrincipal();
            alm.Anio = reader.GetString(0);
            alm.Alzate = double.Parse(reader.GetValue(1).ToString());
            alm.Ramirez = double.Parse(reader.GetValue(2).ToString());
            alm.Tepetitlan = double.Parse(reader.GetValue(3).ToString());
            alm.Tepuxtepec = double.Parse(reader.GetValue(4).ToString());
            alm.Solis = double.Parse(reader.GetValue(5).ToString());
            alm.Yuriria = double.Parse(reader.GetValue(6).ToString());
            alm.Allende = double.Parse(reader.GetValue(7).ToString());
            alm.MOcampo = double.Parse(reader.GetValue(8).ToString());
            alm.Purisima = double.Parse(reader.GetValue(9).ToString());
            alm.Chapala = double.Parse(reader.GetValue(10).ToString());
            return alm;
        }

        /// <summary>
        /// Inserta un registro a la tabla de precipitacion_ma.
        /// </summary>
        /// <param name="pm">
        /// Es el registro de precipitación media a ingresar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado o false si no se pudo insertar.
        /// </returns>
        public static bool InsertarPrecipitacionMedia(PrecipitacionMedia pm)
        {
            InitConnection();
            bool insertado = false;
            string sql = string.Format("INSERT INTO precipitacion_ma VALUES("
                + "'{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, "
                + "{11}, {12})", pm.Ciclo, pm.Nov, pm.Dic, pm.Ene, pm.Feb, pm.Mar,
                pm.Abr, pm.May, pm.Jun, pm.Jul, pm.Ago, pm.Sep, pm.Oct);
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;
            if (GetPrecipitacionMedia(pm.Ciclo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }
            return insertado;
        }

        /// <summary>
        /// Devuelve la precipitación media con el ciclo dado, o null si no 
        /// existe ningún registro con ese ciclo.
        /// </summary>
        /// <param name="ciclo">Es el ciclo que identifica al registro.</param>
        /// <returns>
        /// La precipitación media buscada.
        /// </returns>
        public static PrecipitacionMedia GetPrecipitacionMedia(string ciclo)
        {
            InitConnection();
            string query = "SELECT * FROM [precipitacion_ma] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);
            //Logger.AddToLog(command.CommandText, true);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                PrecipitacionMedia pm = null;
                if (reader.Read())
                {
                    pm = new PrecipitacionMedia();
                    pm.Ciclo = reader.GetString(0);
                    pm.Nov = double.Parse(reader.GetValue(1).ToString());
                    pm.Dic = double.Parse(reader.GetValue(2).ToString());
                    pm.Ene = double.Parse(reader.GetValue(3).ToString());
                    pm.Feb = double.Parse(reader.GetValue(4).ToString());
                    pm.Mar = double.Parse(reader.GetValue(5).ToString());
                    pm.Abr = double.Parse(reader.GetValue(6).ToString());
                    pm.May = double.Parse(reader.GetValue(7).ToString());
                    pm.Jun = double.Parse(reader.GetValue(8).ToString());
                    pm.Jul = double.Parse(reader.GetValue(9).ToString());
                    pm.Ago = double.Parse(reader.GetValue(10).ToString());
                    pm.Sep = double.Parse(reader.GetValue(11).ToString());
                    pm.Oct = double.Parse(reader.GetValue(12).ToString());
                }
                reader.Close();
                return pm;
            }
        }

        /// <summary>
        /// Devuelve todos los registros de precipitación media.
        /// </summary>
        /// <returns>
        /// Una lista con las precipitaciones medias.
        /// </returns>
        public static List<PrecipitacionMedia> GetAllPrecipitacionMedia()
        {
            InitConnection();
            string query = "SELECT * FROM [precipitacion_ma]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<PrecipitacionMedia> pms = new List<PrecipitacionMedia>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                PrecipitacionMedia pm = null;
                while (reader.Read())
                {
                    pm = new PrecipitacionMedia();
                    pm.Ciclo = reader.GetString(0);
                    pm.Nov = double.Parse(reader.GetValue(1).ToString());
                    pm.Dic = double.Parse(reader.GetValue(2).ToString());
                    pm.Ene = double.Parse(reader.GetValue(3).ToString());
                    pm.Feb = double.Parse(reader.GetValue(4).ToString());
                    pm.Mar = double.Parse(reader.GetValue(5).ToString());
                    pm.Abr = double.Parse(reader.GetValue(6).ToString());
                    pm.May = double.Parse(reader.GetValue(7).ToString());
                    pm.Jun = double.Parse(reader.GetValue(8).ToString());
                    pm.Jul = double.Parse(reader.GetValue(9).ToString());
                    pm.Ago = double.Parse(reader.GetValue(10).ToString());
                    pm.Sep = double.Parse(reader.GetValue(11).ToString());
                    pm.Oct = double.Parse(reader.GetValue(12).ToString());
                    pms.Add(pm);
                }
                reader.Close();
            }
            return pms;
        }

        /// <summary>
        /// Inserta un administrador a la base de datos.
        /// </summary>
        /// <param name="adm">
        /// Es la instancia correspondiente del administrador a insertar.
        /// </param>
        /// <returns>
        /// true si el administrador se inserto de manera correcta o false
        /// si no se pudo insertar.
        /// </returns>
        public static bool InsertarAdministrador(Administrador adm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtiene el administrador con el nombre de usuario dado.
        /// </summary>
        /// <param name="nombreUsuario">
        /// Es el nombre del usuario del administrador a buscar.
        /// </param>
        /// <returns>
        /// La instancia del administrador buscado o null si el administrador
        /// no fue encontrado.
        /// </returns>
        public static Administrador GetAdministrador(string nombreUsuario)
        {
            InitConnection();
            string query = "SELECT * FROM [administrador] WHERE "
                + "nombre_usuario=@nombreUsuario";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                Administrador admin = null;
                if (reader.Read())
                {
                    admin = new Administrador();
                    admin.NombreUsuario = reader.GetString(0);
                    admin.Password = reader.GetString(1);
                }
                reader.Close();
                return admin;
            }
        }

        /// <summary>
        /// Inserta un registro de escurrimiento anual a la base de datos.
        /// </summary>
        /// <param name="ea">
        /// Es la instancia correspondiente del escurrimiento anual a insertar.
        /// </param>
        /// <returns>
        /// true si el escurrimiento anual se inserto de manera correcta o false
        /// si no se pudo insertar.
        /// </returns>
        public static bool InsertarEscurrimientoAnual(
            EscurrimientoAnual ea)
        {
            InitConnection();
            bool insertado = false;
            string sql = string.Format("INSERT INTO escurrimiento_anual "
                + "VALUES('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, "
                + "{10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})", ea.Ciclo,
                ea.Alzate, ea.Ramirez, ea.Tepetitlan, ea.Tepuxtepec, ea.Solis,
                ea.Begona, ea.Ameche, ea.Pericos, ea.Yuriria, ea.Salamanca,
                ea.Adjuntas, ea.Angulo, ea.Corrales, ea.Yurecuaro, ea.Duero,
                ea.Zula, ea.Chapala);
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;
            if (GetEscurrimientoAnual(ea.Ciclo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }
            return insertado;
        }

        /// <summary>
        /// Devuelve todos los registros de escurrimiento anual.
        /// </summary>
        /// <returns>
        /// Una lista con los escurrimientos anuales.
        /// </returns>
        public static List<EscurrimientoAnual> GetAllEscurrimientoAnual()
        {
            InitConnection();
            string query = "SELECT * FROM [escurrimiento_anual]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<EscurrimientoAnual> eas = new List<EscurrimientoAnual>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                EscurrimientoAnual ea = null;
                while (reader.Read())
                {
                    ea = new EscurrimientoAnual();
                    ea.Ciclo = reader.GetValue(0).ToString();
                    ea.Alzate = double.Parse(reader.GetValue(1).ToString());
                    ea.Ramirez = double.Parse(reader.GetValue(2).ToString());
                    ea.Tepetitlan = double.Parse(reader.GetValue(3).ToString());
                    ea.Tepuxtepec = double.Parse(reader.GetValue(4).ToString());
                    ea.Solis = double.Parse(reader.GetValue(5).ToString());
                    ea.Begona = double.Parse(reader.GetValue(6).ToString());
                    ea.Ameche = double.Parse(reader.GetValue(7).ToString());
                    ea.Pericos = double.Parse(reader.GetValue(8).ToString());
                    ea.Yuriria = double.Parse(reader.GetValue(9).ToString());
                    ea.Salamanca = double.Parse(reader.GetValue(10).ToString());
                    ea.Adjuntas = double.Parse(reader.GetValue(11).ToString());
                    ea.Angulo = double.Parse(reader.GetValue(12).ToString());
                    ea.Corrales = double.Parse(reader.GetValue(13).ToString());
                    ea.Yurecuaro = double.Parse(reader.GetValue(14).ToString());
                    ea.Duero = double.Parse(reader.GetValue(15).ToString());
                    ea.Zula = double.Parse(reader.GetValue(16).ToString());
                    ea.Chapala = double.Parse(reader.GetValue(17).ToString());
                    eas.Add(ea);
                }
                reader.Close();
            }
            return eas;
        }

        /// <summary>
        /// Devuelve el registro del escurrimiento anual para el ciclo dado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el ciclo a buscar
        /// </param>
        /// <returns>
        /// La instancia del escurrimiento anual buscado o null si el
        /// escurrimiento anual para el ciclo dado no fue encontrado.
        /// </returns>
        public static EscurrimientoAnual GetEscurrimientoAnual(string ciclo)
        {
            InitConnection();
            string query = "SELECT * FROM [escurrimiento_anual] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                EscurrimientoAnual ea = null;
                if (reader.Read())
                {
                    ea = new EscurrimientoAnual();
                    ea.Ciclo = reader.GetValue(0).ToString();
                    ea.Alzate = double.Parse(reader.GetValue(1).ToString());
                    ea.Ramirez = double.Parse(reader.GetValue(2).ToString());
                    ea.Tepetitlan = double.Parse(reader.GetValue(3).ToString());
                    ea.Tepuxtepec = double.Parse(reader.GetValue(4).ToString());
                    ea.Solis = double.Parse(reader.GetValue(5).ToString());
                    ea.Begona = double.Parse(reader.GetValue(6).ToString());
                    ea.Ameche = double.Parse(reader.GetValue(7).ToString());
                    ea.Pericos = double.Parse(reader.GetValue(8).ToString());
                    ea.Yuriria = double.Parse(reader.GetValue(9).ToString());
                    ea.Salamanca = double.Parse(reader.GetValue(10).ToString());
                    ea.Adjuntas = double.Parse(reader.GetValue(11).ToString());
                    ea.Angulo = double.Parse(reader.GetValue(12).ToString());
                    ea.Corrales = double.Parse(reader.GetValue(13).ToString());
                    ea.Yurecuaro = double.Parse(reader.GetValue(14).ToString());
                    ea.Duero = double.Parse(reader.GetValue(15).ToString());
                    ea.Zula = double.Parse(reader.GetValue(16).ToString());
                    ea.Chapala = double.Parse(reader.GetValue(17).ToString());
                }
                reader.Close();
                return ea;
            }
        }

        /// <summary>
        /// Devuelve el nombre correspondiente de las tablas de volumen
        /// dependiendo del tipo dado.
        /// </summary>
        /// <param name="tipo">
        /// Es el tipo a buscar.
        /// </param>
        /// <returns>
        /// El nombre de la tabla correspondiente o null, si no existe una
        /// tabla asociada al tipo dado.
        /// </returns>
        private static string GetNombreTablaVolumen(int tipo, string sufijo="")
        {
            switch (tipo)
            {
                case VOL_DR_ASIGNADO:
                    return "volumen_dr_asignado" + sufijo;
                case VOL_DR_AUTORIZADO:
                    return "volumen_dr_autorizado" + sufijo;
                case VOL_DR_UTILIZADO:
                    return "volumen_dr_utilizado" + sufijo;
                case VOL_PI_ASIGNADO:
                    return "volumen_pi_asignado" + sufijo;
                case VOL_PI_AUTORIZADO:
                    return "volumen_pi_autorizado" + sufijo;
                case VOL_PI_UTILIZADO:
                    return "volumen_pi_utilizado" + sufijo;
                case VOL_GT_ASIGNADO:
                    return "volumen_gt_asignado" + sufijo;
                case VOL_GT_AUTORIZADO:
                    return "volumen_gt_autorizado" + sufijo;
                case VOL_GT_UTILIZADO:
                    return "volumen_gt_utilizado" + sufijo;
                case VOL_AG_ASIGNADO:
                    return "volumen_ag_asignado" + sufijo;
                case VOL_AG_AUTORIZADO:
                    return "volumen_ag_autorizado" + sufijo;
                case VOL_AG_UTILIZADO:
                    return "volumen_ag_utilizado" + sufijo;
                default: return null;
            }
        }

        /// <summary>
        /// Inserta un registro de volumen DR a la base de datos.
        /// </summary>
        /// <param name="v">
        /// Es la instancia del registro a insertar.
        /// </param>
        /// /// <param name="tipo">
        /// Es el tipo de volumen a insertar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado de manera correcta o false si no
        /// se pudo insertar.
        /// </returns>
        public static bool InsertarVolumenDr(VolumenDr v, int tipo)
        {
            InitConnection();
            bool insertado = false;
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return false;
            string sql = string.Format("INSERT INTO {0} VALUES('{1}', {2}, "
                + "{3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})", nombreTabla,
                v.Ciclo, v.Dr033, v.Dr045, v.Dr011, v.Dr085, v.Dr087, v.Dr022,
                v.Dr061, v.Dr024, v.Dr013);
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;
            if (GetVolumenDr(v.Ciclo, tipo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }
            return insertado;
        }

        /// <summary>
        /// Obtiene el registro del volumen DR para el ciclo especificado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el ciclo a buscar.
        /// </param>
        /// <param name="tipo">
        /// Es el tipo de volumen a buscar.
        /// </param>
        /// <returns>
        /// La instancia del volumen DR o null si no se encontro ningún registro
        /// para ese ciclo.
        /// </returns>
        public static VolumenDr GetVolumenDr(string ciclo, int tipo)
        {
            InitConnection();
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return null;
            string query = "SELECT * FROM [" + nombreTabla + "] WHERE "
                + "ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenDr vol = null;
                if (reader.Read())
                {
                    vol = new VolumenDr();
                    vol.Ciclo = reader.GetString(0);
                    vol.Dr033 = double.Parse(reader.GetValue(1).ToString());
                    vol.Dr045 = double.Parse(reader.GetValue(2).ToString());
                    vol.Dr011 = double.Parse(reader.GetValue(3).ToString());
                    vol.Dr085 = double.Parse(reader.GetValue(4).ToString());
                    vol.Dr087 = double.Parse(reader.GetValue(5).ToString());
                    vol.Dr022 = double.Parse(reader.GetValue(6).ToString());
                    vol.Dr061 = double.Parse(reader.GetValue(7).ToString());
                    vol.Dr024 = double.Parse(reader.GetValue(8).ToString());
                    vol.Dr013 = double.Parse(reader.GetValue(9).ToString());
                }
                reader.Close();
                return vol;
            }
        }

        /// <summary>
        /// Obtiene todos los registros del volumen DR.
        /// </summary>
        /// <param name="tipo">
        /// Es el tipo de volumen a buscar.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen DR o null si no se 
        /// encontraron registros.
        /// </returns>
        public static List<VolumenDr> GetAllVolumenDr(int tipo)
        {
            InitConnection();
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return null;
            string query = "SELECT * FROM [" + nombreTabla + "]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<VolumenDr> vols = new List<VolumenDr>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenDr vol = null;
                while (reader.Read())
                {
                    vol = new VolumenDr();
                    vol.Ciclo = reader.GetString(0);
                    vol.Dr033 = double.Parse(reader.GetValue(1).ToString());
                    vol.Dr045 = double.Parse(reader.GetValue(2).ToString());
                    vol.Dr011 = double.Parse(reader.GetValue(3).ToString());
                    vol.Dr085 = double.Parse(reader.GetValue(4).ToString());
                    vol.Dr087 = double.Parse(reader.GetValue(5).ToString());
                    vol.Dr022 = double.Parse(reader.GetValue(6).ToString());
                    vol.Dr061 = double.Parse(reader.GetValue(7).ToString());
                    vol.Dr024 = double.Parse(reader.GetValue(8).ToString());
                    vol.Dr013 = double.Parse(reader.GetValue(9).ToString());
                    vols.Add(vol);
                }
                reader.Close();
                return vols;
            }
        }

        /// <summary>
        /// Inserta un registro de volumen PI a la base de datos.
        /// </summary>
        /// <param name="v">
        /// Es la instancia del registro a insertar.
        /// </param>
        /// <param name="tipo">
        /// Es la constante que inndica el tipo de volumen PI a insetar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado de manera correcta o false si no
        /// se pudo insertar.
        /// </returns>
        public static bool InsertarVolumenPi(VolumenPi v, int tipo)
        {
            InitConnection();
            bool insertado = false;
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return false;
            string sql = string.Format("INSERT INTO {0} VALUES('{1}', {2}, "
                + "{3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13} "
                + ", {14}, {15}, {16})", nombreTabla, v.Ciclo, v.PiAlzate,
                v.PiRamirez, v.PiTepetitlan, v.PiTepuxtepec, v.PiSolis,
                v.PiBegona, v.PiQueretaro, v.PiPericos, v.PiAdjuntas,
                v.PiAngulo, v.PiCorrales, v.PiYurecuaro, v.PiDuero, v.PiZula,
                v.PiChapala);
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;
            if (GetVolumenPi(v.Ciclo, tipo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }
            return insertado;
        }

        /// <summary>
        /// Obtiene el registro del volumen PI para el ciclo especificado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el ciclo a buscar.
        /// </param>
        /// <param name="tipo">
        /// Es la constante que indica el tipo de volumen PI a obtener.
        /// </param>
        /// <returns>
        /// La instancia del volumen PI o null si no se encontro ningún registro
        /// para ese ciclo.
        /// </returns>
        public static VolumenPi GetVolumenPi(string ciclo, int tipo)
        {
            InitConnection();
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return null;
            string query = "SELECT * FROM [" + nombreTabla + "] WHERE "
                + "ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenPi vol = null;
                if (reader.Read())
                {
                    vol = new VolumenPi();
                    vol.Ciclo = reader.GetValue(0).ToString();
                    vol.PiAlzate = double.Parse(reader.GetValue(1).ToString());
                    vol.PiRamirez = double.Parse(reader.GetValue(2).ToString());
                    vol.PiTepetitlan = double.Parse(reader.GetValue(3).ToString());
                    vol.PiTepuxtepec = double.Parse(reader.GetValue(4).ToString());
                    vol.PiSolis = double.Parse(reader.GetValue(5).ToString());
                    vol.PiBegona = double.Parse(reader.GetValue(6).ToString());
                    vol.PiQueretaro = double.Parse(reader.GetValue(7).ToString());
                    vol.PiPericos = double.Parse(reader.GetValue(8).ToString());
                    vol.PiAdjuntas = double.Parse(reader.GetValue(9).ToString());
                    vol.PiAngulo = double.Parse(reader.GetValue(10).ToString());
                    vol.PiCorrales = double.Parse(reader.GetValue(11).ToString());
                    vol.PiYurecuaro = double.Parse(reader.GetValue(12).ToString());
                    vol.PiDuero = double.Parse(reader.GetValue(13).ToString());
                    vol.PiZula = double.Parse(reader.GetValue(14).ToString());
                    vol.PiChapala = double.Parse(reader.GetValue(15).ToString());
                }
                reader.Close();
                return vol;
            }
        }

        /// <summary>
        /// Obtiene todos los registros del volumen PI.
        /// </summary>
        /// <returns>
        /// Una lista con los registros del volumen PI o null si no se 
        /// encontraron registros.
        /// </returns>
        public static List<VolumenPi> GetAllVolumenPi(int tipo)
        {
            InitConnection();
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return null;
            string query = "SELECT * FROM [" + nombreTabla + "]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<VolumenPi> vols = new List<VolumenPi>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenPi vol = null;
                while (reader.Read())
                {
                    vol = new VolumenPi();
                    vol.Ciclo = reader.GetValue(0).ToString();
                    vol.PiAlzate = double.Parse(reader.GetValue(1).ToString());
                    vol.PiRamirez = double.Parse(reader.GetValue(2).ToString());
                    vol.PiTepetitlan = double.Parse(reader.GetValue(3).ToString());
                    vol.PiTepuxtepec = double.Parse(reader.GetValue(4).ToString());
                    vol.PiSolis = double.Parse(reader.GetValue(5).ToString());
                    vol.PiBegona = double.Parse(reader.GetValue(6).ToString());
                    vol.PiQueretaro = double.Parse(reader.GetValue(7).ToString());
                    vol.PiPericos = double.Parse(reader.GetValue(8).ToString());
                    vol.PiAdjuntas = double.Parse(reader.GetValue(9).ToString());
                    vol.PiAngulo = double.Parse(reader.GetValue(10).ToString());
                    vol.PiCorrales = double.Parse(reader.GetValue(11).ToString());
                    vol.PiYurecuaro = double.Parse(reader.GetValue(12).ToString());
                    vol.PiDuero = double.Parse(reader.GetValue(13).ToString());
                    vol.PiZula = double.Parse(reader.GetValue(14).ToString());
                    vol.PiChapala = double.Parse(reader.GetValue(15).ToString());
                    vols.Add(vol);
                }
                reader.Close();
                return vols;
            }
        }

        /// <summary>
        /// Devuelve todos los registros de lluvia anual por estación.
        /// </summary>
        /// <returns>
        /// Una lista con las lluvias anuales.
        /// </returns>
        public static List<LluviaAnualEstacion> GetAllLluviaAnualEstacion()
        {
            InitConnection();
            string query = "SELECT * FROM [lluvia_ae]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<LluviaAnualEstacion> laes = new List<LluviaAnualEstacion>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                LluviaAnualEstacion lae = null;

                while (reader.Read())
                {
                    lae = ReadLaeFromReader(reader);
                    laes.Add(lae);
                }

                reader.Close();
            }
            return laes;
        }

        /// <summary>
        /// Inserta un registro a la tabla de lluvia_ae.
        /// </summary>
        /// <param name="lae">
        /// Es el registro de lluvia anual por estación a insertar.
        /// </param>
        /// <returns>
        /// true si el registro fue insertado o false si no se pudo insertar.
        /// </returns>
        public static bool InsertarLluviaAnualEstacion(LluviaAnualEstacion lae)
        {
            InitConnection();

            bool insertado = false;

            string sql = string.Format("INSERT INTO lluvia_ae " +
                "VALUES('{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, " +
                "{9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, " +
                "{19}, {20}, {21}, {22}, {23}, {24}, {25})", lae.Ciclo,
                lae.LaeCelaya, lae.LaeGuanajuato, lae.LaeIrapuato,
                lae.LaeAdjuntas, lae.LaeLeon, lae.LaePPenuelitas,
                lae.LaePSolis, lae.LaeSanFelipe, lae.LaeSanLuisDeLaPaz,
                lae.LaeYuriria, lae.LaeChapala, lae.LaeFuerte, lae.LaeTule,
                lae.LaeTizapan, lae.LaeYurecuaro, lae.LaeAtlacomulco,
                lae.LaeTolucaRectoria, lae.LaeChincua, lae.LaeCuitzeoAu,
                lae.LaeMelchorOcampo, lae.LaeMorelia, lae.LaeTepuxtepec,
                lae.LaeZacapu, lae.LaeZamora, lae.LaeQueretaroObs);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetLluviaAnualEstacion(lae.Ciclo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }

            return insertado;
        }

        /// <summary>
        /// Devuelve la lluvia anual por estación con el ciclo dado, 
        /// o null si no existe ningún registro con ese ciclo.
        /// </summary>
        /// <param name="ciclo">Es el ciclo que identifica al registro.</param>
        /// <returns>
        /// La lluvia anual por estación buscada.
        /// </returns>
        public static LluviaAnualEstacion GetLluviaAnualEstacion(string ciclo)
        {
            InitConnection();

            string query = "SELECT * FROM [lluvia_ae] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                LluviaAnualEstacion lae = null;

                if (reader.Read())
                {
                    lae = ReadLaeFromReader(reader);
                }

                reader.Close();
                return lae;
            }
        }

        /// <summary>
        /// Lee los datos de una lluvia anual por estación a partir de un 
        /// SqlDataReader que ya contiene un registro de la tabla lluvia_ae.
        /// </summary>
        /// <param name="reader">
        /// Es el reader que contiene el registro leido.
        /// </param>
        /// <returns>
        /// Instancia de LluviaAnualEstacion generada a partir del reader.
        /// </returns>
        private static LluviaAnualEstacion ReadLaeFromReader(SqlDataReader reader)
        {
            LluviaAnualEstacion lae = new LluviaAnualEstacion();
            lae.Ciclo = reader.GetString(0);
            lae.LaeCelaya = double.Parse(reader.GetValue(1).ToString());
            lae.LaeGuanajuato = double.Parse(reader.GetValue(2).ToString());
            lae.LaeIrapuato = double.Parse(reader.GetValue(3).ToString());
            lae.LaeAdjuntas = double.Parse(reader.GetValue(4).ToString());
            lae.LaeLeon = double.Parse(reader.GetValue(5).ToString());
            lae.LaePPenuelitas = double.Parse(reader.GetValue(6).ToString());
            lae.LaePSolis = double.Parse(reader.GetValue(7).ToString());
            lae.LaeSanFelipe = double.Parse(reader.GetValue(8).ToString());
            lae.LaeSanLuisDeLaPaz = double.Parse(reader.GetValue(9).ToString());
            lae.LaeYuriria = double.Parse(reader.GetValue(10).ToString());
            lae.LaeChapala = double.Parse(reader.GetValue(11).ToString());
            lae.LaeFuerte = double.Parse(reader.GetValue(12).ToString());
            lae.LaeTule = double.Parse(reader.GetValue(13).ToString());
            lae.LaeTizapan = double.Parse(reader.GetValue(14).ToString());
            lae.LaeYurecuaro = double.Parse(reader.GetValue(15).ToString());
            lae.LaeAtlacomulco = double.Parse(reader.GetValue(16).ToString());
            lae.LaeTolucaRectoria = double.Parse(reader.GetValue(17).ToString());
            lae.LaeChincua = double.Parse(reader.GetValue(18).ToString());
            lae.LaeCuitzeoAu = double.Parse(reader.GetValue(19).ToString());
            lae.LaeMelchorOcampo = double.Parse(reader.GetValue(20).ToString());
            lae.LaeMorelia = double.Parse(reader.GetValue(21).ToString());
            lae.LaeTepuxtepec = double.Parse(reader.GetValue(22).ToString());
            lae.LaeZacapu = double.Parse(reader.GetValue(23).ToString());
            lae.LaeZamora = double.Parse(reader.GetValue(24).ToString());
            lae.LaeQueretaroObs = double.Parse(reader.GetValue(25).ToString());
            return lae;
        }

        /// <summary>
        /// Inserta un registro de volumen PI old.
        /// </summary>
        /// <param name="vol">
        /// Instancia del volumen a ingresar
        /// </param>
        /// <param name="tipo">
        /// Tipo de volumen PI old a insertar: autorizado o utilizado.
        /// </param>
        /// <returns>
        /// true si la inserción se realizó de forma correcta o false en caso 
        /// contrario.
        /// </returns>
        public static bool InsertarVolumenPiOld(VolumenPiOld vol, int tipo)
        {
            InitConnection();
            bool insertado = false;
            string nombreTabla = GetNombreTablaVolumen(tipo, "_old");
            if (nombreTabla == null) return false;

            string sql = string.Format("INSERT INTO {0} VALUES('{1}', {2}, "
                + "{3}, {4}, {5}, {6})", nombreTabla, vol.Ciclo, 
                vol.PiAltoLerma, vol.PiRioQueretaro, vol.PiBajio, 
                vol.PiAnguloDuero, vol.PiBajoLerma);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetVolumenPiOld(vol.Ciclo, tipo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }

            return insertado;
        }

        /// <summary>
        /// Lee un volumen pi old a partir de un reader sql.
        /// </summary>
        private static VolumenPiOld ReadVolumenPiOldFromReader(SqlDataReader reader) {
            VolumenPiOld vol = new VolumenPiOld();

            vol.Ciclo= reader.GetString(0);
            vol.PiAltoLerma = double.Parse(reader.GetValue(1).ToString());
            vol.PiRioQueretaro = double.Parse(reader.GetValue(2).ToString());
            vol.PiBajio = double.Parse(reader.GetValue(3).ToString());
            vol.PiAnguloDuero = double.Parse(reader.GetValue(4).ToString());
            vol.PiBajoLerma = double.Parse(reader.GetValue(5).ToString());

            return vol;
        }

        /// <summary>
        /// Obtiene el registro del volumen PI old para el ciclo especificado.
        /// </summary>
        /// <param name="ciclo">
        /// Ciclo que identifica al volumen.
        /// </param>
        /// <param name="tipo">
        /// Tipo de volumen PI old a buscar: autorizado o utilizado.
        /// </param>
        /// <returns>
        /// Instancia del volumen buscado o null si no se encontró.
        /// </returns>
        public static VolumenPiOld GetVolumenPiOld(string ciclo, int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo, "_old");
            string query = "SELECT * FROM [" + nombreTabla + "] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenPiOld vol = null;

                if (reader.Read())
                {
                    vol = ReadVolumenPiOldFromReader(reader);
                }

                reader.Close();
                return vol;
            }
        }

        /// <summary>
        /// Obtiene una lista de los volúmenes PI old.
        /// </summary>
        /// <param name="tipo">
        /// Tipo de volúmenes PI old a obtener: autorizados o utilzados.
        /// </param>
        /// <returns>
        /// Lista con los volúmenes encontrados.
        /// </returns>
        public static List<VolumenPiOld> GetAllVolumenPiOld(int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo, "_old");
            string query = "SELECT * FROM [" + nombreTabla + "]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<VolumenPiOld> vols = new List<VolumenPiOld>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenPiOld vol = null;

                while (reader.Read())
                {
                    vol = ReadVolumenPiOldFromReader(reader);
                    vols.Add(vol);
                }

                reader.Close();
                return vols;
            }
        }

        private static VolumenGt ReadVolumenGtFromReader(SqlDataReader reader)
        {
            VolumenGt vol = new VolumenGt();
            vol.Ciclo = reader.GetString(0);
            vol.Volumen = double.Parse(reader.GetValue(1).ToString());
            return vol;
        }

        public static VolumenGt GetVolumenGt(string ciclo, int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo);
            string query = "SELECT * FROM [" + nombreTabla + "] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenGt vol = null;

                if (reader.Read())
                {
                    vol = ReadVolumenGtFromReader(reader);
                }

                reader.Close();
                return vol;
            }
        }

        public static bool InsertarVolumenGt(VolumenGt vol, 
            int tipo)
        {
            InitConnection();
            bool insertado = false;
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return false;

            string sql = string.Format("INSERT INTO {0} VALUES('{1}', {2})", 
                nombreTabla, vol.Ciclo, vol.Volumen);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetVolumenGt(vol.Ciclo, tipo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }

            return insertado;
        }

        public static List<VolumenGt> GetAllVolumenGt(int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo);
            string query = "SELECT * FROM [" + nombreTabla + "]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<VolumenGt> vols = new List<VolumenGt>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenGt vol = null;

                while (reader.Read())
                {
                    vol = ReadVolumenGtFromReader(reader);
                    vols.Add(vol);
                }

                reader.Close();
                return vols;
            }
        }

        private static VolumenAg ReadVolumenAgFromReader(SqlDataReader reader)
        {
            VolumenAg vol = new VolumenAg();
            vol.Ciclo = reader.GetString(0);
            vol.Volumen = double.Parse(reader.GetValue(1).ToString());
            return vol;
        }

        public static VolumenAg GetVolumenAg(string ciclo, int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo);
            string query = "SELECT * FROM [" + nombreTabla + "] WHERE ciclo=@ciclo";
            SqlCommand command = new SqlCommand(query, conexion);
            command.Parameters.AddWithValue("@ciclo", ciclo);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenAg vol = null;

                if (reader.Read())
                {
                    vol = ReadVolumenAgFromReader(reader);
                }

                reader.Close();
                return vol;
            }
        }

        public static bool InsertarVolumenAg(VolumenAg vol, int tipo)
        {
            InitConnection();
            bool insertado = false;
            string nombreTabla = GetNombreTablaVolumen(tipo);
            if (nombreTabla == null) return false;

            string sql = string.Format("INSERT INTO {0} VALUES('{1}', {2})",
                nombreTabla, vol.Ciclo, vol.Volumen);

            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.CommandType = CommandType.Text;

            if (GetVolumenGt(vol.Ciclo, tipo) == null)
            {
                try
                {
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Logger.AddToLog(ex.Message, true);
                }
            }

            return insertado;
        }

        public static List<VolumenAg> GetAllVolumenAg(int tipo)
        {
            InitConnection();

            string nombreTabla = GetNombreTablaVolumen(tipo);
            string query = "SELECT * FROM [" + nombreTabla + "]";
            SqlCommand command = new SqlCommand(query, conexion);
            List<VolumenAg> vols = new List<VolumenAg>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                VolumenAg vol = null;

                while (reader.Read())
                {
                    vol = ReadVolumenAgFromReader(reader);
                    vols.Add(vol);
                }

                reader.Close();
                return vols;
            }
        }
    }
}